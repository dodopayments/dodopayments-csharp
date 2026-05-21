using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class GroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string expectedID = "id";
        List<GroupProduct> expectedProducts = [new() { ProductID = "product_id", Status = true }];
        string expectedGroupName = "group_name";
        bool expectedStatus = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
        Assert.Equal(expectedGroupName, parameters.GroupName);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        Assert.Null(parameters.GroupName);
        Assert.False(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],

            GroupName = null,
            Status = null,
        };

        Assert.Null(parameters.GroupName);
        Assert.True(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        GroupCreateParams parameters = new()
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/product-collections/id/groups"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        GroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
