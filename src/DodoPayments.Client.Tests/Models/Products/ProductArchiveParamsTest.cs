using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductArchiveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductArchiveParams parameters = new() { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductArchiveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        ProductArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
