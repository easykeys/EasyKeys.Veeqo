using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Request;
public class MeasurementAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("width")]
    public decimal Width { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("height")]
    public decimal Height { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("depth")]
    public decimal Depth { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensions_unit")]
    public string DimensionsUnit { get; set; } = "inches";
}
