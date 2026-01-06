using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductListParams
        {
            Archived = true,
            BrandID = "brand_id",
            PageNumber = 0,
            PageSize = 0,
            Recurring = true,
        };

        bool expectedArchived = true;
        string expectedBrandID = "brand_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        bool expectedRecurring = true;

        Assert.Equal(expectedArchived, parameters.Archived);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedRecurring, parameters.Recurring);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductListParams { };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Recurring);
        Assert.False(parameters.RawQueryData.ContainsKey("recurring"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductListParams
        {
            // Null should be interpreted as omitted for these properties
            Archived = null,
            BrandID = null,
            PageNumber = null,
            PageSize = null,
            Recurring = null,
        };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Recurring);
        Assert.False(parameters.RawQueryData.ContainsKey("recurring"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductListParams parameters = new()
        {
            Archived = true,
            BrandID = "brand_id",
            PageNumber = 0,
            PageSize = 0,
            Recurring = true,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/products?archived=true&brand_id=brand_id&page_number=0&page_size=0&recurring=true"
            ),
            url
        );
    }
}
