using System;
using DodoPayments.Client.Models.ProductCollections.Groups.Items;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups.Items;

public class ItemDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemDeleteParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ItemID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "id";
        string expectedGroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedItemID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGroupID, parameters.GroupID);
        Assert.Equal(expectedItemID, parameters.ItemID);
    }

    [Fact]
    public void Url_Works()
    {
        ItemDeleteParams parameters = new()
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ItemID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/product-collections/id/groups/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/items/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemDeleteParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ItemID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ItemDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
