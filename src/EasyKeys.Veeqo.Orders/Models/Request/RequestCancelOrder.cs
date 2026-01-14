using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class RequestCancelOrder
{
    [JsonPropertyName("id")]
    public int OrderId { get; set; }

    [JsonPropertyName("cancel_reason")]
    public string CancelReason { get; set; } = "";

    [JsonPropertyName("send_veeqo_email")]
    public bool SendVeeqoEmail { get; set; } = false;
}
