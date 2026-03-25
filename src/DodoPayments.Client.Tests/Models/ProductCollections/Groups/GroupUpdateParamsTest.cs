using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class GroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupUpdateParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            GroupName = "group_name",
            ProductOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Status = true,
        };

        string expectedID = "id";
        string expectedGroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedGroupName = "group_name";
        List<string> expectedProductOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        bool expectedStatus = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGroupID, parameters.GroupID);
        Assert.Equal(expectedGroupName, parameters.GroupName);
        Assert.NotNull(parameters.ProductOrder);
        Assert.Equal(expectedProductOrder.Count, parameters.ProductOrder.Count);
        for (int i = 0; i < expectedProductOrder.Count; i++)
        {
            Assert.Equal(expectedProductOrder[i], parameters.ProductOrder[i]);
        }
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupUpdateParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.GroupName);
        Assert.False(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.ProductOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("product_order"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GroupUpdateParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            GroupName = null,
            ProductOrder = null,
            Status = null,
        };

        Assert.Null(parameters.GroupName);
        Assert.True(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.ProductOrder);
        Assert.True(parameters.RawBodyData.ContainsKey("product_order"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        GroupUpdateParams parameters = new()
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/product-collections/id/groups/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupUpdateParams
        {
            ID = "id",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            GroupName = "group_name",
            ProductOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Status = true,
        };

        GroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
