using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementUpdateParams
        {
            ID = "id",
            Currency = Currency.Aed,
            Description = "description",
            ExpiresAfterDays = 0,
            MaxRolloverCount = 0,
            Name = "name",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = 0,
            PricePerUnit = "price_per_unit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            Unit = "unit",
        };

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        int expectedExpiresAfterDays = 0;
        int expectedMaxRolloverCount = 0;
        string expectedName = "name";
        ApiEnum<string, CbbOverageBehavior> expectedOverageBehavior =
            CbbOverageBehavior.ForgiveAtReset;
        bool expectedOverageEnabled = true;
        long expectedOverageLimit = 0;
        string expectedPricePerUnit = "price_per_unit";
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedUnit = "unit";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExpiresAfterDays, parameters.ExpiresAfterDays);
        Assert.Equal(expectedMaxRolloverCount, parameters.MaxRolloverCount);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOverageBehavior, parameters.OverageBehavior);
        Assert.Equal(expectedOverageEnabled, parameters.OverageEnabled);
        Assert.Equal(expectedOverageLimit, parameters.OverageLimit);
        Assert.Equal(expectedPricePerUnit, parameters.PricePerUnit);
        Assert.Equal(expectedRolloverEnabled, parameters.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, parameters.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, parameters.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, parameters.RolloverTimeframeInterval);
        Assert.Equal(expectedUnit, parameters.Unit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditEntitlementUpdateParams { ID = "id" };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExpiresAfterDays);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after_days"));
        Assert.Null(parameters.MaxRolloverCount);
        Assert.False(parameters.RawBodyData.ContainsKey("max_rollover_count"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OverageBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("overage_behavior"));
        Assert.Null(parameters.OverageEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("overage_enabled"));
        Assert.Null(parameters.OverageLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("overage_limit"));
        Assert.Null(parameters.PricePerUnit);
        Assert.False(parameters.RawBodyData.ContainsKey("price_per_unit"));
        Assert.Null(parameters.RolloverEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_enabled"));
        Assert.Null(parameters.RolloverPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_percentage"));
        Assert.Null(parameters.RolloverTimeframeCount);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(parameters.RolloverTimeframeInterval);
        Assert.False(parameters.RawBodyData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(parameters.Unit);
        Assert.False(parameters.RawBodyData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CreditEntitlementUpdateParams
        {
            ID = "id",

            Currency = null,
            Description = null,
            ExpiresAfterDays = null,
            MaxRolloverCount = null,
            Name = null,
            OverageBehavior = null,
            OverageEnabled = null,
            OverageLimit = null,
            PricePerUnit = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            Unit = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExpiresAfterDays);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_after_days"));
        Assert.Null(parameters.MaxRolloverCount);
        Assert.True(parameters.RawBodyData.ContainsKey("max_rollover_count"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OverageBehavior);
        Assert.True(parameters.RawBodyData.ContainsKey("overage_behavior"));
        Assert.Null(parameters.OverageEnabled);
        Assert.True(parameters.RawBodyData.ContainsKey("overage_enabled"));
        Assert.Null(parameters.OverageLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("overage_limit"));
        Assert.Null(parameters.PricePerUnit);
        Assert.True(parameters.RawBodyData.ContainsKey("price_per_unit"));
        Assert.Null(parameters.RolloverEnabled);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_enabled"));
        Assert.Null(parameters.RolloverPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_percentage"));
        Assert.Null(parameters.RolloverTimeframeCount);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(parameters.RolloverTimeframeInterval);
        Assert.True(parameters.RawBodyData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(parameters.Unit);
        Assert.True(parameters.RawBodyData.ContainsKey("unit"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/credit-entitlements/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementUpdateParams
        {
            ID = "id",
            Currency = Currency.Aed,
            Description = "description",
            ExpiresAfterDays = 0,
            MaxRolloverCount = 0,
            Name = "name",
            OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
            OverageEnabled = true,
            OverageLimit = 0,
            PricePerUnit = "price_per_unit",
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            Unit = "unit",
        };

        CreditEntitlementUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
