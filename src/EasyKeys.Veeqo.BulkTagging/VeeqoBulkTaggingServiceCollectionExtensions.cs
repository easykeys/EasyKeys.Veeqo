

using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.BulkTagging.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.BulkTagging;

public static class VeeqoBulkTaggingServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoBulkTaggingClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoBulkTaggingClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoBulkTaggingClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoBulkTaggingClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoBulkTaggingClient, VeeqoBulkTaggingClient>(
            nameof(VeeqoBulkTaggingClient),
            (sp, o) =>
            {
                var bulkTaggingOptions = sp.GetRequiredService<IOptions<VeeqoBulkTaggingClientOptions>>().Value;
                var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                var baseUrl = string.IsNullOrWhiteSpace(bulkTaggingOptions.BaseUrl) ? baseOptions.BaseUrl : bulkTaggingOptions.BaseUrl;
                var apiKey = string.IsNullOrWhiteSpace(bulkTaggingOptions.ApiKey) ? baseOptions.ApiKey : bulkTaggingOptions.ApiKey;

                o.BaseAddress = new Uri(baseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", apiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoBulkTaggingClient));


        return services;
    }
}
