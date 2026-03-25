using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "id",
            BrandID = "brand_id",
            Description = "description",
            GroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
        };

        string expectedID = "id";
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        List<string> expectedGroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.GroupOrder);
        Assert.Equal(expectedGroupOrder.Count, parameters.GroupOrder.Count);
        for (int i = 0; i < expectedGroupOrder.Count; i++)
        {
            Assert.Equal(expectedGroupOrder[i], parameters.GroupOrder[i]);
        }
        Assert.Equal(expectedImageID, parameters.ImageID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionUpdateParams { ID = "id" };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.GroupOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("group_order"));
        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "id",

            BrandID = null,
            Description = null,
            GroupOrder = null,
            ImageID = null,
            Name = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.GroupOrder);
        Assert.True(parameters.RawBodyData.ContainsKey("group_order"));
        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/product-collections/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "id",
            BrandID = "brand_id",
            Description = "description",
            GroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
        };

        ProductCollectionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
