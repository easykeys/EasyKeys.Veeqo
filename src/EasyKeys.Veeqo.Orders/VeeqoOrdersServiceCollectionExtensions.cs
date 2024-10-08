﻿using EasyKeys.Veeqo.Abstractions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EasyKeys.Veeqo.Abstractions;

namespace EasyKeys.Veeqo.Orders;

public static class VeeqoOrdersServiceCollectionExtensions
{
    public static IServiceCollection AddVeeqoOrdersClient(this IServiceCollection services)
    {
        services
            .AddVeeqoOptions()
            .AddHttpClient<IVeeqoOrdersClient, VeeqoOrdersClient>(
            nameof(VeeqoOrdersClient),
            (sp, o) =>
            {
                var options = sp.GetRequiredService<IOptions<VeeqoClientOptions>>().Value;
                o.BaseAddress = new Uri(options.BaseUrl);
                o.DefaultRequestHeaders.Clear();
                o.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            })
            .AddClientResiliencyPipeline(nameof(VeeqoOrdersClient));

        return services;
    }
}
