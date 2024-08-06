using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class ResponseProduct
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("notes")]
    public string Notes { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("tags")]
    public List<ResponseTag> Tags { get; set; } = new List<ResponseTag>();

    [JsonPropertyName("active_channels")]
    public List<ResponseActiveChannel> ActiveChannels { get; set; } = new List<ResponseActiveChannel>();

    [JsonPropertyName("sellables")]
    public ResponseSellable[] Sellables { get; set; } = Array.Empty<ResponseSellable>();
}
