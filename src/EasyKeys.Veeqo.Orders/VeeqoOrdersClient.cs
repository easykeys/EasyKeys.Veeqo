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
        try
        {
            var result = await _client.PostAsJsonAsync(endpoint, new RequestOrderNote() { Text = text }, cancellationToken);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<OrderNote>();

            ArgumentNullException.ThrowIfNull(response, nameof(OrderNote));

            return new VeeqoResult<OrderNote>(success: true, data: response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(CreateOrderNotesAsync));
            return new VeeqoResult<OrderNote>(success: false, error: ex.Message);
        }

    }

    public async Task<VeeqoResult<Order>> CreateOrderAsync(RequestOrder order, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders";

        try
        {
            var response = await _client.PostAsJsonAsync(endpoint, new { order = order }, cancellationToken);

            response.EnsureSuccessStatusCode();

            var model = await response.Content.ReadFromJsonAsync<Order>();

            ArgumentNullException.ThrowIfNull(model, nameof(Order));

            return new VeeqoResult<Order>(success: true, data: model);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(CreateOrderAsync));
            return new VeeqoResult<Order>(success: false, error: ex.Message);
        }


    }

    public async Task<VeeqoResult<Order>> GetOrderAsync(int orderId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders/{orderId}";

        try
        {
            var response = await _client.GetFromJsonAsync<Order>(endpoint, cancellationToken);


            ArgumentNullException.ThrowIfNull(response, nameof(Order));

            return new VeeqoResult<Order>(success: true, data: response);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(GetOrderAsync));
            return new VeeqoResult<Order>(success: false, error: ex.Message);
        }

    }

    public async Task<VeeqoResult<List<Order>>> ListOrdersAsync(GetOrdersParameters parameters, CancellationToken cancellationToken = default)
    {
        try
        {
            var models = await _client.GetFromJsonAsync<List<Order>>(parameters.GetUrl(), cancellationToken);


            ArgumentNullException.ThrowIfNull(models, nameof(Order));

            return new VeeqoResult<List<Order>>(success: true, data: models);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(ListOrdersAsync));
            return new VeeqoResult<List<Order>>(success: false, error: ex.Message);
        }

    }

    public async Task<VeeqoResult<Order>> UpdateOrderAsync(int veeqoOrderId, RequestOrder order, CancellationToken cancellationToken = default)
    {
        var endpoint = $"orders/{veeqoOrderId}";

        try
        {
            var response = await _client.PutAsJsonAsync(endpoint, new { order = order }, cancellationToken);

            response.EnsureSuccessStatusCode();

            var model = await response.Content.ReadFromJsonAsync<Order>();

            ArgumentNullException.ThrowIfNull(model, nameof(Order));

            return new VeeqoResult<Order>(success: true, data: model);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{veeqoOrdersClient} failed", nameof(UpdateOrderAsync));
            return new VeeqoResult<Order>(success: false, error: ex.Message);
        }
    }
}