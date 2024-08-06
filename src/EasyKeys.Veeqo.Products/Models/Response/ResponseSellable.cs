using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class ResponseSellable
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("sku_code")]
    public string Sku { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("inventory")]
    public Inventory? Inventory { get; set; }

    [JsonPropertyName("channel_sellables")]
    public List<ResponseChannelSellable> ChannelSellables { get; set; } = new List<ResponseChannelSellable>();
}
