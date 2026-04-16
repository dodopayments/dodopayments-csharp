using System;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup.Details;

public class DetailDownloadCsvParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DetailDownloadCsvParams { PayoutID = "payout_id" };

        string expectedPayoutID = "payout_id";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
    }

    [Fact]
    public void Url_Works()
    {
        DetailDownloadCsvParams parameters = new() { PayoutID = "payout_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/payouts/payout_id/breakup/details/csv"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DetailDownloadCsvParams { PayoutID = "payout_id" };

        DetailDownloadCsvParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
