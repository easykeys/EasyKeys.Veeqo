
namespace EasyKeys.Veeqo.Abstractions.Response;

public class VeeqoResult<T>
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public T Data { get; set; }

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8601 // Possible null reference assignment.
    public VeeqoResult(bool success, string error = null, T data = default(T))
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    {
        Success = success;
        Error = error;
        Data = data;
    }

    public override string ToString()
    {
        return $"BaseResult(Success={Success}, Error={Error}, Data={Data})";
    }

    public IDictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
            {
                { "Success", Success },
                { "Error", Error },
                { "Data", Data }
            };
    }
}