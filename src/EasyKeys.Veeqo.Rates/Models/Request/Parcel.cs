using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Request;

public class Parcel
{
    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("weight_unit")]
    public string WeightUnit { get; set; } = string.Empty;

    [JsonPropertyName("height")]
    public double? Height { get; set; }

    [JsonPropertyName("width")]
    public double? Width { get; set; }

    [JsonPropertyName("length")]
    public double? Length { get; set; }

    [JsonPropertyName("dimension_unit")]
    public string? DimensionUnit { get; set; }

    [JsonPropertyName("hazmat")]
    public bool? Hazmat { get; set; }
}
