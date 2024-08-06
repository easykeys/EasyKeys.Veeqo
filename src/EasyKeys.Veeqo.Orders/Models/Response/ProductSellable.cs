using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;
public class ProductSellable
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
    public List<ChannelSellable> ChannelSellables { get; set; } = new List<ChannelSellable>();
}
