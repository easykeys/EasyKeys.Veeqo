using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class ReturnedVeeqoOrders
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("line_items")]
    public List<ReturnedLineItem> ReturnedLineItems { get; set; } = new List<ReturnedLineItem>();
}
