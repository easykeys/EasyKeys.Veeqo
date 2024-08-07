namespace EasyKeys.Veeqo.Abstractions.Options;

public class VeeqoClientOptions
{
    public string ApiKey { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public bool IsDevelopment { get; set; } = true;
}
