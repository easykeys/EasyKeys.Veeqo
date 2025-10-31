using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class LineItemSellable
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("sku_code")]
    public string SkuCode { get; set; } = string.Empty;

    [JsonPropertyName("product")]
    public Product Product { get; set; } = new Product();

    [JsonPropertyName("sellable_title")]
    public string SellableTitle { get; set; } = string.Empty;

    [JsonPropertyName("product_title")]
    public string ProductTitle { get; set; } = string.Empty;
}
