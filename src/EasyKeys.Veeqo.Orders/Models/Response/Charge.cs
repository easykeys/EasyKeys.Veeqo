using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Charge
{
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
    [JsonPropertyName("chargeId")]
    public string ChargeId { get; set; } = string.Empty;
    [JsonPropertyName("chargeType")]
    public string ChargeType { get; set; } = string.Empty;
}