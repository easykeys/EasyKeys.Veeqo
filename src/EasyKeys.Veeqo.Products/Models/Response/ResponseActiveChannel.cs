using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Products.Models.Response;

public class ResponseActiveChannel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type_code")]
    public string TypeCode { get; set; } = string.Empty;

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;
}
