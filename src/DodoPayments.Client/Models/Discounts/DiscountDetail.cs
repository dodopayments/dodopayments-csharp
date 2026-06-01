using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// Response struct for a discount with its position in a stack and optional cycle-tracking
/// information (for subscriptions).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DiscountDetail, DiscountDetailFromRaw>))]
public sealed record class DiscountDetail : JsonModel
{
    /// <summary>
    /// The discount amount in **basis points** (e.g., 540 =&gt; 5.4%).
    /// </summary>
    public required int Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The business this discount belongs to
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The discount code
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Timestamp when the discount was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// Additional metadata
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Position of this discount in the stack (0-based)
    /// </summary>
    public required int Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("position");
        }
        init { this._rawData.Set("position", value); }
    }

    /// <summary>
    /// Whether this discount should be preserved when a subscription changes plans
    /// </summary>
    public required bool PreserveOnPlanChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("preserve_on_plan_change");
        }
        init { this._rawData.Set("preserve_on_plan_change", value); }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted
    /// </summary>
    public required IReadOnlyList<string> RestrictedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("restricted_to");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "restricted_to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How many times this discount has been used
    /// </summary>
    public required int TimesUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("times_used");
        }
        init { this._rawData.Set("times_used", value); }
    }

    /// <summary>
    /// The type of discount
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Remaining billing cycles for this discount on this subscription (None for
    /// one-time payments)
    /// </summary>
    public int? CyclesRemaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("cycles_remaining");
        }
        init { this._rawData.Set("cycles_remaining", value); }
    }

    /// <summary>
    /// Optional date/time after which discount is expired
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name for the Discount
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for
    /// </summary>
    public int? SubscriptionCycles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("subscription_cycles");
        }
        init { this._rawData.Set("subscription_cycles", value); }
    }

    /// <summary>
    /// Usage limit for this discount, if any
    /// </summary>
    public int? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("usage_limit");
        }
        init { this._rawData.Set("usage_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.Code;
        _ = this.CreatedAt;
        _ = this.DiscountID;
        _ = this.Metadata;
        _ = this.Position;
        _ = this.PreserveOnPlanChange;
        _ = this.RestrictedTo;
        _ = this.TimesUsed;
        this.Type.Validate();
        _ = this.CyclesRemaining;
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.SubscriptionCycles;
        _ = this.UsageLimit;
    }

    public DiscountDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountDetail(DiscountDetail discountDetail)
        : base(discountDetail) { }
#pragma warning restore CS8618

    public DiscountDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountDetailFromRaw.FromRawUnchecked"/>
    public static DiscountDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountDetailFromRaw : IFromRawJson<DiscountDetail>
{
    /// <inheritdoc/>
    public DiscountDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscountDetail.FromRawUnchecked(rawData);
}
