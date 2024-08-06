using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Product
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
    public List<Tag> Tags { get; set; } = new List<Tag>();

    [JsonPropertyName("active_channels")]
    public List<ActiveChannel> ActiveChannels { get; set; } = new List<ActiveChannel>();

    [JsonPropertyName("sellables")]
    public ProductSellable[] Sellables { get; set; } = Array.Empty<ProductSellable>();
}
