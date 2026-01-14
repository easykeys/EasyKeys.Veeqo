using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class ErrorResponse
{
    [JsonPropertyName("error_messages")]
    public List<string>? ErrorMessages { get; set; }
}
