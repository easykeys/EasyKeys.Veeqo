using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Orders.Models.Response;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace EasyKeys.Veeqo.UnitTests;

public class VeeqoOrdersClientTests
{
    private readonly Mock<ILogger<VeeqoOrdersClient>> _loggerMock;

    public VeeqoOrdersClientTests()
    {
        _loggerMock = new Mock<ILogger<VeeqoOrdersClient>>();
    }

    [Fact]
    public async Task CreateOrderNotesAsync_Success()
    {
        // Arrange
        var orderId = 123;
        var text = "Note text";
        var endpoint = $"orders/{orderId}/notes";
        var responseContent = new OrderNote { /* set properties if needed */ };

        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = JsonContent.Create(responseContent)
        };

        var handler = new MockHttpMessageHandler(httpResponseMessage);
        var httpMock = new HttpClient(handler) { BaseAddress = new Uri("https://private-anon-7f66466dcd-veeqo.apiary-mock.com/") };
        var client = new VeeqoOrdersClient(httpMock, _loggerMock.Object);

        // Act
        var result = await client.CreateOrderNotesAsync(orderId, text);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
    }
}
public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpResponseMessage _httpResponseMessage;

    public MockHttpMessageHandler(HttpResponseMessage httpResponseMessage)
    {
        _httpResponseMessage = httpResponseMessage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_httpResponseMessage);
    }
}
