using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Orders.Models.Parameters;
using EasyKeys.Veeqo.Orders.Models.Response;

namespace EasyKeys.Veeqo.Orders;

public interface IVeeqoOrdersClient
{
    Task<VeeqoResult<List<Order>>> ListOrdersAsync(
    GetOrdersParameters parameters,
    CancellationToken cancellationToken = default);

    Task<VeeqoResult<Order>> GetOrderAsync(int orderId, CancellationToken cancellationToken = default);

    Task<VeeqoResult<Order>> CreateOrderAsync(RequestOrder order, CancellationToken cancellationToken = default);

    Task<VeeqoResult<Order>> UpdateOrderAsync(int orderId, RequestOrder order, CancellationToken cancellationToken = default);

    Task<VeeqoResult<OrderNote>> CreateOrderNotesAsync(
        int orderId,
        string text,
        CancellationToken cancellationToken = default);
}
