# Veeqo API Wrapper

## Overview

This repository contains a .NET wrapper for the [Veeqo API](https://developer.veeqo.com/docs). The wrapper simplifies interaction with Veeqo's various endpoints, allowing developers to easily integrate Veeqo functionalities into their applications.

## Features

- Simplified API interaction with Veeqo.
- Support for major Veeqo endpoints (Products, Orders, Customers, etc.).
- Error handling and response validation.
- Customizable to fit different use cases.

## Installation

To install the Veeqo API Wrapper, add the package reference to your project:

```xml
<PackageReference Include="EasyKeys.Veeqo" Version="1.0.0" />
```

## Usage

### Setting Up

Here's a quick example to get you started:

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyKeys.Veeqo.Orders;
using EasyKeys.Veeqo.Orders.Models.Parameters;

// Configure your services
var services = new ServiceCollection();

var configurationData = new Dictionary<string, string>
{
    { "VeeqoClientOptions:BaseUrl", "https://private-anon-4c0cd8afa3-veeqo.apiary-proxy.com/" },
    { "VeeqoClientOptions:ApiKey" , "your-api-key" },
};

var configBuilder = new ConfigurationBuilder().AddInMemoryCollection(configurationData);
var config = configBuilder.Build();

services.AddSingleton<IConfiguration>(config);
services.AddVeeqoOrdersClient();
services.AddVeeqoProductsClient();
services.AddVeeqoStockEntriesClient();
services.AddVeeqoBulkTaggingClient();

var serviceProvider = services.BuildServiceProvider();
var veeqoOrdersClient = serviceProvider.GetRequiredService<IVeeqoOrdersClient>();
```

### Listing Orders

```csharp
// Define parameters
var parameters = new GetOrdersParameters
{
    Query = "query",
    Status = "status",
    Updated_At_Min = DateTime.Now.AddMonths(-1),
    Since_Id = 100,
    Created_At_Min = DateTime.Now.AddMonths(-6),
    Page = 1,
    Page_Size = 50,
    Tags = "tag1,tag2",
    Allocated_At = 5,
};

// List orders
var orders = await veeqoOrdersClient.ListOrdersAsync(parameters);
foreach (var order in orders.Result)
{
    Console.WriteLine(order.Number);
}
```

### Managing Stock Entries

```csharp
var veeqoStockEntriesClient = serviceProvider.GetRequiredService<IVeeqoStockEntriesClient>();

var stockEntryId = 123;
var warehouseId = 456;

// Show stock entry
var stockEntryResult = await veeqoStockEntriesClient.ShowStockEntryAsync(stockEntryId, warehouseId);

// Update stock entry
var newStockEntry = new RequestStockEntry
{
    Infinite = true,
    StockLevel = 188
};

var updateStockEntryResult = await veeqoStockEntriesClient.UpdateStockEntryAsync(stockEntryId, warehouseId, newStockEntry);
```

### Managing Products

```csharp
var veeqoProductsClient = serviceProvider.GetRequiredService<IVeeqoProductsClient>();

// List products
var productsResult = await veeqoProductsClient.ListProductsAsync(new GetProductsParameters() { Page_Size = 50 });

// Update product
var updateProductResult = await veeqoProductsClient.UpdateProductAsync(productsResult.Data.First().Id, new RequestProduct() { Title = "new title" });

// Create a new product
var createdProduct = await veeqoProductsClient.CreateProductAsync(new RequestProduct()
{
    Title = "title",
    Description = "description",
    Notes = "item.Notes",
    ProductVariantsAttributes = new List<RequestProductVariant>
    {
        new RequestProductVariant
        {
            Title = "item.SubTitle",
            SkuCode = "item.Sku",
            Price = 2m,
            MeasurementAttributes = new MeasurementAttributes
            {
                Height = 2m,
                Width = 2m,
                Depth = 2m
            },
            WeightGrams = 56 // 2m * 28
        }
    },
    ImagesAttributes = new List<RequestProductImage>
    {
        new RequestProductImage
        {
            Src = "item.ImgUrl"
        }
    }
});

// Delete product
var deleteProductResult = await veeqoProductsClient.DeleteProductAsync(createdProduct.Data.Id);
```

### Bulk Tagging

```csharp
var veeqoBulkTaggingClient = serviceProvider.GetRequiredService<IVeeqoBulkTaggingClient>();

// Bulk tag orders
var ordersTag = await veeqoBulkTaggingClient.BulkTagOrdersAsync(new List<int> { 1, 2, 3 }, new List<int> { 1, 3, 4 });

// Bulk tag products
var productsTag = await veeqoBulkTaggingClient.BulkTagProductsAsync(new List<int> { 1, 2, 3 }, new List<int> { 1, 3, 4 });
```

## Authentication

To use the Veeqo API, you need to obtain an API key from your Veeqo account. Once you have the key, configure the `VeeqoClientOptions` with your API key as shown in the example above.

## Models

### Request Models

Request models are used to structure the data sent to the Veeqo API when creating or updating resources. For example, `RequestOrder` is used when creating or updating an order. These models are located in the `Models/Request` folder.

### Response Models

Response models represent the structure of the data returned by the Veeqo API. For example, `Order` is used to represent the details of an order returned by the API. These models are located in the `Models/Response` folder.

### Parameter Models

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