using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.StockEntries.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.StockEntries;

public static class VeeqoStockEntriesServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoStockEntriesClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoStockEntriesClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoStockEntriesClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoStockEntriesClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoStockEntriesClient, VeeqoStockEntriesClient>(
            nameof(IVeeqoStockEntriesClient),
            (sp, o) =>
            {
                var stockEntriesOptions = sp.GetRequiredService<IOptions<VeeqoStockEntriesClientOptions>>().Value;
                var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                var baseUrl = string.IsNullOrWhiteSpace(stockEntriesOptions.BaseUrl) ? baseOptions.BaseUrl : stockEntriesOptions.BaseUrl;
                var apiKey = string.IsNullOrWhiteSpace(stockEntriesOptions.ApiKey) ? baseOptions.ApiKey : stockEntriesOptions.ApiKey;

                o.BaseAddress = new Uri(baseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", apiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoStockEntriesClient));


        return services;
    }
}
