using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUnarchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUnarchiveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductUnarchiveParams parameters = new() { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/unarchive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductUnarchiveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        ProductUnarchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
