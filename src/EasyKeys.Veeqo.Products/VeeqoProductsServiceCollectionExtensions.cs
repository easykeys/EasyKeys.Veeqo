using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
            .AddClientResiliencyPipeline(nameof(VeeqoProductsClient));


        return services;
    }
}
