using EasyKeys.Veeqo.Abstractions;
using EasyKeys.Veeqo.Abstractions.Options;
using EasyKeys.Veeqo.Rates.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyKeys.Veeqo.Rates;

public static class VeeqoRatesServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoRatesClient(this IServiceCollection services)
    {
        services.AddVeeqoOptions();

        services.AddOptions<VeeqoRatesClientOptions>()
            .Configure<IConfiguration>((o, c) =>
            {
                o.BaseUrl = c["VeeqoRatesClientOptions:BaseUrl"]!;
                o.ApiKey = c["VeeqoRatesClientOptions:ApiKey"]!;
            });

        services
            .AddHttpClient<IVeeqoRatesClient, VeeqoRatesClient>(
                nameof(VeeqoRatesClient),
                (sp, o) =>
                {
                    var ratesOptions = sp.GetRequiredService<IOptions<VeeqoRatesClientOptions>>().Value;
                    var baseOptions = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;

                    var baseUrl = string.IsNullOrWhiteSpace(ratesOptions.BaseUrl) ? baseOptions.BaseUrl : ratesOptions.BaseUrl;
                    var apiKey = string.IsNullOrWhiteSpace(ratesOptions.ApiKey) ? baseOptions.ApiKey : ratesOptions.ApiKey;

                    o.BaseAddress = new Uri(baseUrl);
                    o.DefaultRequestHeaders.Clear();
                    o.DefaultRequestHeaders.Add("x-api-key", apiKey);
                })
            .AddClientResiliencyPipeline(nameof(VeeqoRatesClient));

        return services;
    }
}
