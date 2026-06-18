using System;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RefundRetrieveParams { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        string expectedRefundID = "ref_F0gZetLvTxxBrMU2CZcmy";

        Assert.Equal(expectedRefundID, parameters.RefundID);
    }

    [Fact]
    public void Url_Works()
    {
        RefundRetrieveParams parameters = new() { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/refunds/ref_F0gZetLvTxxBrMU2CZcmy"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RefundRetrieveParams { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        RefundRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
