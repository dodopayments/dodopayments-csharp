using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

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
                        Country = CountryCode.Af,
                        City = "city",
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

        List<SubscriptionListResponse> expectedItems =
        [
            new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Items =
            [
                new()
                {
                    Billing = new()
                    {
                        Country = CountryCode.Af,
                        City = "city",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Items =
            [
                new()
                {
                    Billing = new()
                    {
                        Country = CountryCode.Af,
                        City = "city",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SubscriptionListResponse> expectedItems =
        [
            new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
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

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Items =
            [
                new()
                {
                    Billing = new()
                    {
                        Country = CountryCode.Af,
                        City = "city",
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

        model.Validate();
    }
}
