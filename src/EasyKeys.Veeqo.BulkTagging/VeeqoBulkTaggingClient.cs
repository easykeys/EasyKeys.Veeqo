

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

    public async Task<VeeqoResult<long>> BulkTagOrdersAsync(long[] orderIds, long[] tagIds, bool remove = false, CancellationToken cancellationToken = default)
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

            return new VeeqoResult<long>(success: true, data: (long)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(BulkTagOrdersAsync));
            return new VeeqoResult<long>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<long>> BulkTagProductsAsync(long[] productIds, long[] tagIds, bool remove, CancellationToken cancellationToken = default)
    {
        var endpoint = $"bulk_tagging";

        try
        {
            HttpResponseMessage response;

            if (remove)
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

            return new VeeqoResult<long>(success: true, data: (long)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(BulkTagProductsAsync));

            return new VeeqoResult<long>(success: false, error: ex.Message);
        }

    }
}