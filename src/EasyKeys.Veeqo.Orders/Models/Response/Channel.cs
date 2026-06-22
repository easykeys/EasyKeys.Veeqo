using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Orders.Models.Response;

public class Channel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("type_code")]
    public string TypeCode { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
