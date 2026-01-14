using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class ResponseRates
{
    [JsonPropertyName("quotes")]
    public List<Quote>? Quotes { get; set; }

    [JsonPropertyName("unavailable_quotes")]
    public List<UnavailableQuote>? UnavailableQuotes { get; set; }

    [JsonPropertyName("remote_shipment_id")]
    public string? RemoteShipmentId { get; set; }

    [JsonPropertyName("request_token")]
    public string? RequestToken { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTimeOffset? ExpiresAt { get; set; }

    [JsonPropertyName("to_address_id")]
    public string? ToAddressId { get; set; }

    [JsonPropertyName("from_address_id")]
    public string? FromAddressId { get; set; }
}
