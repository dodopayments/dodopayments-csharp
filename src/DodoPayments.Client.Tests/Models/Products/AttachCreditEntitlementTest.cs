using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class AttachCreditEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        string expectedPricePerUnit = "price_per_unit";
        ApiEnum<string, CbbProrationBehavior> expectedProrationBehavior =
            CbbProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";
        bool expectedTrialCreditsExpireAfterTrial = true;

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedExpiresAfterDays, model.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, model.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, model.MaxRolloverCount);
        Assert.Equal(expectedOverageBehavior, model.OverageBehavior);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedProrationBehavior, model.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, model.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, model.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, model.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, model.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, model.TrialCredits);
        Assert.Equal(expectedTrialCreditsExpireAfterTrial, model.TrialCreditsExpireAfterTrial);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachCreditEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachCreditEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        string expectedPricePerUnit = "price_per_unit";
        ApiEnum<string, CbbProrationBehavior> expectedProrationBehavior =
            CbbProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";
        bool expectedTrialCreditsExpireAfterTrial = true;

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedExpiresAfterDays, deserialized.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, deserialized.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, deserialized.MaxRolloverCount);
        Assert.Equal(expectedOverageBehavior, deserialized.OverageBehavior);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedProrationBehavior, deserialized.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, deserialized.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, deserialized.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, deserialized.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, deserialized.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, deserialized.TrialCredits);
        Assert.Equal(
            expectedTrialCreditsExpireAfterTrial,
            deserialized.TrialCreditsExpireAfterTrial
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.False(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.False(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.False(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageBehavior);
        Assert.False(model.RawData.ContainsKey("overage_behavior"));
        Assert.Null(model.OverageEnabled);
        Assert.False(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PricePerUnit);
        Assert.False(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.ProrationBehavior);
        Assert.False(model.RawData.ContainsKey("proration_behavior"));
        Assert.Null(model.RolloverEnabled);
        Assert.False(model.RawData.ContainsKey("rollover_enabled"));
        Assert.Null(model.RolloverPercentage);
        Assert.False(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.False(model.RawData.ContainsKey("trial_credits"));
        Assert.Null(model.TrialCreditsExpireAfterTrial);
        Assert.False(model.RawData.ContainsKey("trial_credits_expire_after_trial"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",

            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageBehavior = null,
            OverageEnabled = null,
            OverageLimit = null,
            PricePerUnit = null,
            ProrationBehavior = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
            TrialCreditsExpireAfterTrial = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.True(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.True(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.True(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageBehavior);
        Assert.True(model.RawData.ContainsKey("overage_behavior"));
        Assert.Null(model.OverageEnabled);
        Assert.True(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PricePerUnit);
        Assert.True(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.ProrationBehavior);
        Assert.True(model.RawData.ContainsKey("proration_behavior"));
        Assert.Null(model.RolloverEnabled);
        Assert.True(model.RawData.ContainsKey("rollover_enabled"));
        Assert.Null(model.RolloverPercentage);
        Assert.True(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.True(model.RawData.ContainsKey("trial_credits"));
        Assert.Null(model.TrialCreditsExpireAfterTrial);
        Assert.True(model.RawData.ContainsKey("trial_credits_expire_after_trial"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",

            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageBehavior = null,
            OverageEnabled = null,
            OverageLimit = null,
            PricePerUnit = null,
            ProrationBehavior = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
            TrialCreditsExpireAfterTrial = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachCreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        AttachCreditEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}
