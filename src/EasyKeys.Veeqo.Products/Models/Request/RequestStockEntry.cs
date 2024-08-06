using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Request;

public class RequestStockEntry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("physical_stock_level")]
    public int StockLevel { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("infinite")]
    public bool Infinite { get; set; } = false;
}
