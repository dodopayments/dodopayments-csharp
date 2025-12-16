using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdatePaymentMethodResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        string expectedClientSecret = "client_secret";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentID = "payment_id";
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
    }
}
