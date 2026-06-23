using System;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class LocalizedPriceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LocalizedPriceListParams { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        string expectedProductID = "pdt_R8AWMPiV8RyJElcCKvAID";

        Assert.Equal(expectedProductID, parameters.ProductID);
    }

    [Fact]
    public void Url_Works()
    {
        LocalizedPriceListParams parameters = new() { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/localized-prices"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LocalizedPriceListParams { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        LocalizedPriceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
