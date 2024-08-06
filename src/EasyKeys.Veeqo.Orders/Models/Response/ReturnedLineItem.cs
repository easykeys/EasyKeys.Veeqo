using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class ReturnedLineItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("sku_code")]
    public string Sku { get; set; } = string.Empty;

    [JsonPropertyName("received_quantity")]
    public int RecievedQuantity { get; set; }
}
