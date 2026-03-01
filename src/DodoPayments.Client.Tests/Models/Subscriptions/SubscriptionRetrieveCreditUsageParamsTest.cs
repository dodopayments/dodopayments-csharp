using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveCreditUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveCreditUsageParams
        {
            SubscriptionID = "subscription_id",
        };

        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveCreditUsageParams parameters = new()
        {
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://live.dodopayments.com/subscriptions/subscription_id/credit-usage"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveCreditUsageParams
        {
            SubscriptionID = "subscription_id",
        };

        SubscriptionRetrieveCreditUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
