using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.LineItems.Models;

public class RequestLineItemNote
{
    [JsonPropertyName("additional_options")]
    public string AdditionalOptions { get; set; } = string.Empty;
}