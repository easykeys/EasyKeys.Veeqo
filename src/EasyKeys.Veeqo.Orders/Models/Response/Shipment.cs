using System.Text.Json.Serialization;
using EasyKeys.Veeqo.Abstractions.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Shipment
{
    [JsonPropertyName("charges")]
    [JsonConverter(typeof(SingleOrArrayJsonConverter<Charge>))]
    public List<Charge> Charges { get; set; } = new List<Charge>();

    [JsonPropertyName("service_type")]
    public string? ServiceType { get; set; }
    [JsonPropertyName("service_name")]
    public string? ServiceName { get; set; }
    [JsonPropertyName("short_service_name")]
    public string? ShortServiceName { get; set; }
    [JsonPropertyName("service_carrier_name")]
    public string? ServiceCarrierName { get; set; }
    [JsonPropertyName("tracking_number")]
    public TrackingNumber? TrackingNumber { get; set; }

}
