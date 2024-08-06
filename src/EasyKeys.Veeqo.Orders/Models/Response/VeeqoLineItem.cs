using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class VeeqoLineItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("sellable")]
    public LineItemSellable Sellable { get; set; } = new LineItemSellable();

    [JsonPropertyName("price_per_unit")]
    public decimal PricePerUnit { get; set; }
}
