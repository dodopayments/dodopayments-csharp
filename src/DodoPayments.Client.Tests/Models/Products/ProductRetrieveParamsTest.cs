using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductRetrieveParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Locale = "locale",
        };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductRetrieveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductRetrieveParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductRetrieveParams parameters = new()
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductRetrieveParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Locale = "locale",
        };

        ProductRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
