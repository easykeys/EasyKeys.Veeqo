using EasyKeys.Veeqo.Abstractions.Response;

namespace EasyKeys.Veeqo.BulkTagging;

public interface IVeeqoBulkTaggingClient
{
    Task<VeeqoResult<int>> BulkTagProductsAsync(int[] productIds, int[] tagIds, CancellationToken cancellationToken = default);

    Task<VeeqoResult<int>> BulkTagOrdersAsync(int[] orderIds, int[] tagIds, CancellationToken cancellationToken = default);
}
