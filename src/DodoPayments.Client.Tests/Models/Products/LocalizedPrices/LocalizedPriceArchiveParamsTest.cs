using System;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class LocalizedPriceArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LocalizedPriceArchiveParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
        };

        string expectedProductID = "pdt_R8AWMPiV8RyJElcCKvAID";
        string expectedID = "lcp_3aOOT7ebrzBOV41yL2V6s";

        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        LocalizedPriceArchiveParams parameters = new()
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/localized-prices/lcp_3aOOT7ebrzBOV41yL2V6s"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LocalizedPriceArchiveParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
        };

        LocalizedPriceArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
