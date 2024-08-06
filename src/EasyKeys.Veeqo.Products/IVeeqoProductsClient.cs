using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Products.Models.Parameters;
using EasyKeys.Veeqo.Products.Models.Request;
using EasyKeys.Veeqo.Products.Models.Response;

namespace EasyKeys.Veeqo.Products;


public interface IVeeqoProductsClient
{
    Task<VeeqoResult<int>> DeleteProductAsync(int productId, CancellationToken cancellationToken = default);

    Task<VeeqoResult<ResponseProduct>> CreateProductAsync(RequestProduct product, CancellationToken cancellationToken = default);

    Task<VeeqoResult<ResponseProduct>> UpdateProductAsync(int productId, RequestProduct product, CancellationToken cancellationToken = default);

    Task<VeeqoResult<List<ResponseProduct>>> ListProductsAsync(
        GetProductsParameters parameters,
        CancellationToken cancellationToken = default);

}
