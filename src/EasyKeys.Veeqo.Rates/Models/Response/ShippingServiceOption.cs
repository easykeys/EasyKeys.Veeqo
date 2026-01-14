using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class ShippingServiceOption
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("multiple")]
    public bool? Multiple { get; set; }

    [JsonPropertyName("values")]
    public List<QuoteValue>? Values { get; set; }

    [JsonPropertyName("validation")]
    public QuoteValidation? Validation { get; set; }

    [JsonPropertyName("default")]
    public string? Default { get; set; }
}
