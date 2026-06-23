using System;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class LocalizedPriceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LocalizedPriceUpdateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
            Amount = 0,
        };

        string expectedProductID = "pdt_R8AWMPiV8RyJElcCKvAID";
        string expectedID = "lcp_3aOOT7ebrzBOV41yL2V6s";
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LocalizedPriceUpdateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LocalizedPriceUpdateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",

            Amount = null,
        };

        Assert.Null(parameters.Amount);
        Assert.True(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void Url_Works()
    {
        LocalizedPriceUpdateParams parameters = new()
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
        var parameters = new LocalizedPriceUpdateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ID = "lcp_3aOOT7ebrzBOV41yL2V6s",
            Amount = 0,
        };

        LocalizedPriceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
