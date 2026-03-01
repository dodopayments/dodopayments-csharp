using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementCreateParams
        {
            Name = "name",
            OverageEnabled = true,
            Precision = 0,
            RolloverEnabled = true,
            Unit = "unit",
            Currency = Currency.Aed,
            Description = "description",
            ExpiresAfterDays = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageLimit = 0,
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        string expectedName = "name";
        bool expectedOverageEnabled = true;
        int expectedPrecision = 0;
        bool expectedRolloverEnabled = true;
        string expectedUnit = "unit";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        int expectedExpiresAfterDays = 0;
        int expectedMaxRolloverCount = 0;
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        long expectedOverageLimit = 0;
        string expectedPricePerUnit = "price_per_unit";
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOverageEnabled, parameters.OverageEnabled);
        Assert.Equal(expectedPrecision, parameters.Precision);
        Assert.Equal(expectedRolloverEnabled, parameters.RolloverEnabled);
        Assert.Equal(expectedUnit, parameters.Unit);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExpiresAfterDays, parameters.ExpiresAfterDays);
        Assert.Equal(expectedMaxRolloverCount, parameters.MaxRolloverCount);
        Assert.Equal(expectedOverageBehavior, parameters.OverageBehavior);
        Assert.Equal(expectedOverageLimit, parameters.OverageLimit);
        Assert.Equal(expectedPricePerUnit, parameters.PricePerUnit);
        Assert.Equal(expectedRolloverPercentage, parameters.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, parameters.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, parameters.RolloverTimeframeInterval);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditEntitlementCreateParams
        {
            Name = "name",
            OverageEnabled = true,
            Precision = 0,
            RolloverEnabled = true,
            Unit = "unit",
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExpiresAfterDays);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after_days"));
        Assert.Null(parameters.MaxRolloverCount);
        Assert.False(parameters.RawBodyData.ContainsKey("max_rollover_count"));
        Assert.Null(parameters.OverageBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("overage_behavior"));
        Assert.Null(parameters.OverageLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("overage_limit"));
        Assert.Null(parameters.PricePerUnit);
        Assert.False(parameters.RawBodyData.ContainsKey("price_per_unit"));
        Assert.Null(parameters.RolloverPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_percentage"));
        Assert.Null(parameters.RolloverTimeframeCount);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(parameters.RolloverTimeframeInterval);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_timeframe_interval"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CreditEntitlementCreateParams
        {
            Name = "name",
            OverageEnabled = true,
            Precision = 0,
            RolloverEnabled = true,
            Unit = "unit",

            Currency = null,
            Description = null,
            ExpiresAfterDays = null,
            MaxRolloverCount = null,
            OverageBehavior = null,
            OverageLimit = null,
            PricePerUnit = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExpiresAfterDays);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_after_days"));
        Assert.Null(parameters.MaxRolloverCount);
        Assert.True(parameters.RawBodyData.ContainsKey("max_rollover_count"));
        Assert.Null(parameters.OverageBehavior);
        Assert.True(parameters.RawBodyData.ContainsKey("overage_behavior"));
        Assert.Null(parameters.OverageLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("overage_limit"));
        Assert.Null(parameters.PricePerUnit);
        Assert.True(parameters.RawBodyData.ContainsKey("price_per_unit"));
        Assert.Null(parameters.RolloverPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_percentage"));
        Assert.Null(parameters.RolloverTimeframeCount);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(parameters.RolloverTimeframeInterval);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_timeframe_interval"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementCreateParams parameters = new()
        {
            Name = "name",
            OverageEnabled = true,
            Precision = 0,
            RolloverEnabled = true,
            Unit = "unit",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/credit-entitlements"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementCreateParams
        {
            Name = "name",
            OverageEnabled = true,
            Precision = 0,
            RolloverEnabled = true,
            Unit = "unit",
            Currency = Currency.Aed,
            Description = "description",
            ExpiresAfterDays = 0,
            MaxRolloverCount = 0,
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageLimit = 0,
            PricePerUnit = "price_per_unit",
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
        };

        CreditEntitlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
