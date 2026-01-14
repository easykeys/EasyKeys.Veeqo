using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Rates.Models.Request;

public class RequestRates
{
    [JsonPropertyName("to_address")]
    public Address ToAddress { get; set; } = new();

    [JsonPropertyName("from_address")]
    public Address FromAddress { get; set; } = new();

    [JsonPropertyName("return_address")]
    public Address? ReturnAddress { get; set; }

    [JsonPropertyName("parcels")]
    public List<Parcel> Parcels { get; set; } = new();

    [JsonPropertyName("customer_reference")]
    public string? CustomerReference { get; set; }

    [JsonPropertyName("contents")]
    public string? Contents { get; set; }

    [JsonPropertyName("estimated_value")]
    public string? EstimatedValue { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("customer_type")]
    public string? CustomerType { get; set; }

    [JsonPropertyName("is_amazon_order")]
    public bool? IsAmazonOrder { get; set; }

    [JsonPropertyName("seller_display_name")]
    public string? SellerDisplayName { get; set; }

    [JsonPropertyName("preferred_shipment_date")]
    public DateTimeOffset? PreferredShipmentDate { get; set; }

    [JsonPropertyName("due_date")]
    public DateTimeOffset? DueDate { get; set; }

    [JsonPropertyName("liability_amount")]
    public double? LiabilityAmount { get; set; }

    [JsonPropertyName("contents_type")]
    public string? ContentsType { get; set; }

    [JsonPropertyName("restriction_type")]
    public string? RestrictionType { get; set; }

    [JsonPropertyName("country_of_origin")]
    public string? CountryOfOrigin { get; set; }

    [JsonPropertyName("channel_items")]
    public List<ChannelItem>? ChannelItems { get; set; }

    [JsonPropertyName("shipping_configuration_ids")]
    public List<string>? ShippingConfigurationIds { get; set; }

    [JsonPropertyName("include_unavailable_quotes")]
    public bool? IncludeUnavailableQuotes { get; set; }
}
