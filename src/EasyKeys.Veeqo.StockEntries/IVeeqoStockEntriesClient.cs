using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.StockEntries.Models.Request;
using EasyKeys.Veeqo.StockEntries.Models.Response;

namespace EasyKeys.Veeqo.StockEntries;

public interface IVeeqoStockEntriesClient
{
    Task<VeeqoResult<InventoryItem>> UpdateStockEntryAsync(long sellableId, long warehouseId, RequestStockEntry stockEntry, CancellationToken cancellationToken = default);

    Task<VeeqoResult<InventoryItem>> ShowStockEntryAsync(long sellableId, long warehouseId, CancellationToken cancellationToken = default);

}
