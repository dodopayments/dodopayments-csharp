using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountListParams
        {
            Active = true,
            Code = "code",
            DiscountType = DiscountType.Percentage,
            PageNumber = 0,
            PageSize = 0,
            ProductID = "product_id",
        };

        bool expectedActive = true;
        string expectedCode = "code";
        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Percentage;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        string expectedProductID = "product_id";

        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedDiscountType, parameters.DiscountType);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedProductID, parameters.ProductID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DiscountListParams { };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawQueryData.ContainsKey("code"));
        Assert.Null(parameters.DiscountType);
        Assert.False(parameters.RawQueryData.ContainsKey("discount_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ProductID);
        Assert.False(parameters.RawQueryData.ContainsKey("product_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DiscountListParams
        {
            // Null should be interpreted as omitted for these properties
            Active = null,
            Code = null,
            DiscountType = null,
            PageNumber = null,
            PageSize = null,
            ProductID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawQueryData.ContainsKey("code"));
        Assert.Null(parameters.DiscountType);
        Assert.False(parameters.RawQueryData.ContainsKey("discount_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ProductID);
        Assert.False(parameters.RawQueryData.ContainsKey("product_id"));
    }

    [Fact]
    public void Url_Works()
    {
        DiscountListParams parameters = new()
        {
            Active = true,
            Code = "code",
            DiscountType = DiscountType.Percentage,
            PageNumber = 0,
            PageSize = 0,
            ProductID = "product_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/discounts?active=true&code=code&discount_type=percentage&page_number=0&page_size=0&product_id=product_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DiscountListParams
        {
            Active = true,
            Code = "code",
            DiscountType = DiscountType.Percentage,
            PageNumber = 0,
            PageSize = 0,
            ProductID = "product_id",
        };

        DiscountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
