using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class Inventory
{
    [JsonPropertyName("infinite")]
    public bool? Infinite { get; set; }

    [JsonPropertyName("physical_stock_level_at_all_warehouses")]
    public int? PhysicalStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("allocated_stock_level_at_all_warehouses")]
    public int? AllocatedStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("available_stock_level_at_all_warehouses")]
    public int? AvailableStockLevelAtAllWarehouses { get; set; }

    [JsonPropertyName("incoming_stock_level_at_all_warehouses")]
    public int? IncomingStockLevelAtAllWarehouses { get; set; }
}
