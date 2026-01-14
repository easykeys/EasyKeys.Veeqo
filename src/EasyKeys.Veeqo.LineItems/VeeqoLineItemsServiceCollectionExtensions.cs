using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.LineItems.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.LineItems;


public static class VeeqoLineItemsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoLineItemsClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoLineItemsClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoLineItemsClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoLineItemsClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoLineItemsClient, VeeqoLineItemsClient>(
            nameof(VeeqoLineItemsClient),
            (sp, o) =>
            {
                var lineItemOptions = sp.GetRequiredService<IOptions<VeeqoLineItemsClientOptions>>().Value;
                var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                var baseUrl = string.IsNullOrWhiteSpace(lineItemOptions.BaseUrl) ? baseOptions.BaseUrl : lineItemOptions.BaseUrl;
                var apiKey = string.IsNullOrWhiteSpace(lineItemOptions.ApiKey) ? baseOptions.ApiKey : lineItemOptions.ApiKey;

                o.BaseAddress = new Uri(baseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", apiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoLineItemsClient));

        return services;
    }
}
