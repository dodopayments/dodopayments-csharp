using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(typeof(ModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : ModelBase
{
    /// <summary>
    /// The discount amount.
    ///
    /// <para>- If `discount_type` is `percentage`, this is in **basis points**
    ///  (e.g., 540 => 5.4%). - Otherwise, this is **USD cents** (e.g., 100 => `$1.00`).</para>
    /// </summary>
    public required int Amount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The business this discount belongs to.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The discount code (up to 16 chars).
    /// </summary>
    public required string Code
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "code"); }
        init { ModelBase.Set(this._rawData, "code", value); }
    }

    /// <summary>
    /// Timestamp when the discount is created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "discount_id"); }
        init { ModelBase.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted.
    /// </summary>
    public required IReadOnlyList<string> RestrictedTo
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "restricted_to"); }
        init { ModelBase.Set(this._rawData, "restricted_to", value); }
    }

    /// <summary>
    /// How many times this discount has been used.
    /// </summary>
    public required int TimesUsed
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "times_used"); }
        init { ModelBase.Set(this._rawData, "times_used", value); }
    }

    /// <summary>
    /// The type of discount, e.g. `percentage`, `flat`, or `flat_per_unit`.
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DiscountType>>(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Optional date/time after which discount is expired.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "expires_at"); }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// Name for the Discount
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not
    /// provided, the discount will be applied indefinitely to all recurring payments
    /// related to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "subscription_cycles"); }
        init { ModelBase.Set(this._rawData, "subscription_cycles", value); }
    }

    /// <summary>
    /// Usage limit for this discount, if any.
    /// </summary>
    public int? UsageLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "usage_limit"); }
        init { ModelBase.Set(this._rawData, "usage_limit", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRaw<Discount>
{
    /// <inheritdoc/>
    public Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Discount.FromRawUnchecked(rawData);
}
