using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Orders.Models.Parameters;
using EasyKeys.Veeqo.Orders.Models.Response;
using Microsoft.Extensions.DependencyInjection;

namespace EasyKeys.Veeqo.IntegrationTests.Orders;

public class VeeqoOrdersClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoOrdersClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [Theory]
    [InlineData(1)]
    public async Task List_Update_Create_AddOrderNote_OnOrdersAsync(int pageSize)
    {
        // Arrange
        var veeqoOrdersClient = sp.GetRequiredService<IVeeqoOrdersClient>();

        // Act
        var result = await veeqoOrdersClient.ListOrdersAsync(new GetOrdersParameters() { Page_Size = pageSize});

        // veeqo dev doesnt return a list of orders..

        var order = await veeqoOrdersClient.GetOrderAsync(1);

        Assert.True(order.Success);

        var newOrder = new RequestOrder
        {
            ChannelId = 45465,
            Customer = new Customer
            {
                Mobile = "1234567890",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                BillingAddress = new Address
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address1 = "123 Main St",
                    City = "New York",
                    State = "NY",
                    Zip = "10001",
                    Country = "USA"
                }
            },
            DeliverTo = new Address
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "123 Main St",
                City = "New York",
                State = "NY",
                Zip = "10001",
                Country = "USA"
            },
            DueDate = "31/01/2018",
            Number = "rdr1236",
            SendNotificationEmail = true,
            LineItems = new List<LineItem>
            {
                new LineItem
                {
                    PricePerUnit = 75.000m,
                    TaxlessDiscountPerUnit =4m,
                    Quantity =1,
                    TaxRate = 0.2m,
                    SellableId = 13847534,
                    AdditionalOptions = "This thing is a thing"
                },
                new LineItem
                {
                    PricePerUnit = 150.000m,
                    TaxlessDiscountPerUnit = 30.00m,
                    Quantity = 1,
                    TaxRate = 0.2m,
                    SellableId = 14358568,
                    AdditionalOptions = "This thing is also a thing"
                },
                new LineItem
                {
                    PricePerUnit = 1250.000m,
                    TaxlessDiscountPerUnit = 30.00m,
                    Quantity = 1,
                    TaxRate = 0.2m,
                    SellableId = 14358568,
                    AdditionalOptions = "This thing is also a thing"
                }
            },
            AdditionalOrderLevelTaxlessDiscount = "19.50",
            DeliveryMethodId = 171784,
            DeliveryCost = 2.00m,
            TotalTax = 35.54m,
            TotalDiscounts = 49.5m,
            Payment = new Payment
            {
                PaymentType = "paypal",
                ReferenceNumber = "PPP1234"
            },
            CustomerNote = new CustomerNote
            {
                Text = "Please tell Sam to look after this puppy. --This is a customer note--"
            },
            EmployeeNotes = new List<EmployeeNote>
            {
                new EmployeeNote
                {
                    Text = "Package contains a dog. Use suitable box. --This is an internal note--"
                }
            }
        };

        var createdOrder = await veeqoOrdersClient.CreateOrderAsync(newOrder);

        Assert.True(createdOrder.Success);

        var updatedOrder = await veeqoOrdersClient.UpdateOrderAsync(1, new RequestOrder { EmployeeNotes = new List<EmployeeNote> { new EmployeeNote { Text = "This is an updated note" } } });

        Assert.True(updatedOrder.Success);

        var deletedOrder = await veeqoOrdersClient.CreateOrderNotesAsync(1,"test order notes");

        Assert.True(deletedOrder.Success);
    }


}