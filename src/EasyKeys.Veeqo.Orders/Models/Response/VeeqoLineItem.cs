using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class VeeqoLineItem
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("quantity")]
    public long Quantity { get; set; }

    [JsonPropertyName("sellable")]
    public LineItemSellable Sellable { get; set; } = new LineItemSellable();

    [JsonPropertyName("price_per_unit")]
    public decimal PricePerUnit { get; set; }

    [JsonPropertyName("additional_options")]
    public string AdditionalOptions { get; set; } = string.Empty;
}
