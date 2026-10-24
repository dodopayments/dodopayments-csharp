using System;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionRetrieveParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            Locale = "locale",
        };

        string expectedID = "pdc_8BWv0hojwUH7iCDabr0NI";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionRetrieveParams { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductCollectionRetrieveParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionRetrieveParams parameters = new()
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/pdc_8BWv0hojwUH7iCDabr0NI?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionRetrieveParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            Locale = "locale",
        };

        ProductCollectionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
