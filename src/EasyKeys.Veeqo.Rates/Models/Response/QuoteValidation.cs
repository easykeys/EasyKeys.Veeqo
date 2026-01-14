using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Response;

public class QuoteValidation
{
    [JsonPropertyName("min")]
    public double? Min { get; set; }

    [JsonPropertyName("max")]
    public double? Max { get; set; }
}
