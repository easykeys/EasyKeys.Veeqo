

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

    public async Task<VeeqoResult<int>> BulkTagOrdersAsync(int[] orderIds, int[] tagIds,bool remove = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/bulk_tagging";

        try
        {
            HttpResponseMessage response;

            if (remove)
            {                
                response = await _client.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_client.BaseAddress!, endpoint),
                    Content = JsonContent.Create(new { order_ids = orderIds, tag_ids = tagIds })
                }, cancellationToken);
            }
            else
            {
                response = await _client.PostAsJsonAsync(endpoint, new { order_ids = orderIds, tag_ids = tagIds }, cancellationToken);
            }

            response.EnsureSuccessStatusCode();

            return new VeeqoResult<int>(success: true, data: (int)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(BulkTagOrdersAsync));
            return new VeeqoResult<int>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<int>> BulkTagProductsAsync(int[] productIds, int[] tagIds,bool remove, CancellationToken cancellationToken = default)
    {
        var endpoint = $"bulk_tagging";

        try
        {
            HttpResponseMessage response;

            if(remove)
            {
                response = await _client.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_client.BaseAddress!, endpoint),
                    Content = JsonContent.Create(new { product_ids = productIds, tag_ids = tagIds })
                }, cancellationToken);
            }
            else
            {
                response = await _client.PostAsJsonAsync(endpoint, new { product_ids = productIds, tag_ids = tagIds }, cancellationToken);
            }

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