using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<UpdateSubscriptionPlanReq, UpdateSubscriptionPlanReqFromRaw>)
)]
public sealed record class UpdateSubscriptionPlanReq : JsonModel
{
    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
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
    /// Proration Billing Mode
    /// </summary>
    public required ApiEnum<
        string,
        UpdateSubscriptionPlanReqProrationBillingMode
    > ProrationBillingMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode>
            >("proration_billing_mode");
        }
        init { this._rawData.Set("proration_billing_mode", value); }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Whether adaptive currency fees should be included in the price (true) or
    /// added on top (false). If not specified, uses the subscription's stored setting.
    /// </summary>
    public bool? AdaptiveCurrencyFeesInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("adaptive_currency_fees_inclusive");
        }
        init { this._rawData.Set("adaptive_currency_fees_inclusive", value); }
    }

    /// <summary>
    /// Addons for the new plan. Note : Leaving this empty would remove any existing addons
    /// </summary>
    public IReadOnlyList<AttachAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttachAddon>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttachAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// DEPRECATED: Use discount_codes instead. Cannot be used together with discount_codes.
    /// </summary>
    [Obsolete("Use `discount_id` instead.")]
    public string? DiscountCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_code");
        }
        init { this._rawData.Set("discount_code", value); }
    }

    /// <summary>
    /// Stacked discount codes to apply to the new plan. Max 20. Cannot be used together
    /// with discount_code. If provided, replaces any existing discount codes. Empty
    /// array removes all discounts. If not provided (None), existing discounts with
    /// preserve_on_plan_change=true are preserved.
    /// </summary>
    public IReadOnlyList<string>? DiscountCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("discount_codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "discount_codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When to apply the plan change. - `immediately` (default): Apply the plan
    /// change right away - `next_billing_date`: Schedule the change for the next
    /// billing date
    /// </summary>
    public ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>? EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>
            >("effective_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effective_at", value);
        }
    }

    /// <summary>
    /// Metadata for the payment. If not passed, the metadata of the subscription
    /// will be taken
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Controls behavior when the plan change payment fails. - `prevent_change`:
    /// Keep subscription on current plan until payment succeeds - `apply_change`
    /// (default): Apply plan change immediately regardless of payment outcome
    ///
    /// <para>If not specified, uses the business-level default setting.</para>
    /// </summary>
    public ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>? OnPaymentFailure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>
            >("on_payment_failure");
        }
        init { this._rawData.Set("on_payment_failure", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        this.ProrationBillingMode.Validate();
        _ = this.Quantity;
        _ = this.AdaptiveCurrencyFeesInclusive;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.DiscountCode;
        _ = this.DiscountCodes;
        this.EffectiveAt?.Validate();
        _ = this.Metadata;
        this.OnPaymentFailure?.Validate();
    }

    public UpdateSubscriptionPlanReq() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateSubscriptionPlanReq(UpdateSubscriptionPlanReq updateSubscriptionPlanReq)
        : base(updateSubscriptionPlanReq) { }
#pragma warning restore CS8618

    public UpdateSubscriptionPlanReq(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateSubscriptionPlanReq(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateSubscriptionPlanReqFromRaw.FromRawUnchecked"/>
    public static UpdateSubscriptionPlanReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateSubscriptionPlanReqFromRaw : IFromRawJson<UpdateSubscriptionPlanReq>
{
    /// <inheritdoc/>
    public UpdateSubscriptionPlanReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateSubscriptionPlanReq.FromRawUnchecked(rawData);
}

/// <summary>
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(UpdateSubscriptionPlanReqProrationBillingModeConverter))]
public enum UpdateSubscriptionPlanReqProrationBillingMode
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class UpdateSubscriptionPlanReqProrationBillingModeConverter
    : JsonConverter<UpdateSubscriptionPlanReqProrationBillingMode>
{
    public override UpdateSubscriptionPlanReqProrationBillingMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            "full_immediately" => UpdateSubscriptionPlanReqProrationBillingMode.FullImmediately,
            "difference_immediately" =>
                UpdateSubscriptionPlanReqProrationBillingMode.DifferenceImmediately,
            "do_not_bill" => UpdateSubscriptionPlanReqProrationBillingMode.DoNotBill,
            _ => (UpdateSubscriptionPlanReqProrationBillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqProrationBillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately =>
                    "prorated_immediately",
                UpdateSubscriptionPlanReqProrationBillingMode.FullImmediately => "full_immediately",
                UpdateSubscriptionPlanReqProrationBillingMode.DifferenceImmediately =>
                    "difference_immediately",
                UpdateSubscriptionPlanReqProrationBillingMode.DoNotBill => "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When to apply the plan change. - `immediately` (default): Apply the plan change
/// right away - `next_billing_date`: Schedule the change for the next billing date
/// </summary>
[JsonConverter(typeof(UpdateSubscriptionPlanReqEffectiveAtConverter))]
public enum UpdateSubscriptionPlanReqEffectiveAt
{
    Immediately,
    NextBillingDate,
}

sealed class UpdateSubscriptionPlanReqEffectiveAtConverter
    : JsonConverter<UpdateSubscriptionPlanReqEffectiveAt>
{
    public override UpdateSubscriptionPlanReqEffectiveAt Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            "next_billing_date" => UpdateSubscriptionPlanReqEffectiveAt.NextBillingDate,
            _ => (UpdateSubscriptionPlanReqEffectiveAt)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqEffectiveAt value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateSubscriptionPlanReqEffectiveAt.Immediately => "immediately",
                UpdateSubscriptionPlanReqEffectiveAt.NextBillingDate => "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Controls behavior when the plan change payment fails. - `prevent_change`: Keep
/// subscription on current plan until payment succeeds - `apply_change` (default):
/// Apply plan change immediately regardless of payment outcome
///
/// <para>If not specified, uses the business-level default setting.</para>
/// </summary>
[JsonConverter(typeof(UpdateSubscriptionPlanReqOnPaymentFailureConverter))]
public enum UpdateSubscriptionPlanReqOnPaymentFailure
{
    PreventChange,
    ApplyChange,
}

sealed class UpdateSubscriptionPlanReqOnPaymentFailureConverter
    : JsonConverter<UpdateSubscriptionPlanReqOnPaymentFailure>
{
    public override UpdateSubscriptionPlanReqOnPaymentFailure Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prevent_change" => UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            "apply_change" => UpdateSubscriptionPlanReqOnPaymentFailure.ApplyChange,
            _ => (UpdateSubscriptionPlanReqOnPaymentFailure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqOnPaymentFailure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange => "prevent_change",
                UpdateSubscriptionPlanReqOnPaymentFailure.ApplyChange => "apply_change",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
