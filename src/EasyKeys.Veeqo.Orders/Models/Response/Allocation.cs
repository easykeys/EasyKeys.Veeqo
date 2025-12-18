using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Allocation
{
    [JsonPropertyName("shipment")]
    public Shipment? Shipment { get; set; }
}
