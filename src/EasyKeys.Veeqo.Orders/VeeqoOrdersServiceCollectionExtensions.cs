using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.Orders.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EasyKeys.Veeqo.Abstractions;

namespace EasyKeys.Veeqo.Orders;

public static class VeeqoOrdersServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoOrdersClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoOrdersClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoOrdersClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoOrdersClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoOrdersClient, VeeqoOrdersClient>(
            nameof(VeeqoOrdersClient),
            (sp, o) =>
            {
                var ordersOptions = sp.GetRequiredService<IOptions<VeeqoOrdersClientOptions>>().Value;
                var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                var baseUrl = string.IsNullOrWhiteSpace(ordersOptions.BaseUrl) ? baseOptions.BaseUrl : ordersOptions.BaseUrl;
                var apiKey = string.IsNullOrWhiteSpace(ordersOptions.ApiKey) ? baseOptions.ApiKey : ordersOptions.ApiKey;

                o.BaseAddress = new Uri(baseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", apiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoOrdersClient));

        return services;
    }
}
