namespace EasyKeys.Veeqo.Abstractions.Request;

public abstract class VeeqoParameter
{
#pragma warning disable SA1401 // Fields should be private
    protected readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();
#pragma warning restore SA1401 // Fields should be private

    public abstract string Endpoint { get; }

    public Dictionary<string, string> Parameters => _dictionary;

    public string GetUrl()
    {
        var endpoint = Endpoint;

        endpoint += "?";

        foreach (var query in _dictionary)
        {
            if (!string.IsNullOrEmpty(query.Value))
                endpoint += $"{query.Key}={query.Value}&";
        }

        if (endpoint.EndsWith("&"))
        {
            endpoint = endpoint[..^1];
        }

        return endpoint;
    }

    public void Clear()
    {
        _dictionary.Clear();
    }
}
