using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CancelReason = CancelReason.CancelledByCustomer,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = CancellationFeedback.TooExpensive,
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
            CustomerName = "customer_name",
            DisableOnDemand = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.Pending,
            TaxID = "tax_id",
        };

        string expectedSubscriptionID = "subscription_id";
        BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.CancelledByCustomer;
        string expectedCancellationComment = "cancellation_comment";
        ApiEnum<string, CancellationFeedback> expectedCancellationFeedback =
            CancellationFeedback.TooExpensive;
        List<CreditEntitlementCart> expectedCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditsAmount = "credits_amount",
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageEnabled = true,
                OverageLimit = "overage_limit",
                RolloverEnabled = true,
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
            },
        ];
        string expectedCustomerName = "customer_name";
        DisableOnDemand expectedDisableOnDemand = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.Pending;
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedBilling, parameters.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, parameters.CancelAtNextBillingDate);
        Assert.Equal(expectedCancelReason, parameters.CancelReason);
        Assert.Equal(expectedCancellationComment, parameters.CancellationComment);
        Assert.Equal(expectedCancellationFeedback, parameters.CancellationFeedback);
        Assert.NotNull(parameters.CreditEntitlementCart);
        Assert.Equal(expectedCreditEntitlementCart.Count, parameters.CreditEntitlementCart.Count);
        for (int i = 0; i < expectedCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlementCart[i], parameters.CreditEntitlementCart[i]);
        }
        Assert.Equal(expectedCustomerName, parameters.CustomerName);
        Assert.Equal(expectedDisableOnDemand, parameters.DisableOnDemand);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedNextBillingDate, parameters.NextBillingDate);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTaxID, parameters.TaxID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams { SubscriptionID = "subscription_id" };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.CancelAtNextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_at_next_billing_date"));
        Assert.Null(parameters.CancelReason);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_reason"));
        Assert.Null(parameters.CancellationComment);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellation_comment"));
        Assert.Null(parameters.CancellationFeedback);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellation_feedback"));
        Assert.Null(parameters.CreditEntitlementCart);
        Assert.False(parameters.RawBodyData.ContainsKey("credit_entitlement_cart"));
        Assert.Null(parameters.CustomerName);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_name"));
        Assert.Null(parameters.DisableOnDemand);
        Assert.False(parameters.RawBodyData.ContainsKey("disable_on_demand"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("next_billing_date"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",

            Billing = null,
            CancelAtNextBillingDate = null,
            CancelReason = null,
            CancellationComment = null,
            CancellationFeedback = null,
            CreditEntitlementCart = null,
            CustomerName = null,
            DisableOnDemand = null,
            Metadata = null,
            NextBillingDate = null,
            Status = null,
            TaxID = null,
        };

        Assert.Null(parameters.Billing);
        Assert.True(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.CancelAtNextBillingDate);
        Assert.True(parameters.RawBodyData.ContainsKey("cancel_at_next_billing_date"));
        Assert.Null(parameters.CancelReason);
        Assert.True(parameters.RawBodyData.ContainsKey("cancel_reason"));
        Assert.Null(parameters.CancellationComment);
        Assert.True(parameters.RawBodyData.ContainsKey("cancellation_comment"));
        Assert.Null(parameters.CancellationFeedback);
        Assert.True(parameters.RawBodyData.ContainsKey("cancellation_feedback"));
        Assert.Null(parameters.CreditEntitlementCart);
        Assert.True(parameters.RawBodyData.ContainsKey("credit_entitlement_cart"));
        Assert.Null(parameters.CustomerName);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_name"));
        Assert.Null(parameters.DisableOnDemand);
        Assert.True(parameters.RawBodyData.ContainsKey("disable_on_demand"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NextBillingDate);
        Assert.True(parameters.RawBodyData.ContainsKey("next_billing_date"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateParams parameters = new() { SubscriptionID = "subscription_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/subscriptions/subscription_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CancelReason = CancelReason.CancelledByCustomer,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = CancellationFeedback.TooExpensive,
            CreditEntitlementCart =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
            CustomerName = "customer_name",
            DisableOnDemand = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.Pending,
            TaxID = "tax_id",
        };

        SubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CancelReasonTest : TestBase
{
    [Theory]
    [InlineData(CancelReason.CancelledByCustomer)]
    [InlineData(CancelReason.CancelledByMerchant)]
    [InlineData(CancelReason.CancelledByMerchantSendDunning)]
    [InlineData(CancelReason.DodoTeam)]
    public void Validation_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancelReason.CancelledByCustomer)]
    [InlineData(CancelReason.CancelledByMerchant)]
    [InlineData(CancelReason.CancelledByMerchantSendDunning)]
    [InlineData(CancelReason.DodoTeam)]
    public void SerializationRoundtrip_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CancellationFeedbackTest : TestBase
{
    [Theory]
    [InlineData(CancellationFeedback.TooExpensive)]
    [InlineData(CancellationFeedback.MissingFeatures)]
    [InlineData(CancellationFeedback.SwitchedService)]
    [InlineData(CancellationFeedback.Unused)]
    [InlineData(CancellationFeedback.CustomerService)]
    [InlineData(CancellationFeedback.LowQuality)]
    [InlineData(CancellationFeedback.TooComplex)]
    [InlineData(CancellationFeedback.Other)]
    public void Validation_Works(CancellationFeedback rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationFeedback> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationFeedback.TooExpensive)]
    [InlineData(CancellationFeedback.MissingFeatures)]
    [InlineData(CancellationFeedback.SwitchedService)]
    [InlineData(CancellationFeedback.Unused)]
    [InlineData(CancellationFeedback.CustomerService)]
    [InlineData(CancellationFeedback.LowQuality)]
    [InlineData(CancellationFeedback.TooComplex)]
    [InlineData(CancellationFeedback.Other)]
    public void SerializationRoundtrip_Works(CancellationFeedback rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationFeedback> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreditEntitlementCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
        Assert.Equal(expectedExpiresAfterDays, model.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, model.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, model.MaxRolloverCount);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedRolloverEnabled, model.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, model.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, model.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, model.RolloverTimeframeInterval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
        Assert.Equal(expectedExpiresAfterDays, deserialized.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, deserialized.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, deserialized.MaxRolloverCount);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedRolloverEnabled, deserialized.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, deserialized.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, deserialized.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, deserialized.RolloverTimeframeInterval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditEntitlementCart { CreditEntitlementID = "credit_entitlement_id" };

        Assert.Null(model.CreditsAmount);
        Assert.False(model.RawData.ContainsKey("credits_amount"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.False(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.False(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.False(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageEnabled);
        Assert.False(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RolloverEnabled);
        Assert.False(model.RawData.ContainsKey("rollover_enabled"));
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
        var model = new CreditEntitlementCart { CreditEntitlementID = "credit_entitlement_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",

            CreditsAmount = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageEnabled = null,
            OverageLimit = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
        };

        Assert.Null(model.CreditsAmount);
        Assert.True(model.RawData.ContainsKey("credits_amount"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.True(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.True(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.True(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageEnabled);
        Assert.True(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RolloverEnabled);
        Assert.True(model.RawData.ContainsKey("rollover_enabled"));
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
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",

            CreditsAmount = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageEnabled = null,
            OverageLimit = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlementCart
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        CreditEntitlementCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, deserialized.NextBillingDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DisableOnDemand copied = new(model);

        Assert.Equal(model, copied);
    }
}
