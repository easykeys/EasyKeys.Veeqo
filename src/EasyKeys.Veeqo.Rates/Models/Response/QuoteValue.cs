using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class QuoteValue
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}
