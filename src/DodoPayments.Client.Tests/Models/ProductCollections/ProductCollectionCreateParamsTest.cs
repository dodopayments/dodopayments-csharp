using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
        };

        List<ProductCollectionGroupDetails> expectedGroups =
        [
            new()
            {
                Products = [new() { ProductID = "product_id", Status = true }],
                GroupName = "group_name",
                Status = true,
            },
        ];
        string expectedName = "name";
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";

        Assert.Equal(expectedGroups.Count, parameters.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], parameters.Groups[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",

            BrandID = null,
            Description = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionCreateParams parameters = new()
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/product-collections"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
        };

        ProductCollectionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
