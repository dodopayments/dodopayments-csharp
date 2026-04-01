using System;
using DodoPayments.Client.Models.Payouts.Breakup;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup;

public class BreakupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BreakupRetrieveParams { PayoutID = "payout_id" };

        string expectedPayoutID = "payout_id";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
    }

    [Fact]
    public void Url_Works()
    {
        BreakupRetrieveParams parameters = new() { PayoutID = "payout_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/payouts/payout_id/breakup"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BreakupRetrieveParams { PayoutID = "payout_id" };

        BreakupRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
