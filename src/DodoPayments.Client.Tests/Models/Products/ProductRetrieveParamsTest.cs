using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductRetrieveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductRetrieveParams parameters = new() { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

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
        var parameters = new ProductRetrieveParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        ProductRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
