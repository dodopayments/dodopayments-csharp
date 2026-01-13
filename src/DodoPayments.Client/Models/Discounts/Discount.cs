using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(typeof(JsonModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : JsonModel
{
    /// <summary>
    /// The discount amount.
    ///
    /// <para>- If `discount_type` is `percentage`, this is in **basis points**
    ///  (e.g., 540 => 5.4%). - Otherwise, this is **USD cents** (e.g., 100 => `$1.00`).</para>
    /// </summary>
    public required int Amount
    {
        get { return this._rawData.GetNotNullStruct<int>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The business this discount belongs to.
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The discount code (up to 16 chars).
    /// </summary>
    public required string Code
    {
        get { return this._rawData.GetNotNullClass<string>("code"); }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Timestamp when the discount is created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get { return this._rawData.GetNotNullClass<string>("discount_id"); }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted.
    /// </summary>
    public required IReadOnlyList<string> RestrictedTo
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("restricted_to"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "restricted_to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How many times this discount has been used.
    /// </summary>
    public required int TimesUsed
    {
        get { return this._rawData.GetNotNullStruct<int>("times_used"); }
        init { this._rawData.Set("times_used", value); }
    }

    /// <summary>
    /// The type of discount, e.g. `percentage`, `flat`, or `flat_per_unit`.
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, DiscountType>>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional date/time after which discount is expired.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at"); }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name for the Discount
    /// </summary>
    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not
    /// provided, the discount will be applied indefinitely to all recurring payments
    /// related to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get { return this._rawData.GetNullableStruct<int>("subscription_cycles"); }
        init { this._rawData.Set("subscription_cycles", value); }
    }

    /// <summary>
    /// Usage limit for this discount, if any.
    /// </summary>
    public int? UsageLimit
    {
        get { return this._rawData.GetNullableStruct<int>("usage_limit"); }
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
        _ = this.RestrictedTo;
        _ = this.TimesUsed;
        this.Type.Validate();
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.SubscriptionCycles;
        _ = this.UsageLimit;
    }

    public Discount() { }

    public Discount(Discount discount)
        : base(discount) { }

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRawJson<Discount>
{
    /// <inheritdoc/>
    public Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Discount.FromRawUnchecked(rawData);
}
