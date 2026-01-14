
````markdown
# Veeqo API Wrapper

## Overview

This repository contains a .NET wrapper for the [Veeqo API](https://developer.veeqo.com/docs). The wrapper simplifies interaction with Veeqo's various endpoints, allowing developers to easily integrate Veeqo functionalities into their applications.

## Features

- Simplified API interaction with Veeqo.
- Support for major Veeqo endpoints (Products, Orders, LineItems, Customers, etc.).
- Error handling and response validation.
- Customizable to fit different use cases.

## Installation

To install the Veeqo API Wrapper, you can add the package reference to your project:

```xml
<PackageReference Include="EasyKeys.Veeqo" Version="1.0.0" />
````

## Usage

Here's a quick example to get you started:

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.LineItems;
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
services.AddVeeqoLineItemsClient();

var serviceProvider = services.BuildServiceProvider();

var veeqoOrdersClient = serviceProvider.GetRequiredService<IVeeqoOrdersClient>();
var veeqoLineItemsClient = serviceProvider.GetRequiredService<IVeeqoLineItemsClient>();

// Orders
var result = await veeqoOrdersClient.ListOrdersAsync(new GetOrdersParameters() { Page_Size = 10 });
var order = await veeqoOrdersClient.GetOrderAsync(1);

// Line Items
var updatedLineItemNote = await veeqoLineItemsClient.UpdateLineItemNotesAsync(12345, "This is a note for the line item");
```

## Authentication

To use the Veeqo API, you need to obtain an API key from your Veeqo account. Once you have the key, configure the `VeeqoClientOptions` with your API key as shown in the example above.

## Endpoints

The wrapper supports the following Veeqo endpoints:

### Products

* `GetProductsAsync()`: Retrieve a list of products.
* `GetProductAsync(productId)`: Retrieve a single product by its ID.
* `CreateProductAsync(data)`: Create a new product.
* `UpdateProductAsync(productId, data)`: Update an existing product.
* `DeleteProductAsync(productId)`: Delete a product by its ID.

### Orders

* `ListOrdersAsync(parameters)`: Retrieve a list of orders.
* `GetOrderAsync(orderId)`: Retrieve a single order by its ID.
* `CreateVeeqoOrderAsync(order)`: Create a new order.
* `UpdateVeeqoOrderAsync(orderId, order)`: Update an existing order.
* `CreateOrderNotesAsync(orderId, text)`: Create a note for an order.

### Line Items

* `UpdateLineItemNotesAsync(lineItemId, note)`: Update notes for a specific line item.

## Models

### Request Models

Request models are used to structure the data sent to the Veeqo API when creating or updating resources. For example, `RequestOrder` is used when creating or updating an order. These models are located in the `Models/Request` folder.

### Response Models

Response models represent the structure of the data returned by the Veeqo API. For example, `Order` is used to represent the details of an order returned by the API. These models are located in the `Models/Response` folder.

### Parameters Models

Parameter models are used to filter and paginate the results when retrieving data from the API. For example, `GetOrdersParameters` allows you to specify various criteria such as date range, status, and pagination options to refine the results returned by the API. These models are located in the `Models/Parameters` folder.


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

If you have any questions or suggestions, please feel free to open an issue or contact us directly.