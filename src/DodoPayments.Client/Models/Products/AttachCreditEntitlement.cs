using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// Request struct for attaching a credit entitlement to a product
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AttachCreditEntitlement, AttachCreditEntitlementFromRaw>))]
public sealed record class AttachCreditEntitlement : JsonModel
{
    /// <summary>
    /// ID of the credit entitlement to attach
    /// </summary>
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    /// <summary>
    /// Number of credits to grant when this product is purchased
    /// </summary>
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
    /// Currency for credit-related pricing
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Number of days after which credits expire
    /// </summary>
    public int? ExpiresAfterDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("expires_after_days");
        }
        init { this._rawData.Set("expires_after_days", value); }
    }

    /// <summary>
    /// Balance threshold percentage for low balance notifications (0-100)
    /// </summary>
    public int? LowBalanceThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("low_balance_threshold_percent");
        }
        init { this._rawData.Set("low_balance_threshold_percent", value); }
    }

    /// <summary>
    /// Maximum number of rollover cycles allowed
    /// </summary>
    public int? MaxRolloverCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_rollover_count");
        }
        init { this._rawData.Set("max_rollover_count", value); }
    }

    /// <summary>
    /// Controls how overage is handled at billing cycle end.
    /// </summary>
    public ApiEnum<string, CbbOverageBehavior>? OverageBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CbbOverageBehavior>>(
                "overage_behavior"
            );
        }
        init { this._rawData.Set("overage_behavior", value); }
    }

    /// <summary>
    /// Whether overage usage is allowed beyond credit balance
    /// </summary>
    public bool? OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Maximum amount of overage allowed
    /// </summary>
    public string? OverageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("overage_limit");
        }
        init { this._rawData.Set("overage_limit", value); }
    }

    /// <summary>
    /// Price per credit unit for purchasing additional credits
    /// </summary>
    public string? PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    /// <summary>
    /// Proration behavior for credit grants during plan changes
    /// </summary>
    public ApiEnum<string, CbbProrationBehavior>? ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CbbProrationBehavior>>(
                "proration_behavior"
            );
        }
        init { this._rawData.Set("proration_behavior", value); }
    }

    /// <summary>
    /// Whether unused credits can roll over to the next billing period
    /// </summary>
    public bool? RolloverEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("rollover_enabled");
        }
        init { this._rawData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Percentage of unused credits that can roll over (0-100)
    /// </summary>
    public int? RolloverPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_percentage");
        }
        init { this._rawData.Set("rollover_percentage", value); }
    }

    /// <summary>
    /// Number of timeframe units for rollover window
    /// </summary>
    public int? RolloverTimeframeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_timeframe_count");
        }
        init { this._rawData.Set("rollover_timeframe_count", value); }
    }

    /// <summary>
    /// Time interval for rollover window (day, week, month, year)
    /// </summary>
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

    /// <summary>
    /// Credits granted during trial period
    /// </summary>
    public string? TrialCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trial_credits");
        }
        init { this._rawData.Set("trial_credits", value); }
    }

    /// <summary>
    /// Whether trial credits expire when trial ends
    /// </summary>
    public bool? TrialCreditsExpireAfterTrial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("trial_credits_expire_after_trial");
        }
        init { this._rawData.Set("trial_credits_expire_after_trial", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.CreditsAmount;
        this.Currency?.Validate();
        _ = this.ExpiresAfterDays;
        _ = this.LowBalanceThresholdPercent;
        _ = this.MaxRolloverCount;
        this.OverageBehavior?.Validate();
        _ = this.OverageEnabled;
        _ = this.OverageLimit;
        _ = this.PricePerUnit;
        this.ProrationBehavior?.Validate();
        _ = this.RolloverEnabled;
        _ = this.RolloverPercentage;
        _ = this.RolloverTimeframeCount;
        this.RolloverTimeframeInterval?.Validate();
        _ = this.TrialCredits;
        _ = this.TrialCreditsExpireAfterTrial;
    }

    public AttachCreditEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachCreditEntitlement(AttachCreditEntitlement attachCreditEntitlement)
        : base(attachCreditEntitlement) { }
#pragma warning restore CS8618

    public AttachCreditEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachCreditEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachCreditEntitlementFromRaw.FromRawUnchecked"/>
    public static AttachCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachCreditEntitlementFromRaw : IFromRawJson<AttachCreditEntitlement>
{
    /// <inheritdoc/>
    public AttachCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttachCreditEntitlement.FromRawUnchecked(rawData);
}
