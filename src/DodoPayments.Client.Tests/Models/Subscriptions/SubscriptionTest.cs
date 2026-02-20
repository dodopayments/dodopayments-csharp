using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        List<AddonCartResponseItem> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SubscriptionCreditEntitlementCart> expectedCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CreditsAmount = "credits_amount",
                OverageBalance = "overage_balance",
                OverageChargeAtBilling = true,
                OverageEnabled = true,
                ProductID = "product_id",
                RemainingBalance = "remaining_balance",
                RolloverEnabled = true,
                Unit = "unit",
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageLimit = "overage_limit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
            },
        ];
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
        List<MeterCreditEntitlementCart> expectedMeterCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                MeterID = "meter_id",
                MeterName = "meter_name",
                MeterUnitsPerCredit = "meter_units_per_credit",
                ProductID = "product_id",
            },
        ];
        List<Meter> expectedMeters =
        [
            new()
            {
                Currency = Currency.Aed,
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                MeterID = "meter_id",
                Name = "name",
                PricePerUnit = "10.50",
                Description = "description",
            },
        ];
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
        List<CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, model.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementCart.Count, model.CreditEntitlementCart.Count);
        for (int i = 0; i < expectedCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlementCart[i], model.CreditEntitlementCart[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(
            expectedMeterCreditEntitlementCart.Count,
            model.MeterCreditEntitlementCart.Count
        );
        for (int i = 0; i < expectedMeterCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(
                expectedMeterCreditEntitlementCart[i],
                model.MeterCreditEntitlementCart[i]
            );
        }
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
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
        Assert.NotNull(model.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, model.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], model.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, model.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedTaxID, model.TaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AddonCartResponseItem> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SubscriptionCreditEntitlementCart> expectedCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CreditsAmount = "credits_amount",
                OverageBalance = "overage_balance",
                OverageChargeAtBilling = true,
                OverageEnabled = true,
                ProductID = "product_id",
                RemainingBalance = "remaining_balance",
                RolloverEnabled = true,
                Unit = "unit",
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageLimit = "overage_limit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
            },
        ];
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
        List<MeterCreditEntitlementCart> expectedMeterCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                MeterID = "meter_id",
                MeterName = "meter_name",
                MeterUnitsPerCredit = "meter_units_per_credit",
                ProductID = "product_id",
            },
        ];
        List<Meter> expectedMeters =
        [
            new()
            {
                Currency = Currency.Aed,
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                MeterID = "meter_id",
                Name = "name",
                PricePerUnit = "10.50",
                Description = "description",
            },
        ];
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
        List<CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, deserialized.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementCart.Count, deserialized.CreditEntitlementCart.Count);
        for (int i = 0; i < expectedCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlementCart[i], deserialized.CreditEntitlementCart[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(
            expectedMeterCreditEntitlementCart.Count,
            deserialized.MeterCreditEntitlementCart.Count
        );
        for (int i = 0; i < expectedMeterCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(
                expectedMeterCreditEntitlementCart[i],
                deserialized.MeterCreditEntitlementCart[i]
            );
        }
        Assert.Equal(expectedMeters.Count, deserialized.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], deserialized.Meters[i]);
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
        Assert.NotNull(deserialized.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, deserialized.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], deserialized.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, deserialized.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
        Assert.Null(model.CustomFieldResponses);
        Assert.False(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.False(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CustomFieldResponses);
        Assert.True(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.True(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentMethodID);
        Assert.True(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditsAmount = "credits_amount",
                    OverageBalance = "overage_balance",
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    ProductID = "product_id",
                    RemainingBalance = "remaining_balance",
                    RolloverEnabled = true,
                    Unit = "unit",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
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
            MeterCreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    MeterID = "meter_id",
                    MeterName = "meter_name",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    ProductID = "product_id",
                },
            ],
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
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
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionCreditEntitlementCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditsAmount = "credits_amount";
        string expectedOverageBalance = "overage_balance";
        bool expectedOverageChargeAtBilling = true;
        bool expectedOverageEnabled = true;
        string expectedProductID = "product_id";
        string expectedRemainingBalance = "remaining_balance";
        bool expectedRolloverEnabled = true;
        string expectedUnit = "unit";
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        string expectedOverageLimit = "overage_limit";
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, model.CreditEntitlementName);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
        Assert.Equal(expectedOverageBalance, model.OverageBalance);
        Assert.Equal(expectedOverageChargeAtBilling, model.OverageChargeAtBilling);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedRemainingBalance, model.RemainingBalance);
        Assert.Equal(expectedRolloverEnabled, model.RolloverEnabled);
        Assert.Equal(expectedUnit, model.Unit);
        Assert.Equal(expectedExpiresAfterDays, model.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, model.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, model.MaxRolloverCount);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedRolloverPercentage, model.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, model.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, model.RolloverTimeframeInterval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreditEntitlementCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreditEntitlementCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditsAmount = "credits_amount";
        string expectedOverageBalance = "overage_balance";
        bool expectedOverageChargeAtBilling = true;
        bool expectedOverageEnabled = true;
        string expectedProductID = "product_id";
        string expectedRemainingBalance = "remaining_balance";
        bool expectedRolloverEnabled = true;
        string expectedUnit = "unit";
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        string expectedOverageLimit = "overage_limit";
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, deserialized.CreditEntitlementName);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
        Assert.Equal(expectedOverageBalance, deserialized.OverageBalance);
        Assert.Equal(expectedOverageChargeAtBilling, deserialized.OverageChargeAtBilling);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedRemainingBalance, deserialized.RemainingBalance);
        Assert.Equal(expectedRolloverEnabled, deserialized.RolloverEnabled);
        Assert.Equal(expectedUnit, deserialized.Unit);
        Assert.Equal(expectedExpiresAfterDays, deserialized.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, deserialized.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, deserialized.MaxRolloverCount);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedRolloverPercentage, deserialized.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, deserialized.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, deserialized.RolloverTimeframeInterval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
        };

        Assert.Null(model.ExpiresAfterDays);
        Assert.False(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.False(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.False(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RolloverPercentage);
        Assert.False(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",

            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageLimit = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
        };

        Assert.Null(model.ExpiresAfterDays);
        Assert.True(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.True(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.True(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RolloverPercentage);
        Assert.True(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",

            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageLimit = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditsAmount = "credits_amount",
            OverageBalance = "overage_balance",
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            ProductID = "product_id",
            RemainingBalance = "remaining_balance",
            RolloverEnabled = true,
            Unit = "unit",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        SubscriptionCreditEntitlementCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MeterCreditEntitlementCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedMeterID = "meter_id";
        string expectedMeterName = "meter_name";
        string expectedMeterUnitsPerCredit = "meter_units_per_credit";
        string expectedProductID = "product_id";

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedMeterID, model.MeterID);
        Assert.Equal(expectedMeterName, model.MeterName);
        Assert.Equal(expectedMeterUnitsPerCredit, model.MeterUnitsPerCredit);
        Assert.Equal(expectedProductID, model.ProductID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCreditEntitlementCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCreditEntitlementCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedMeterID = "meter_id";
        string expectedMeterName = "meter_name";
        string expectedMeterUnitsPerCredit = "meter_units_per_credit";
        string expectedProductID = "product_id";

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedMeterID, deserialized.MeterID);
        Assert.Equal(expectedMeterName, deserialized.MeterName);
        Assert.Equal(expectedMeterUnitsPerCredit, deserialized.MeterUnitsPerCredit);
        Assert.Equal(expectedProductID, deserialized.ProductID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeterCreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        MeterCreditEntitlementCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedMeterID = "meter_id";
        string expectedName = "name";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, model.MeasurementUnit);
        Assert.Equal(expectedMeterID, model.MeterID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedMeterID = "meter_id";
        string expectedName = "name";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, deserialized.MeasurementUnit);
        Assert.Equal(expectedMeterID, deserialized.MeterID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meter
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
        };

        Meter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomFieldResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomFieldResponse { Key = "key", Value = "value" };

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomFieldResponse { Key = "key", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomFieldResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomFieldResponse { Key = "key", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomFieldResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomFieldResponse { Key = "key", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomFieldResponse { Key = "key", Value = "value" };

        CustomFieldResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
