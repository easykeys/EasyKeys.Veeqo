using Microsoft.Extensions.DependencyInjection;
using EasyKeys.Veeqo.Products;
using EasyKeys.Veeqo.Products.Models.Parameters;
using EasyKeys.Veeqo.Products.Models.Request;

namespace EasyKeys.Veeqo.IntegrationTests.Products;
public class VeeqoProductsClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoProductsClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [Theory]
    [InlineData(1)]
    public async Task List_Update_Create_Delete_ProductAsync(int pageSize)
    {
        // Arrange
        var veeqoProductsClient = sp.GetRequiredService<IVeeqoProductsClient>();

        // Act
        var result = await veeqoProductsClient.ListProductsAsync(new GetProductsParameters() { Page_Size = pageSize });

        // Assert
        Assert.True(result.Success);
        Assert.True(result.Data.Count > 0);

        var updateResult = await veeqoProductsClient.UpdateProductAsync(result.Data.First().Id, new RequestProduct() { Title = "new title" });

        Assert.True(updateResult.Success);

        var createdProduct = await veeqoProductsClient.CreateProductAsync(new RequestProduct()
        {
            Title = "title",
            Description = "description",
            Notes = "item.Notes",
            ProductVariantsAttributes = new List<RequestProductVariant>()
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
                        Depth =2m
                    },
                    WeightGrams = 2m * 28
                }
            },
            ImagesAttributes = new List<RequestProductImage>()
                {
                    new RequestProductImage()
                    {
                        Src = "item.ImgUrl"
                    }
                }
        });

        Assert.True(createdProduct.Success);

        var deleteResult = await veeqoProductsClient.DeleteProductAsync(createdProduct.Data.Id);

        Assert.True(deleteResult.Success);
    }

}