using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.LineItems;


public static class VeeqoLineItemsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoLineItemsClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoLineItemsClient, VeeqoLineItemsClient>(
            nameof(VeeqoLineItemsClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoLineItemsClient));

        return services;
    }
}
