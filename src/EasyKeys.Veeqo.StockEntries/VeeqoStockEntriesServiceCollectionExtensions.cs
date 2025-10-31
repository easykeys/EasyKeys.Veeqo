using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.StockEntries;

public static class VeeqoStockEntriesServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoStockEntriesClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoStockEntriesClient, VeeqoStockEntriesClient>(
            nameof(IVeeqoStockEntriesClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoStockEntriesClient));


        return services;
    }
}
