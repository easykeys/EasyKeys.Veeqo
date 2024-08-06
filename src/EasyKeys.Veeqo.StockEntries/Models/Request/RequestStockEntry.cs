using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyKeys.Veeqo.StockEntries.Models.Request;

public class RequestStockEntry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("physical_stock_level")]
    public int StockLevel { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("infinite")]
    public bool Infinite { get; set; } = false;
}
