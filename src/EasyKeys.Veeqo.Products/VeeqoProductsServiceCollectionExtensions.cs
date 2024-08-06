using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System.Threading.RateLimiting;

namespace EasyKeys.Veeqo.Products;

public static class VeeqoProductsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoProductsClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoProductsClient, VeeqoProductsClient>(
            nameof(VeeqoProductsClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddResilienceHandler(nameof(VeeqoProductsClient), (resiliencePipeline, context) =>
            {
                resiliencePipeline.AddRetry(new HttpRetryStrategyOptions
                {
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true,  // Adds a random factor to the delay
                    MaxRetryAttempts = 4,
                    Delay = TimeSpan.FromSeconds(3),
                    OnRetry = (outcome) =>
                    {
                        context.ServiceProvider.GetRequiredService<ILoggerFactory>()
                            .CreateLogger(nameof(VeeqoProductsClient))
                            .LogWarning("Retrying request");

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

        return services;
    }
}
