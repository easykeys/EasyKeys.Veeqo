using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Orders.Models.Parameters;
using Microsoft.Extensions.DependencyInjection;

namespace EasyKeys.Veeqo.IntegrationTests;

public class VeeqoOrdersClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoOrdersClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [Fact]
    public async Task ListOrdersAsync()
    {
        // Arrange
        var veeqoOrdersClient = sp.GetRequiredService<IVeeqoOrdersClient>();

        // Act
        var result = await veeqoOrdersClient.ListOrdersAsync(new GetOrdersParameters());

        //var jsontest = JsonSerializer.Serialize(result);
        //var fileName = Path.Combine("Data/KeyModels", jsonFile);
        //var expectedJson = File.ReadAllText(fileName);

        //var expectedResult = JsonSerializer.Deserialize<KeyViewModel>(expectedJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //// Assert
        //Assert.Equivalent(expectedResult, result);
    }

}