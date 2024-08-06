using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Order
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; } = string.Empty;

    [JsonPropertyName("shipped_at")]
    public DateTime? ShippedAt { get; set; }

    [JsonPropertyName("channel")]
    public Channel Channel { get; set; } = new Channel();

    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; } = new List<Tag>();

    [JsonPropertyName("employee_notes")]
    public List<EmployeeNote> EmployeeNotes { get; set; } = new List<EmployeeNote>();

    [JsonPropertyName("line_items")]
    public List<VeeqoLineItem> LineItems { get; set; } = new List<VeeqoLineItem>();

    [JsonPropertyName("returns")]
    public List<ReturnedVeeqoOrders> Returns { get; set; } = new List<ReturnedVeeqoOrders>();
}
