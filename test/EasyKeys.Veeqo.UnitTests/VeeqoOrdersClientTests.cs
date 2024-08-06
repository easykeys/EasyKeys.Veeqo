using System.Net.Http.Json;
using System.Net;
using Moq;
using EasyKeys.Veeqo.Orders;
using Microsoft.Extensions.Logging;
using EasyKeys.Veeqo.Orders.Models.Response;
using EasyKeys.Veeqo.Orders.Models.Parameters;
using Moq.Protected;

namespace EasyKeys.Veeqo.UnitTests
{
    public class VeeqoOrdersClientTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly Mock<ILogger<VeeqoOrdersClient>> _loggerMock;
        private readonly VeeqoOrdersClient _veeqoOrdersClient;

        public VeeqoOrdersClientTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://api.veeqo.com/")
            };
            _loggerMock = new Mock<ILogger<VeeqoOrdersClient>>();
            _veeqoOrdersClient = new VeeqoOrdersClient(_httpClient, _loggerMock.Object);
        }

        [Fact]
        public async Task CreateOrderNotesAsync_ShouldReturnSuccessResult()
        {
            // Arrange
            var orderId = 123;
            var text = "Test note";
            var orderNote = new OrderNote { Text = text };

            _httpMessageHandlerMock.SetupRequest(HttpMethod.Post, $"orders/{orderId}/notes");

            // Act
            var result = await _veeqoOrdersClient.CreateOrderNotesAsync(orderId, text);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(orderNote.Text, result.Data.Text);
        }

        [Fact]
        public async Task CreateVeeqoOrderAsync_ShouldReturnSuccessResult()
        {
            // Arrange
            var requestOrder = new RequestOrder { /* Initialize properties */ };
            var order = new Order { /* Initialize properties */ };

            _httpMessageHandlerMock.SetupRequest(HttpMethod.Post, "orders");

            // Act
            var result = await _veeqoOrdersClient.CreateVeeqoOrderAsync(requestOrder);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(order, result.Data);
        }

        [Fact]
        public async Task GetOrderAsync_ShouldReturnSuccessResult()
        {
            // Arrange
            var orderId = 123;
            var order = new Order { /* Initialize properties */ };

            _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, $"orders/{orderId}");

            // Act
            var result = await _veeqoOrdersClient.GetOrderAsync(orderId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(order, result.Data);
        }

        [Fact]
        public async Task ListOrdersAsync_ShouldReturnSuccessResult()
        {
            // Arrange
            var parameters = new GetOrdersParameters { /* Initialize properties */ };
            var orders = new List<Order> { /* Initialize list of orders */ };

            _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, parameters.GetUrl());

            // Act
            var result = await _veeqoOrdersClient.ListOrdersAsync(parameters);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(orders, result.Data);
        }

        [Fact]
        public async Task UpdateVeeqoOrderAsync_ShouldReturnSuccessResult()
        {
            // Arrange
            var veeqoOrderId = 123;
            var requestOrder = new RequestOrder { /* Initialize properties */ };
            var order = new Order { /* Initialize properties */ };

            _httpMessageHandlerMock.SetupRequest(HttpMethod.Put, $"orders/{veeqoOrderId}");

            // Act
            var result = await _veeqoOrdersClient.UpdateVeeqoOrderAsync(veeqoOrderId, requestOrder);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(order, result.Data);
        }
    }

    internal static class HttpMessageHandlerExtensions
    {
        public static void SetupRequest(this Mock<HttpMessageHandler> mockHandler, HttpMethod method, string requestUri)
        {
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == method &&
                        req.RequestUri == new Uri("https://api.veeqo.com/" + requestUri)),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("")
                });
        }

        public static void SetupRequest<T>(this Mock<HttpMessageHandler> mockHandler, HttpMethod method, string requestUri, T responseBody, HttpStatusCode statusCode)
        {
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == method &&
                        req.RequestUri == new Uri("https://api.veeqo.com/" + requestUri)),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(statusCode)
                {
                    Content = JsonContent.Create(responseBody)
                });
        }

        public static void ReturnsResponse(this Mock<HttpMessageHandler> mockHandler, HttpStatusCode statusCode)
        {
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(statusCode));
        }

        public static void ReturnsResponse<T>(this Mock<HttpMessageHandler> mockHandler, T responseBody, HttpStatusCode statusCode)
        {
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(statusCode)
                {
                    Content = JsonContent.Create(responseBody)
                });
        }
    }
}