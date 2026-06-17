using System;
using DodoPayments.Client.Models.Payouts.Breakup;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup;

public class BreakupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BreakupRetrieveParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        string expectedPayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
    }

    [Fact]
    public void Url_Works()
    {
        BreakupRetrieveParams parameters = new() { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/payouts/pyt_zFTrrn4sk3x3y2vjDBW3T/breakup"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BreakupRetrieveParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        BreakupRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
