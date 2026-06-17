using System;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionDeleteParams { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        string expectedID = "pdc_8BWv0hojwUH7iCDabr0NI";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionDeleteParams parameters = new() { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/pdc_8BWv0hojwUH7iCDabr0NI"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionDeleteParams { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        ProductCollectionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
