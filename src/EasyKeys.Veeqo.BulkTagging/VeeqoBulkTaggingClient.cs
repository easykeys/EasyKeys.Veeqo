

using EasyKeys.Veeqo.Abstractions.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.BulkTagging;

public class VeeqoBulkTaggingClient : IVeeqoBulkTaggingClient
{
    private readonly ILogger<VeeqoBulkTaggingClient> _logger;

    private readonly HttpClient _client;

    public VeeqoBulkTaggingClient(HttpClient httpClient, ILogger<VeeqoBulkTaggingClient> logger)
    {
        _client = httpClient;
        _logger = logger;
    }

    public async Task<VeeqoResult<int>> BulkTagOrdersAsync(int[] orderIds, int[] tagIds, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/bulk_tagging";

        try
        {

           var response = await _client.PostAsJsonAsync(endpoint, new { order_ids = orderIds, tag_ids = tagIds }, cancellationToken);

            response.EnsureSuccessStatusCode();

            return new VeeqoResult<int>(success: true, data: (int)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(BulkTagOrdersAsync));
            return new VeeqoResult<int>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<int>> BulkTagProductsAsync(int[] productIds, int[] tagIds, CancellationToken cancellationToken = default)
    {
        var endpoint = $"bulk_tagging";

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var response = await _client.PostAsJsonAsync(endpoint, new { product_ids = productIds, tag_ids = tagIds }, cancellationToken);

            response.EnsureSuccessStatusCode();

            return new VeeqoResult<int>(success: true, data: (int)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(BulkTagProductsAsync));

            return new VeeqoResult<int>(success: false, error: ex.Message);
        }

    }
}