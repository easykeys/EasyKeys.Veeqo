using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Products.Models.Parameters;
using EasyKeys.Veeqo.Products.Models.Request;
using EasyKeys.Veeqo.Products.Models.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.Products;

public class VeeqoProductsClient : IVeeqoProductsClient
{
    private readonly ILogger<VeeqoProductsClient> _logger;
    private readonly HttpClient _client;

    public VeeqoProductsClient(HttpClient client, ILogger<VeeqoProductsClient> logger)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<VeeqoResult<ResponseProduct>> CreateProductAsync(RequestProduct product, CancellationToken cancellationToken = default)
    {
        try
        {
            var endpoint = $"products";

            var response = await _client.PostAsJsonAsync(endpoint, product, cancellationToken);

            response.EnsureSuccessStatusCode();

            var model = await response.Content.ReadFromJsonAsync<ResponseProduct>();

            return new VeeqoResult<ResponseProduct>(success: true, data: model);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(CreateProductAsync));
            return new VeeqoResult<ResponseProduct>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<int>> DeleteProductAsync(int productId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"products/{productId}";

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var response = await _client.DeleteAsync(endpoint, cancellationToken);

            response.EnsureSuccessStatusCode();

            return new VeeqoResult<int>(success: true, data: (int)response.StatusCode);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(DeleteProductAsync));
            return new VeeqoResult<int>(success: false, error: ex.Message); 
        }

    }

    public async Task<VeeqoResult<List<ResponseProduct>>> ListProductsAsync(GetProductsParameters parameters, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _client.GetFromJsonAsync<List<ResponseProduct>>(parameters.GetUrl(), cancellationToken);
            return new VeeqoResult<List<ResponseProduct>>(success: true, data: response);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(ListProductsAsync));
            return new VeeqoResult<List<ResponseProduct>>(success: false, error: ex.Message);
        }
    }

    public async Task<VeeqoResult<ResponseProduct>> UpdateProductAsync(int productId, RequestProduct product, CancellationToken cancellationToken = default)
    {
        try
        {
            var endpoint = $"/products/{productId}";

            var response = await _client.PutAsJsonAsync(endpoint, product, cancellationToken);

            response.EnsureSuccessStatusCode();

            var updatedProduct = await response.Content.ReadFromJsonAsync<ResponseProduct>();

            return new VeeqoResult<ResponseProduct>(success: true, data: updatedProduct);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(UpdateProductAsync));
            return new VeeqoResult<ResponseProduct>(success: false, error: ex.Message);
        }
    }
}