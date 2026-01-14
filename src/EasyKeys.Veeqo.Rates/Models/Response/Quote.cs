using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class Quote
{
    [JsonPropertyName("rate_id")]
    public string? RateId { get; set; }

    [JsonPropertyName("service_name")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("carrier_id")]
    public string? CarrierId { get; set; }

    [JsonPropertyName("service_carrier")]
    public string? ServiceCarrier { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("delivery_estimate")]
    public DateTimeOffset? DeliveryEstimate { get; set; }

    [JsonPropertyName("total_charge")]
    public string? TotalCharge { get; set; }

    [JsonPropertyName("base_rate")]
    public string? BaseRate { get; set; }

    [JsonPropertyName("charges")]
    public List<Charge>? Charges { get; set; }

    [JsonPropertyName("shipping_service_options")]
    public List<ShippingServiceOption>? ShippingServiceOptions { get; set; }

    [JsonPropertyName("credits")]
    public double? Credits { get; set; }

    [JsonPropertyName("own_account")]
    public bool? OwnAccount { get; set; }

    [JsonPropertyName("protected")]
    public bool? Protected { get; set; }

    [JsonPropertyName("protections")]
    public List<string>? Protections { get; set; }

    [JsonPropertyName("service_id")]
    public string? ServiceId { get; set; }
}
