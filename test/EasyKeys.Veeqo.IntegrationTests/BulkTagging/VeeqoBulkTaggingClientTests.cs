using Microsoft.Extensions.DependencyInjection;
using EasyKeys.Veeqo.BulkTagging;

namespace EasyKeys.Veeqo.IntegrationTests.BulkTagging;

public class VeeqoBulkTaggingClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoBulkTaggingClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [Fact]
    public async Task Tag_Orders_Products_Async()
    {
        var veeqoBulkTaggingClient = sp.GetRequiredService<IVeeqoBulkTaggingClient>();

        var ordersTag = await veeqoBulkTaggingClient.BulkTagOrdersAsync([1,2,3], [1,3,4]);

        Assert.True(ordersTag.Success);

        var productsTag = await veeqoBulkTaggingClient.BulkTagProductsAsync([1, 2, 3], [1, 3, 4]);

        Assert.True(productsTag.Success);

    }


}