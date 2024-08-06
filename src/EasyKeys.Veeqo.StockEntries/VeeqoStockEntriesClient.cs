using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.StockEntries.Models.Request;
using EasyKeys.Veeqo.StockEntries.Models.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.StockEntries;

public class VeeqoStockEntriesClient : IVeeqoStockEntriesClient
{
    private readonly ILogger<VeeqoStockEntriesClient> _logger;

    private readonly HttpClient _client;

    public VeeqoStockEntriesClient(ILogger<VeeqoStockEntriesClient> logger, HttpClient httpClient)
    {
        _logger = logger;
        _client = httpClient;
    }

    public async Task<VeeqoResult<InventoryItem>> ShowStockEntryAsync(int sellableId, int warehouseId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"sellables/{sellableId}/warehouses/{warehouseId}/stock_entry";

        try
        {

            var inventoryItem = await _client.GetFromJsonAsync<InventoryItem>(endpoint,cancellationToken);

            ArgumentNullException.ThrowIfNull(inventoryItem, nameof(InventoryItem));

            return new VeeqoResult<InventoryItem>(success: true, data: inventoryItem);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(UpdateStockEntryAsync));
            return new VeeqoResult<InventoryItem>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<InventoryItem>> UpdateStockEntryAsync(int sellableId,int warehouseId, RequestStockEntry stockEntry, CancellationToken cancellationToken = default)
    {
        var endpoint = $"sellables/{sellableId}/warehouses/{warehouseId}/stock_entry";

        try
        {

            var response = await _client.PutAsJsonAsync(endpoint, stockEntry, cancellationToken);

            response.EnsureSuccessStatusCode();

            var inventoryItem = await response.Content.ReadFromJsonAsync<InventoryItem>(cancellationToken);

            ArgumentNullException.ThrowIfNull(inventoryItem, nameof(InventoryItem));

            return new VeeqoResult<InventoryItem>(success: true, data: inventoryItem);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(UpdateStockEntryAsync));
            return new VeeqoResult<InventoryItem>(success: false, error: ex.Message);
        }
    }
}