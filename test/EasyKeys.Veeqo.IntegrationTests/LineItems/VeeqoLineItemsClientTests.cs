using EasyKeys.Veeqo.LineItems;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKeys.Veeqo.IntegrationTests.LineItems;

public class VeeqoLineItemsClientTests
{
    private readonly IServiceProvider sp;

    public VeeqoLineItemsClientTests()
    {
        sp = IntegrationTestBuilder.BuildDiContainer();
    }


    [RunnableInDebugOnly]
    public async Task Update_Line_Item_Notes_Async()
    {
        var veeqoLineItemsClient = sp.GetRequiredService<IVeeqoLineItemsClient>();

        var ordersTag = await veeqoLineItemsClient.UpdateLineItemNotesAsync(1288248613, "test notes");

        Assert.True(ordersTag.Success);

    }


}