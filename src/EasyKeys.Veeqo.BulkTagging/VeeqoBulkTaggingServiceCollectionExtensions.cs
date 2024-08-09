

using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
            .AddClientResiliencyPipeline(nameof(VeeqoBulkTaggingClient));


        return services;
    }
}
