using EasyKeys.Veeqo.Abstractions.Response;

namespace EasyKeys.Veeqo.BulkTagging;

public interface IVeeqoBulkTaggingClient
{
    Task<VeeqoResult<int>> BulkTagProductsAsync(int[] productIds, int[] tagIds,bool remove = false, CancellationToken cancellationToken = default);

    Task<VeeqoResult<int>> BulkTagOrdersAsync(int[] orderIds, int[] tagIds,bool remove = false, CancellationToken cancellationToken = default);
}
