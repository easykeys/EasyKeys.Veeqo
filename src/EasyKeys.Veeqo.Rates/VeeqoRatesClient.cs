using EasyKeys.Veeqo.Abstractions.Response;
using EasyKeys.Veeqo.Rates.Models.Request;
using EasyKeys.Veeqo.Rates.Models.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.Rates;

public class VeeqoRatesClient : IVeeqoRatesClient
{
    private readonly HttpClient _client;
    private readonly ILogger<VeeqoRatesClient> _logger;

    public VeeqoRatesClient(HttpClient httpClient, ILogger<VeeqoRatesClient> logger)
    {
        _client = httpClient;
        _logger = logger;
    }

    public async Task<VeeqoResult<ResponseRates>> GetRatesAsync(RequestRates request, CancellationToken cancellationToken = default)
    {
        const string endpoint = "/shipping/api/v1/rates";

        try
        {
            var response = await _client.PostAsJsonAsync(endpoint, request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogError("{veeqoClientMethod} failed with {message}", nameof(GetRatesAsync), errorMsg);
                return new VeeqoResult<ResponseRates>(success: false, error: errorMsg);
            }

            var model = await response.Content.ReadFromJsonAsync<ResponseRates>(cancellationToken: cancellationToken);

            ArgumentNullException.ThrowIfNull(model, nameof(ResponseRates));

            return new VeeqoResult<ResponseRates>(success: true, data: model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{veeqoClientMethod} failed.", nameof(GetRatesAsync));
            return new VeeqoResult<ResponseRates>(success: false, error: ex.Message);
        }
    }

}
