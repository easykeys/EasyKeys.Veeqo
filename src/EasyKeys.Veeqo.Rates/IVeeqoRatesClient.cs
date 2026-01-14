using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Rates.Models.Request;
using EasyKeys.Veeqo.Rates.Models.Response;

namespace EasyKeys.Veeqo.Rates;

public interface IVeeqoRatesClient
{
    Task<VeeqoResult<ResponseRates>> GetRatesAsync(RequestRates request, CancellationToken cancellationToken = default);
}
