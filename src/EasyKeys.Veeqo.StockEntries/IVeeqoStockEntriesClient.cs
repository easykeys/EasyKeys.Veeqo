using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.StockEntries.Models.Request;
using EasyKeys.Veeqo.StockEntries.Models.Response;

namespace EasyKeys.Veeqo.StockEntries;

public interface IVeeqoStockEntriesClient
{
    Task<VeeqoResult<InventoryItem>> UpdateStockEntryAsync(int sellableId, int warehouseId, RequestStockEntry stockEntry, CancellationToken cancellationToken = default);

    Task<VeeqoResult<InventoryItem>> ShowStockEntryAsync(int sellableId, int warehouseId, CancellationToken cancellationToken = default);

}
