using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class TrackingNumber
{
    [JsonPropertyName("tracking_number")]
    public string? Tracking_Number { get; set; }
}