using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Orders.Models.Parameters;
using EasyKeys.Veeqo.Orders.Models.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.Orders;
public class VeeqoOrdersClient : IVeeqoOrdersClient
{
    private readonly ILogger<VeeqoOrdersClient> _logger;
    private readonly HttpClient _client;

    public VeeqoOrdersClient(HttpClient client,ILogger<VeeqoOrdersClient> logger)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<VeeqoResult<OrderNote>> CreateOrderNotesAsync(int orderId, string text, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders/{orderId}/notes";
        var result = await _client.PostAsJsonAsync(endpoint, new RequestOrderNote() { Text = text }, cancellationToken);

        result.EnsureSuccessStatusCode();

        var response = await result.Content.ReadFromJsonAsync<OrderNote>();
        return new VeeqoResult<OrderNote>(success: true,data: response);
    }

    public async Task<VeeqoResult<Order>> CreateVeeqoOrderAsync(RequestOrder order, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders";

        var response = await _client.PostAsJsonAsync(endpoint, new { order = order }, cancellationToken);

        response.EnsureSuccessStatusCode();

        var model = await response.Content.ReadFromJsonAsync<Order>();

        return new VeeqoResult<Order>(success: true, data: model);
    }

    public async Task<VeeqoResult<Order>> GetOrderAsync(int orderId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders/{orderId}";

        var response = await _client.GetFromJsonAsync<Order>(endpoint, cancellationToken);

        return new VeeqoResult<Order>(success: true, data: response);
    }

    public async Task<VeeqoResult<List<Order>>> ListOrdersAsync(GetOrdersParameters parameters, CancellationToken cancellationToken = default)
    {
        var models = await _client.GetFromJsonAsync<List<Order>>(parameters.GetUrl(), cancellationToken);

        return new VeeqoResult<List<Order>>(success: true, data: models);
    }

    public async Task<VeeqoResult<Order>> UpdateVeeqoOrderAsync(int veeqoOrderId, RequestOrder order, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders/{veeqoOrderId}";

        var response = await _client.PutAsJsonAsync(endpoint, new { order = order }, cancellationToken);

        response.EnsureSuccessStatusCode();

        var model = await response.Content.ReadFromJsonAsync<Order>();

        return new VeeqoResult<Order>(success: true, data: model);
    }
}