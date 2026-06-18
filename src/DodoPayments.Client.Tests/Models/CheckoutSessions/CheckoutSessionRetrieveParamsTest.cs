using System;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckoutSessionRetrieveParams { ID = "cks_n010SZaY4NXc7F1ck3Tq1" };

        string expectedID = "cks_n010SZaY4NXc7F1ck3Tq1";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckoutSessionRetrieveParams parameters = new() { ID = "cks_n010SZaY4NXc7F1ck3Tq1" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/checkouts/cks_n010SZaY4NXc7F1ck3Tq1"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckoutSessionRetrieveParams { ID = "cks_n010SZaY4NXc7F1ck3Tq1" };

        CheckoutSessionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
