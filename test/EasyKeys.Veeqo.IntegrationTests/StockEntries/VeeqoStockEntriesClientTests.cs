
using Microsoft.Extensions.DependencyInjection;

using EasyKeys.Veeqo.StockEntries;
using EasyKeys.Veeqo.StockEntries.Models.Request;

namespace EasyKeys.Veeqo.IntegrationTests.StockEntries;

public class VeeqoStockEntriesClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoStockEntriesClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [RunnableInDebugOnly]
    public async Task Show_Update_StockEntryAsync()
    {
        var stockEntryId = 1;
        var warehouseId = 2;

        var veeqoStockEntriesClient = sp.GetRequiredService<IVeeqoStockEntriesClient>();

        var result = await veeqoStockEntriesClient.ShowStockEntryAsync(stockEntryId, warehouseId);

        Assert.True(result.Success);

        var newStockEntry = new RequestStockEntry
        {
            Infinite = true,
            StockLevel = 188
        };

        var updateResult = await veeqoStockEntriesClient.UpdateStockEntryAsync(stockEntryId, warehouseId, newStockEntry);

        Assert.True(updateResult.Success);

    }

}