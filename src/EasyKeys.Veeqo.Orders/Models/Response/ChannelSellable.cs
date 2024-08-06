using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class ChannelSellable
{
    [JsonPropertyName("remote_title")]
    public string RemoteTitle { get; set; } = string.Empty;
}
