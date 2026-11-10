using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveUpcomingInvoiceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveUpcomingInvoiceParams
        {
            SubscriptionID = "subscription_id",
        };

        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveUpcomingInvoiceParams parameters = new()
        {
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/subscription_id/upcoming-invoice"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveUpcomingInvoiceParams
        {
            SubscriptionID = "subscription_id",
        };

        SubscriptionRetrieveUpcomingInvoiceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
