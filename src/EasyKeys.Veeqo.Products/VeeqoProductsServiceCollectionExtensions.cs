using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.Products.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.Products;

public static class VeeqoProductsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoProductsClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoProductsClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoProductsClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoProductsClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoProductsClient, VeeqoProductsClient>(
            nameof(VeeqoProductsClient),
            (sp, o) =>
            {
                var productsOptions = sp.GetRequiredService<IOptions<VeeqoProductsClientOptions>>().Value;
                var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                var baseUrl = string.IsNullOrWhiteSpace(productsOptions.BaseUrl) ? baseOptions.BaseUrl : productsOptions.BaseUrl;
                var apiKey = string.IsNullOrWhiteSpace(productsOptions.ApiKey) ? baseOptions.ApiKey : productsOptions.ApiKey;

                o.BaseAddress = new Uri(baseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", apiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoProductsClient));


        return services;
    }
}
