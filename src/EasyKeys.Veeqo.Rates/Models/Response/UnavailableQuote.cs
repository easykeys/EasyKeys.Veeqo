using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class UnavailableQuote
{
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("service_carrier")]
    public string? ServiceCarrier { get; set; }

    [JsonPropertyName("sub_carrier_id")]
    public string? SubCarrierId { get; set; }

    [JsonPropertyName("unavailable_reasons")]
    public List<UnavailableReason>? UnavailableReasons { get; set; }
}
