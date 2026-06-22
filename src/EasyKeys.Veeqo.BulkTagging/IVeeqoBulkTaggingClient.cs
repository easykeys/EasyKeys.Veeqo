using EasyKeys.Veeqo.Abstractions.Response;

namespace EasyKeys.Veeqo.BulkTagging;

public interface IVeeqoBulkTaggingClient
{
    Task<VeeqoResult<long>> BulkTagProductsAsync(long[] productIds, long[] tagIds, bool remove = false, CancellationToken cancellationToken = default);

    Task<VeeqoResult<long>> BulkTagOrdersAsync(long[] orderIds, long[] tagIds, bool remove = false, CancellationToken cancellationToken = default);
}
