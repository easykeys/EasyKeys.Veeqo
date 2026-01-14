using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.LineItems.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.LineItems;

public class VeeqoLineItemsClient : IVeeqoLineItemsClient
{
    private readonly ILogger<VeeqoLineItemsClient> _logger;
    private readonly HttpClient _client;

    public VeeqoLineItemsClient(HttpClient client, ILogger<VeeqoLineItemsClient> logger)
    {
        _logger = logger;
        _client = client;
    }
    public async Task<VeeqoResult<bool>> UpdateLineItemNotesAsync(int lineItemId, string note, CancellationToken cancellationToken = default)
    {
        var endpoint = $"line_items/{lineItemId}";

        try
        {
            var response = await _client.PutAsJsonAsync(endpoint, new RequestLineItemNote() { AdditionalOptions = note }, cancellationToken);

            response.EnsureSuccessStatusCode();

            return new VeeqoResult<bool>(success: true, data: true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(UpdateLineItemNotesAsync));
            return new VeeqoResult<bool>(success: false, data: false, error: ex.Message);
        }
    }
}
