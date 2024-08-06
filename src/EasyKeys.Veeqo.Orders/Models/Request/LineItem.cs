using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class LineItem
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_per_unit")]
    public decimal? PricePerUnit { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxless_discount_per_unit")]
    public decimal? TaxlessDiscountPerUnit { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    [JsonPropertyName("tax_rate")]
    public decimal TaxRate { get; set; }

    [JsonPropertyName("sellable_id")]
    public int SellableId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("additional_options")]
    public string? AdditionalOptions { get; set; }
}
