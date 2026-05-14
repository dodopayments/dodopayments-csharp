using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class SubscriptionRenewedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRenewedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                        Description = "description",
                        PricePerUnit = "10.50",
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
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        Subscription expectedData = new()
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
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                    Description = "description",
                    PricePerUnit = "10.50",
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
            CancellationComment = "cancellation_comment",
            CancellationFeedback = CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("subscription.renewed");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionRenewedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                        Description = "description",
                        PricePerUnit = "10.50",
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
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRenewedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRenewedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                        Description = "description",
                        PricePerUnit = "10.50",
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
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRenewedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        Subscription expectedData = new()
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
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                    Description = "description",
                    PricePerUnit = "10.50",
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
            CancellationComment = "cancellation_comment",
            CancellationFeedback = CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("subscription.renewed");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionRenewedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                        Description = "description",
                        PricePerUnit = "10.50",
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
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionRenewedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
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
                        Description = "description",
                        PricePerUnit = "10.50",
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
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionRenewedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
