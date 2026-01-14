using EasyKeys.Veeqo.Rates;
using EasyKeys.Veeqo.Rates.Models.Request;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace EasyKeys.Veeqo.IntegrationTests.Rates;

public class VeeqoRatesClientTests
{
    private readonly IServiceProvider sp;
    private readonly ITestOutputHelper _output;
    public VeeqoRatesClientTests(ITestOutputHelper output)
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
        _output = output;
    }

    [RunnableInDebugOnly]
    public async Task GetDomesticRates_Successfully()
    {
        var client = sp.GetRequiredService<IVeeqoRatesClient>();

        var request = new RequestRates
        {
            ToAddress = new Address
            {
                Name = "John Smith",
                Phone = "+12125551234",
                Line1 = "350 5th Ave",
                Town = "New York",
                Postcode = "10118",
                CountryCode = "US",
                County = "NY"
            },
            FromAddress = new Address
            {
                Name = "Veeqo Fulfillment",
                Company = "Veeqo Inc",
                Phone = "+12065551234",
                Line1 = "410 Terry Ave N",
                Town = "Seattle",
                Postcode = "98109",
                CountryCode = "US",
                County = "WA"
            },
            Parcels = new List<Parcel>
            {
                new()
                {
                    Weight = 1.5,
                    WeightUnit = "lb",
                    Height = 10,
                    Width = 10,
                    Length = 10,
                    DimensionUnit = "in"
                }
            },
            CustomerReference = "ORDER-12345"
        };

        var result = await client.GetRatesAsync(request);

        Assert.True(result.Success, result.Error);

        foreach(var quote in result.Data.Quotes)
        {
            _output.WriteLine($"{quote.ServiceName}, Total: {quote.TotalCharge} {quote.Currency}, ETA: {quote.DeliveryEstimate.Value.Date.ToString("MM-dd")}");
        }
        Assert.NotNull(result.Data);
    }


    [RunnableInDebugOnly]
    public async Task GetDomesticRates_BadRequest()
    {
        var client = sp.GetRequiredService<IVeeqoRatesClient>();

        var request = new RequestRates
        {
            ToAddress = new Address
            {
                Name = "John Smith",
                Phone = "+12125551234",
                Line1 = "350 5th Ave",
                Town = "New York",
                Postcode = "10118",
                CountryCode = "US",
                County = "NY"
            },
            FromAddress = new Address
            {
                Name = "Veeqo Fulfillment",
                Company = "Veeqo Inc",
                Phone = "+12065551234",
                Line1 = "410 Terry Ave N",
                Town = "Seattle",
                Postcode = "11333",
                CountryCode = "US",
                County = "WA"
            },
            Parcels = new List<Parcel>
            {
                new()
                {
                    Weight = 1.5,
                    WeightUnit = "lb",
                    Height = 10,
                    Width = 10,
                    Length = 10,
                    DimensionUnit = "in"
                }
            },
            CustomerReference = "ORDER-12345"
        };

        var result = await client.GetRatesAsync(request);

        Assert.False(result.Success);

        _output.WriteLine($"{result.Error}");
    }
}
