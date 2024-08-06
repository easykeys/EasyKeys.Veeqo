using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class ResponseChannelSellable
{
    [JsonPropertyName("remote_title")]
    public string RemoteTitle { get; set; } = string.Empty;
}
