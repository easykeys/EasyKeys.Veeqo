

using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System.Threading.RateLimiting;

namespace EasyKeys.Veeqo.BulkTagging;

public static class VeeqoBulkTaggingServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoBulkTaggingClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoBulkTaggingClient, VeeqoBulkTaggingClient>(
            nameof(VeeqoBulkTaggingClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddResilienceHandler(nameof(VeeqoBulkTaggingClient), (resiliencePipeline, context) =>
            {
                resiliencePipeline.AddRetry(new HttpRetryStrategyOptions
                {
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true,  // Adds a random factor to the delay
                    MaxRetryAttempts = 4,
                    Delay = TimeSpan.FromSeconds(3),
                    OnRetry = async (outcome) =>
                    {
                        context.ServiceProvider.GetRequiredService<ILoggerFactory>()
                            .CreateLogger(nameof(VeeqoBulkTaggingClient))
                            .LogWarning("Retrying request");
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
