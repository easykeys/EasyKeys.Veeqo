using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.RateLimiting;
using Polly.Timeout;
using System.Net;
using System.Threading.RateLimiting;

namespace EasyKeys.Veeqo.Abstractions;


public static class VeeqoAbstractionsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoOptions(this IServiceCollection services)
    {
        services.AddOptions<VeeqoClientOptions>()
        .Configure<IConfiguration>((o, c) =>
        {
            o.BaseUrl = c["VeeqoClientOptions:BaseUrl"]!;
            o.ApiKey = c["VeeqoClientOptions:ApiKey"]!;
        });

        return services;
    }

    public static IHttpClientBuilder AddClientResiliencyPipeline(this IHttpClientBuilder builder, string clientName)
    {
        builder.AddResilienceHandler(clientName, (resiliencePipeline, context) =>
        {
            resiliencePipeline.AddRetry(new HttpRetryStrategyOptions
            {
                ShouldHandle = args => args switch
                {
                    { Outcome.Result.StatusCode: HttpStatusCode.TooManyRequests } => PredicateResult.True(),
                    { Outcome.Result.StatusCode: HttpStatusCode.ServiceUnavailable } => PredicateResult.True(),
                    { Outcome.Result.StatusCode: HttpStatusCode.InternalServerError } => PredicateResult.True(),
                    { Outcome.Result.StatusCode: HttpStatusCode.RequestTimeout } => PredicateResult.True(),
                    { Outcome.Exception: RateLimiterRejectedException } => PredicateResult.True(),
                    { Outcome.Exception: TaskCanceledException } => PredicateResult.True(),
                    { Outcome.Exception: HttpRequestException } => PredicateResult.True(),
                    { Outcome.Exception: OperationCanceledException } => PredicateResult.True(),
                    { Outcome.Exception: TimeoutRejectedException } => PredicateResult.True(),
                    _ => PredicateResult.False()
                },
                BackoffType = DelayBackoffType.Exponential,
                UseJitter = true,  // Adds a random factor to the delay
                MaxRetryAttempts = 4,
                Delay = TimeSpan.FromSeconds(3),
                OnRetry = (outcome) =>
                {
                    context.ServiceProvider.GetRequiredService<ILoggerFactory>()
                        .CreateLogger(clientName)
                        .LogWarning("Retrying request due to {message}", outcome.Outcome.Exception?.Message);

                    return default;
                }
            })
            .AddRateLimiter(new SlidingWindowRateLimiter(new SlidingWindowRateLimiterOptions
            {
                PermitLimit = 5,
                SegmentsPerWindow = 1,
                Window = TimeSpan.FromSeconds(1),
            }));
        });

        return builder;
    }
}
