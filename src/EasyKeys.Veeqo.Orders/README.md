# Veeqo API Wrapper

## Overview

This repository contains a .NET wrapper for the [Veeqo API](https://developer.veeqo.com/docs). The wrapper simplifies interaction with Veeqo's various endpoints, allowing developers to easily integrate Veeqo functionalities into their applications.

## Features

- Simplified API interaction with Veeqo.
- Support for major Veeqo endpoints (Products, Orders, Customers, etc.).
- Error handling and response validation.
- Customizable to fit different use cases.

## Installation

To install the Veeqo API Wrapper, you can add the package reference to your project:

```xml
<PackageReference Include="EasyKeys.Veeqo" Version="1.0.0" />
```

## Usage

Here's a quick example to get you started:

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Orders.Models.Parameters;

// Configure your services
var services = new ServiceCollection();

var dic = new Dictionary<string, string>
{
    { "VeeqoClientOptions:BaseUrl", "https://private-anon-4c0cd8afa3-veeqo.apiary-proxy.com/" },
    { "VeeqoClientOptions:ApiKey" , "your-api-key" },
};

var configBuilder = new ConfigurationBuilder().AddInMemoryCollection(dic);
var config = configBuilder.Build();

services.AddSingleton<IConfiguration>(config);
services.AddVeeqoOrdersClient();

var serviceProvider = services.BuildServiceProvider();
var veeqoOrdersClient = sp.GetRequiredService<IVeeqoOrdersClient>();

// Act
var result = await veeqoOrdersClient.ListOrdersAsync(new GetOrdersParameters() { Page_Size = pageSize});

// veeqo mock server doesnt return a list of orders..

var order = await veeqoOrdersClient.GetOrderAsync(1);

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

var updatedOrder = await veeqoOrdersClient.UpdateOrderAsync(1, new RequestOrder { EmployeeNotes = new List<EmployeeNote> { new EmployeeNote { Text = "This is an updated note" } } });

var deletedOrder = await veeqoOrdersClient.CreateOrderNotesAsync(1,"test order notes");

```

## Authentication

To use the Veeqo API, you need to obtain an API key from your Veeqo account. Once you have the key, configure the `VeeqoClientOptions` with your API key as shown in the example above.

## Endpoints

The wrapper supports the following Veeqo endpoints:

### Products

- `GetProductsAsync()`: Retrieve a list of products.
- `GetProductAsync(productId)`: Retrieve a single product by its ID.
- `CreateProductAsync(data)`: Create a new product.
- `UpdateProductAsync(productId, data)`: Update an existing product.
- `DeleteProductAsync(productId)`: Delete a product by its ID.

### Orders

- `ListOrdersAsync(parameters)`: Retrieve a list of orders.
- `GetOrderAsync(orderId)`: Retrieve a single order by its ID.
- `CreateVeeqoOrderAsync(order)`: Create a new order.
- `UpdateVeeqoOrderAsync(orderId, order)`: Update an existing order.
- `CreateOrderNotesAsync(orderId, text)`: Create a note for an order.

## Models

### Request Models

Request models are used to structure the data sent to the Veeqo API when creating or updating resources. For example, `RequestOrder` is used when creating or updating an order. These models are located in the `Models/Request` folder.

### Response Models

Response models represent the structure of the data returned by the Veeqo API. For example, `Order` is used to represent the details of an order returned by the API. These models are located in the `Models/Response` folder.

### Parameters Models

Parameter models are used to filter and paginate the results when retrieving data from the API. For example, `GetOrdersParameters` allows you to specify various criteria such as date range, status, and pagination options to refine the results returned by the API. These models are located in the `Models/Parameters` folder.

## Contributing

Contributions are welcome! Please fork this repository and submit a pull request for any enhancements or bug fixes.

### Steps to Contribute

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

If you have any questions or suggestions, please feel free to open an issue or contact us directly.