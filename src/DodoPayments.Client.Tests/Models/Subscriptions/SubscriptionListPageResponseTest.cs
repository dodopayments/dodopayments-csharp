using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Items =
            [
                new()
                {
                    Billing = new()
                    {
                        City = "city",
                        Country = CountryCode.Af,
                        State = "state",
                        Street = "street",
                        Zipcode = "zipcode",
                    },
                    CancelAtNextBillingDate = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Customer = new()
                    {
                        CustomerID = "customer_id",
                        Email = "email",
                        Name = "name",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PhoneNumber = "phone_number",
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnDemand = true,
                    PaymentFrequencyCount = 0,
                    PaymentFrequencyInterval = TimeInterval.Day,
                    PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    RecurringPreTaxAmount = 0,
                    Status = SubscriptionStatus.Pending,
                    SubscriptionID = "subscription_id",
                    SubscriptionPeriodCount = 0,
                    SubscriptionPeriodInterval = TimeInterval.Day,
                    TaxInclusive = true,
                    TrialPeriodDays = 0,
                    CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountCyclesRemaining = 0,
                    DiscountID = "discount_id",
                    PaymentMethodID = "payment_method_id",
                    TaxID = "tax_id",
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                Billing = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Billing = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnDemand = true,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        Payments::BillingAddress expectedBilling = new()
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedOnDemand = true;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, TimeInterval> expectedPaymentFrequencyInterval = TimeInterval.Day;
        DateTimeOffset expectedPreviousBillingDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedRecurringPreTaxAmount = 0;
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.Pending;
        string expectedSubscriptionID = "subscription_id";
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, TimeInterval> expectedSubscriptionPeriodInterval = TimeInterval.Day;
        bool expectedTaxInclusive = true;
        int expectedTrialPeriodDays = 0;
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        string expectedPaymentMethodID = "payment_method_id";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, model.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedNextBillingDate, model.NextBillingDate);
        Assert.Equal(expectedOnDemand, model.OnDemand);
        Assert.Equal(expectedPaymentFrequencyCount, model.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, model.PaymentFrequencyInterval);
        Assert.Equal(expectedPreviousBillingDate, model.PreviousBillingDate);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedRecurringPreTaxAmount, model.RecurringPreTaxAmount);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedSubscriptionPeriodCount, model.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, model.SubscriptionPeriodInterval);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, model.TrialPeriodDays);
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
        Assert.Equal(expectedDiscountCyclesRemaining, model.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedTaxID, model.TaxID);
    }
}
