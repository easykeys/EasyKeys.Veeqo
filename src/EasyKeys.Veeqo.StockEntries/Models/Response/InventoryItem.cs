using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyKeys.Veeqo.StockEntries.Models.Response;


public class InventoryItem
{
    [JsonPropertyName("sellable_id")]
    public int SellableId { get; set; }

    [JsonPropertyName("warehouse_id")]
    public int WarehouseId { get; set; }

    [JsonPropertyName("infinite")]
    public bool Infinite { get; set; }

    [JsonPropertyName("allocated_stock_level")]
    public int AllocatedStockLevel { get; set; }

    [JsonPropertyName("warehouse")]
    public Warehouse Warehouse { get; set; }

    [JsonPropertyName("location")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Location { get; set; }

    [JsonPropertyName("stock_running_low")]
    public bool StockRunningLow { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("incoming_stock_level")]
    public int IncomingStockLevel { get; set; }

    [JsonPropertyName("physical_stock_level")]
    public int PhysicalStockLevel { get; set; }

    [JsonPropertyName("available_stock_level")]
    public int AvailableStockLevel { get; set; }

    [JsonPropertyName("sellable_on_hand_value")]
    public decimal SellableOnHandValue { get; set; }
}
