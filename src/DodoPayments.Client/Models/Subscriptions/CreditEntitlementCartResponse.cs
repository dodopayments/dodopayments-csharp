using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing credit entitlement cart details for a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditEntitlementCartResponse, CreditEntitlementCartResponseFromRaw>)
)]
public sealed record class CreditEntitlementCartResponse : JsonModel
{
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CreditEntitlementName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_name");
        }
        init { this._rawData.Set("credit_entitlement_name", value); }
    }

    public required string CreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits_amount");
        }
        init { this._rawData.Set("credits_amount", value); }
    }

    /// <summary>
    /// Customer's current overage balance for this entitlement
    /// </summary>
    public required string OverageBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_balance");
        }
        init { this._rawData.Set("overage_balance", value); }
    }

    /// <summary>
    /// Controls how overage is handled at the end of a billing cycle.
    ///
    /// <para>| Preset                  | Charge at billing | Credits reduce overage
    /// | Preserve overage at reset | |-------------------------|:-----------------:|:---------------------:|:-------------------------:|
    /// | `forgive_at_reset`      | No                | No                    | No
    ///                        | | `invoice_at_billing`    | Yes               | No
    ///                    | No                        | | `carry_deficit`
    ///  | No                | No                    | Yes                       |
    /// | `carry_deficit_auto_repay` | No             | Yes                   | Yes
    ///                       |</para>
    /// </summary>
    public required ApiEnum<string, CbbOverageBehavior> OverageBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CbbOverageBehavior>>(
                "overage_behavior"
            );
        }
        init { this._rawData.Set("overage_behavior", value); }
    }

    public required bool OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Customer's current remaining credit balance for this entitlement
    /// </summary>
    public required string RemainingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("remaining_balance");
        }
        init { this._rawData.Set("remaining_balance", value); }
    }

    public required bool RolloverEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("rollover_enabled");
        }
        init { this._rawData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Unit label for the credit entitlement (e.g., "API Calls", "Tokens")
    /// </summary>
    public required string Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    public int? ExpiresAfterDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("expires_after_days");
        }
        init { this._rawData.Set("expires_after_days", value); }
    }

    public int? LowBalanceThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("low_balance_threshold_percent");
        }
        init { this._rawData.Set("low_balance_threshold_percent", value); }
    }

    public int? MaxRolloverCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_rollover_count");
        }
        init { this._rawData.Set("max_rollover_count", value); }
    }

    public string? OverageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("overage_limit");
        }
        init { this._rawData.Set("overage_limit", value); }
    }

    public int? RolloverPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_percentage");
        }
        init { this._rawData.Set("rollover_percentage", value); }
    }

    public int? RolloverTimeframeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_timeframe_count");
        }
        init { this._rawData.Set("rollover_timeframe_count", value); }
    }

    public ApiEnum<string, TimeInterval>? RolloverTimeframeInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TimeInterval>>(
                "rollover_timeframe_interval"
            );
        }
        init { this._rawData.Set("rollover_timeframe_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.CreditsAmount;
        _ = this.OverageBalance;
        this.OverageBehavior.Validate();
        _ = this.OverageEnabled;
        _ = this.ProductID;
        _ = this.RemainingBalance;
        _ = this.RolloverEnabled;
        _ = this.Unit;
        _ = this.ExpiresAfterDays;
        _ = this.LowBalanceThresholdPercent;
        _ = this.MaxRolloverCount;
        _ = this.OverageLimit;
        _ = this.RolloverPercentage;
        _ = this.RolloverTimeframeCount;
        this.RolloverTimeframeInterval?.Validate();
    }

    public CreditEntitlementCartResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementCartResponse(
        CreditEntitlementCartResponse creditEntitlementCartResponse
    )
        : base(creditEntitlementCartResponse) { }
#pragma warning restore CS8618

    public CreditEntitlementCartResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementCartResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementCartResponseFromRaw.FromRawUnchecked"/>
    public static CreditEntitlementCartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditEntitlementCartResponseFromRaw : IFromRawJson<CreditEntitlementCartResponse>
{
    /// <inheritdoc/>
    public CreditEntitlementCartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditEntitlementCartResponse.FromRawUnchecked(rawData);
}
