using EasyKeys.Veeqo.BulkTagging;
using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Products;
using EasyKeys.Veeqo.StockEntries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EasyKeys.Veeqo.IntegrationTests;

public static class IntegrationTestBuilder
{
    public static IServiceProvider BuildDiContainer()
    {
        var services = new ServiceCollection();

        var logFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .AddEnvironmentVariables();


        var config = configBuilder.Build();

        services.AddSingleton<IConfiguration>(config);
        services.AddVeeqoOrdersClient();
        services.AddVeeqoProductsClient();
        services.AddVeeqoStockEntriesClient();
        services.AddVeeqoBulkTaggingClient();
        return services.BuildServiceProvider();
    }

}