using System;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionListParams
        {
            Archived = true,
            BrandID = "brand_id",
            PageNumber = 0,
            PageSize = 0,
        };

        bool expectedArchived = true;
        string expectedBrandID = "brand_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedArchived, parameters.Archived);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionListParams { };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductCollectionListParams
        {
            // Null should be interpreted as omitted for these properties
            Archived = null,
            BrandID = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionListParams parameters = new()
        {
            Archived = true,
            BrandID = "brand_id",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections?archived=true&brand_id=brand_id&page_number=0&page_size=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionListParams
        {
            Archived = true,
            BrandID = "brand_id",
            PageNumber = 0,
            PageSize = 0,
        };

        ProductCollectionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
