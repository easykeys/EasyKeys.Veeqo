using EasyKeys.Veeqo.Abstractions.Request;

namespace EasyKeys.Veeqo.Orders.Models.Parameters;

#pragma warning disable CS8601 // Possible null reference assignment.
public class GetOrdersParameters : VeeqoParameter
{
    public override string Endpoint => "orders";

    public int? Since_Id
    {
        get => int.Parse(_dictionary[nameof(Since_Id).ToLower()]);
        set => _dictionary[nameof(Since_Id).ToLower()] = value.ToString();
    }

    public DateTime? Created_At_Min
    {
        get => DateTime.Parse(_dictionary[nameof(Created_At_Min)]);
        set => _dictionary[nameof(Created_At_Min).ToLower()] = value?.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public DateTime? Updated_At_Min
    {
        get => DateTime.Parse(_dictionary[nameof(Updated_At_Min)]);
        set => _dictionary[nameof(Updated_At_Min).ToLower()] = value?.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public int? Page_Size
    {
        get => int.Parse(_dictionary[nameof(Page_Size)]);
        set => _dictionary[nameof(Page_Size).ToLower()] = value?.ToString();
    }

    public int? Page
    {
        get => int.Parse(_dictionary.GetValueOrDefault(nameof(Page).ToLower()) ?? "0");
        set => _dictionary[nameof(Page).ToLower()] = value?.ToString();
    }

    public string? Query
    {
        get => _dictionary[nameof(Query).ToLower()];
        set => _dictionary[nameof(Query).ToLower()] = value;
    }

    public string? Status
    {
        get => _dictionary[nameof(Status).ToLower()];
        set => _dictionary[nameof(Status).ToLower()] = value;
    }

    public string? Tags
    {
        get => _dictionary[nameof(Tags).ToLower()];
        set => _dictionary[nameof(Tags).ToLower()] = value;
    }

    public int? Allocated_At
    {
        get => int.Parse(_dictionary[nameof(Allocated_At)]);
        set => _dictionary[nameof(Allocated_At).ToLower()] = value?.ToString();
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.
