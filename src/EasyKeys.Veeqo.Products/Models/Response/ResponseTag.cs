using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class ResponseTag
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("colour")]
    public string Colour { get; set; } = string.Empty;
}
