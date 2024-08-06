using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Http.Resilience;
using Polly;
using System.Threading.RateLimiting;
using EasyKeys.Veeqo.Abstractions;

namespace EasyKeys.Veeqo.Orders;

public static class VeeqoOrdersServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoOrdersClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoOrdersClient, VeeqoOrdersClient>(
            nameof(VeeqoOrdersClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddResilienceHandler(nameof(VeeqoOrdersClient), (resiliencePipeline, context) =>
            {
                resiliencePipeline.AddRetry(new HttpRetryStrategyOptions
                {
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true,  // Adds a random factor to the delay
                    MaxRetryAttempts = 4,
                    Delay = TimeSpan.FromSeconds(3),
                })
                .AddRateLimiter(new SlidingWindowRateLimiter(new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = 5,
                    SegmentsPerWindow = 1,
                    Window = TimeSpan.FromSeconds(1),
                }));

            });

        return services;
    }
}
