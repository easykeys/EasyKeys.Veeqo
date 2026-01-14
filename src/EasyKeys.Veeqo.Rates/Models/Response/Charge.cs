using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class Charge
{
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("charge_id")]
    public string? ChargeId { get; set; }

    [JsonPropertyName("charge_title")]
    public string? ChargeTitle { get; set; }

    [JsonPropertyName("charge_type")]
    public string? ChargeType { get; set; }
}
