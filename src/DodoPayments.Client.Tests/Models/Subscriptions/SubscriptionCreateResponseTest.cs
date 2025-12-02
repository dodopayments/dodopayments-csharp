using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
        };

        List<AddonCartResponseItem> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        int expectedRecurringPreTaxAmount = 0;
        string expectedSubscriptionID = "subscription_id";
        string expectedClientSecret = "client_secret";
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRecurringPreTaxAmount, model.RecurringPreTaxAmount);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
    }
}
