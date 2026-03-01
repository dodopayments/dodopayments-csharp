using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class CreditEntitlementCartResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementCartResponse
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
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditsAmount = "credits_amount";
        string expectedOverageBalance = "overage_balance";
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
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
        Assert.Equal(expectedOverageBehavior, model.OverageBehavior);
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
        var model = new CreditEntitlementCartResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementCartResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementCartResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementCartResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCreditsAmount = "credits_amount";
        string expectedOverageBalance = "overage_balance";
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
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
        Assert.Equal(expectedOverageBehavior, deserialized.OverageBehavior);
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
        var model = new CreditEntitlementCartResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditEntitlementCartResponse
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
        var model = new CreditEntitlementCartResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditEntitlementCartResponse
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
        var model = new CreditEntitlementCartResponse
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
        var model = new CreditEntitlementCartResponse
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
        };

        CreditEntitlementCartResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
