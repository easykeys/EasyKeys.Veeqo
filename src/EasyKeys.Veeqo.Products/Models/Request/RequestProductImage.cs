using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Request;

public class RequestProductImage
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("src")]
    public string? Src { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("display_position")]
    public int? DisplayPosition { get; set; }
}
