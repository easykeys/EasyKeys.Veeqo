
namespace EasyKeys.Veeqo.Abstractions.Response;

public class VeeqoResult<T>
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public T Data { get; set; }

    public VeeqoResult(bool success, string error = null, T data = default(T))
    {
        Success = success;
        Error = error;
        Data = data;
    }

    public override string ToString()
    {
        return $"BaseResult(Success={Success}, Error={Error}, Data={Data})";
    }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>
            {
                { "Success", Success },
                { "Error", Error },
                { "Data", Data }
            };
    }
}