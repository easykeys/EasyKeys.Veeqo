using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Inventory
{
    [JsonPropertyName("infinite")]
    public bool? Infinite { get; set; }

    [JsonPropertyName("physical_stock_level_at_all_warehouses")]
    public long? PhysicalStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("allocated_stock_level_at_all_warehouses")]
    public long? AllocatedStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("available_stock_level_at_all_warehouses")]
    public long? AvailableStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("incoming_stock_level_at_all_warehouses")]
    public long? IncomingStockLevelAtAllWarehouses { get; set; }
}
