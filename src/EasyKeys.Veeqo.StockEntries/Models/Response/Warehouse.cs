using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.StockEntries.Models.Response;

public class Warehouse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("user_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object UserId { get; set; }

    [JsonPropertyName("address_line_1")]
    public string AddressLine1 { get; set; }

    [JsonPropertyName("address_line_2")]
    public string AddressLine2 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("country")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Country { get; set; }

    [JsonPropertyName("post_code")]
    public string PostCode { get; set; }

    [JsonPropertyName("inventory_type_code")]
    public string InventoryTypeCode { get; set; }

    [JsonPropertyName("default_min_reorder")]
    public int DefaultMinReorder { get; set; }

    [JsonPropertyName("click_and_collect_enabled")]
    public bool ClickAndCollectEnabled { get; set; }

    [JsonPropertyName("click_and_collect_days")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object ClickAndCollectDays { get; set; }

    [JsonPropertyName("created_by_id")]
    public int CreatedById { get; set; }

    [JsonPropertyName("updated_by_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object UpdatedById { get; set; }

    [JsonPropertyName("deleted_at")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object DeletedAt { get; set; }

    [JsonPropertyName("deleted_by_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object DeletedById { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("phone")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Phone { get; set; }

    [JsonPropertyName("requested_carrier_account")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object RequestedCarrierAccount { get; set; }
}