namespace EasyKeys.Veeqo.Abstractions.Options;

public class VeeqoClientOptions
{
    public required string ApiKey { get; set; }

    public required string BaseUrl { get; set; }

    public bool IsDevelopment { get; set; } = true;
}
