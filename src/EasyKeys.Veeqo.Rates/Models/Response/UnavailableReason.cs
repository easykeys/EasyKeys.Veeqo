using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class UnavailableReason
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
