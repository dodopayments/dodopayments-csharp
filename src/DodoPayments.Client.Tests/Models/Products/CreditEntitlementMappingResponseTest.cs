using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class CreditEntitlementMappingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditEntitlementUnit = "credit_entitlement_unit";
        string expectedCreditsAmount = "credits_amount";
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        bool expectedOverageEnabled = true;
        ApiEnum<string, CbbProrationBehavior> expectedProrationBehavior =
            CbbProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        bool expectedTrialCreditsExpireAfterTrial = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        string expectedOverageLimit = "overage_limit";
        string expectedPricePerUnit = "price_per_unit";
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, model.CreditEntitlementName);
        Assert.Equal(expectedCreditEntitlementUnit, model.CreditEntitlementUnit);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
        Assert.Equal(expectedOverageBehavior, model.OverageBehavior);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedProrationBehavior, model.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, model.RolloverEnabled);
        Assert.Equal(expectedTrialCreditsExpireAfterTrial, model.TrialCreditsExpireAfterTrial);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedExpiresAfterDays, model.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, model.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, model.MaxRolloverCount);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedRolloverPercentage, model.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, model.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, model.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, model.TrialCredits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementMappingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementMappingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditEntitlementUnit = "credit_entitlement_unit";
        string expectedCreditsAmount = "credits_amount";
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        bool expectedOverageEnabled = true;
        ApiEnum<string, CbbProrationBehavior> expectedProrationBehavior =
            CbbProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        bool expectedTrialCreditsExpireAfterTrial = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        string expectedOverageLimit = "overage_limit";
        string expectedPricePerUnit = "price_per_unit";
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, deserialized.CreditEntitlementName);
        Assert.Equal(expectedCreditEntitlementUnit, deserialized.CreditEntitlementUnit);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
        Assert.Equal(expectedOverageBehavior, deserialized.OverageBehavior);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedProrationBehavior, deserialized.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, deserialized.RolloverEnabled);
        Assert.Equal(
            expectedTrialCreditsExpireAfterTrial,
            deserialized.TrialCreditsExpireAfterTrial
        );
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedExpiresAfterDays, deserialized.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, deserialized.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, deserialized.MaxRolloverCount);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedRolloverPercentage, deserialized.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, deserialized.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, deserialized.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, deserialized.TrialCredits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.False(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.False(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.False(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PricePerUnit);
        Assert.False(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.RolloverPercentage);
        Assert.False(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.False(model.RawData.ContainsKey("trial_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,

            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageLimit = null,
            PricePerUnit = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.True(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.True(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.True(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PricePerUnit);
        Assert.True(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.RolloverPercentage);
        Assert.True(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.True(model.RawData.ContainsKey("trial_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,

            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageLimit = null,
            PricePerUnit = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlementMappingResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CreditEntitlementUnit = "credit_entitlement_unit",
            CreditsAmount = "credits_amount",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            ProrationBehavior = CbbProrationBehavior.Prorate,
            RolloverEnabled = true,
            TrialCreditsExpireAfterTrial = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageLimit = "overage_limit",
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
        };

        CreditEntitlementMappingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
