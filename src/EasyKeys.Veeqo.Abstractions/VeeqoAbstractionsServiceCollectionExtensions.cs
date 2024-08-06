using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyKeys.Veeqo.Abstractions;


public static class VeeqoAbstractionsServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoOptions(this IServiceCollection services)
    {
        services.AddOptions<VeeqoClientOptions>()
        .Configure<IConfiguration>((o, c) =>
        {
            o.BaseUrl = c["VeeqoClientOptions:BaseUrl"]!;
            o.ApiKey = c["VeeqoClientOptions:ApiKey"]!;
        });

        return services;
    }
}
