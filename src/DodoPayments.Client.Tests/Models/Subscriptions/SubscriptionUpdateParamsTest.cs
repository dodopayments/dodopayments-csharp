using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class DisableOnDemandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, model.NextBillingDate);
    }
}
