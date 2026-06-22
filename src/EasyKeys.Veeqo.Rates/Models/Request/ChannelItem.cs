using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Request;

public class ChannelItem
{
    [JsonPropertyName("remote_id")]
    public string RemoteId { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public long? Quantity { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("asin")]
    public string? Asin { get; set; }

    [JsonPropertyName("tariff_code")]
    public string? TariffCode { get; set; }

    [JsonPropertyName("country_of_manufacture")]
    public string? CountryOfManufacture { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
