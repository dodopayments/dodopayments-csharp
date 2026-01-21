using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponse
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
            ProductName = "product_name",
            TaxID = "tax_id",
        };

        BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        CustomerLimitedDetails expectedCustomer = new()
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
        string expectedProductName = "product_name";
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
        Assert.Equal(expectedProductName, model.ProductName);
        Assert.Equal(expectedTaxID, model.TaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponse
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
            ProductName = "product_name",
            TaxID = "tax_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponse
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
            ProductName = "product_name",
            TaxID = "tax_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        CustomerLimitedDetails expectedCustomer = new()
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
        string expectedProductName = "product_name";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, deserialized.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedNextBillingDate, deserialized.NextBillingDate);
        Assert.Equal(expectedOnDemand, deserialized.OnDemand);
        Assert.Equal(expectedPaymentFrequencyCount, deserialized.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, deserialized.PaymentFrequencyInterval);
        Assert.Equal(expectedPreviousBillingDate, deserialized.PreviousBillingDate);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedRecurringPreTaxAmount, deserialized.RecurringPreTaxAmount);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedSubscriptionPeriodCount, deserialized.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, deserialized.SubscriptionPeriodInterval);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, deserialized.TrialPeriodDays);
        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
        Assert.Equal(expectedDiscountCyclesRemaining, deserialized.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedProductName, deserialized.ProductName);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponse
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
            ProductName = "product_name",
            TaxID = "tax_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponse
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
        };

        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.False(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.ProductName);
        Assert.False(model.RawData.ContainsKey("product_name"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionListResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionListResponse
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

            CancelledAt = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            PaymentMethodID = null,
            ProductName = null,
            TaxID = null,
        };

        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.True(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.PaymentMethodID);
        Assert.True(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.ProductName);
        Assert.True(model.RawData.ContainsKey("product_name"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionListResponse
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

            CancelledAt = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            PaymentMethodID = null,
            ProductName = null,
            TaxID = null,
        };

        model.Validate();
    }
}
