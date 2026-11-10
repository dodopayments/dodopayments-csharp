using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using System = System;

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
    /// Cancel the payment link of a pending plan change, so that this change can
    /// replace it.
    ///
    /// <para>The link is cancelled only if the customer has not started to pay. A
    /// paid or in-progress payment gives a `409`. A failed cancel gives a `503`,
    /// and a retry is safe.</para>
    ///
    /// <para>The request is validated before the cancel. A later failure, for example
    /// an amount below the minimum, leaves the subscription on its current plan
    /// with no open link. A retry is safe.</para>
    ///
    /// <para>The preview route shares this request body and ignores this field.</para>
    /// </summary>
    public bool? CancelOlderPaymentLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cancel_older_payment_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cancel_older_payment_link", value);
        }
    }

    /// <summary>
    /// Replace a scheduled plan change with this one.
    ///
    /// <para>The scheduled change is cancelled by the transaction that applies this
    /// change. A change that never applies leaves the schedule in place.</para>
    ///
    /// <para>`effective_at: next_billing_date` is allowed. The new schedule then
    /// replaces the old one in the request transaction.</para>
    ///
    /// <para>A pending plan change still gets a `409`. This field does not affect it.</para>
    ///
    /// <para>The preview route shares this request body, so a preview that sets
    /// this field also passes the scheduled-change `409`.</para>
    /// </summary>
    public bool? CancelScheduledChangePlan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cancel_scheduled_change_plan");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cancel_scheduled_change_plan", value);
        }
    }

    /// <summary>
    /// Collect the plan-change amount with a payment link. The customer then pays
    /// on a checkout page.
    ///
    /// <para>The business needs the `allow_plan_change_via_payment_link` capability.
    /// The request needs `effective_at: immediately`. The request also needs `on_payment_failure: prevent_change`.</para>
    ///
    /// <para>The preview route shares this request body and ignores this field.</para>
    /// </summary>
    public bool? CollectViaPaymentLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collect_via_payment_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collect_via_payment_link", value);
        }
    }

    /// <summary>
    /// Where a downgrade credit goes. Only invoice-led subscriptions read it. The
    /// default is `customer_balance`.
    /// </summary>
    public ApiEnum<string, UpdateSubscriptionPlanReqCredit>? Credit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateSubscriptionPlanReqCredit>>(
                "credit"
            );
        }
        init { this._rawData.Set("credit", value); }
    }

    /// <summary>
    /// DEPRECATED: Use discount_codes instead. Cannot be used together with discount_codes.
    /// </summary>
    [System::Obsolete("Use `discount_id` instead.")]
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
    /// The invoice of a plan change billed now. Only invoice-led subscriptions read it.
    /// </summary>
    public UpdateSubscriptionPlanReqInvoice? Invoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UpdateSubscriptionPlanReqInvoice>("invoice");
        }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// Metadata for the payment. If not passed, the metadata of the subscription
    /// will be taken
    /// </summary>
    public IReadOnlyDictionary<string, MetadataItem>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, MetadataItem>?>(
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
    /// <para>With `effective_at: next_billing_date`, the plan change payment replaces
    /// the renewal payment. If that payment fails with `prevent_change`, the plan
    /// change is cancelled. The subscription then renews on the current plan, with
    /// the usual payment retries.</para>
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

    /// <summary>
    /// The URL that receives the customer after they pay the payment link. Needs
    /// `collect_via_payment_link: true`. Without it, the request gets a `422`. A
    /// change that collects no money issues no link and does not use the URL. The
    /// preview route validates this field but does not use it.
    ///
    /// <para>The redirect adds `subscription_id`, `payment_id` and `status`. The
    /// `status` value is the status of the plan-change payment. It is not the status
    /// of the subscription. When that payment fails, the subscription stays active
    /// on its current plan. To try again, call this endpoint again to get a new
    /// link. The new plan can apply after the redirect, when the payment webhook arrives.</para>
    /// </summary>
    public string? ReturnUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_url");
        }
        init { this._rawData.Set("return_url", value); }
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
        _ = this.CancelOlderPaymentLink;
        _ = this.CancelScheduledChangePlan;
        _ = this.CollectViaPaymentLink;
        this.Credit?.Validate();
        _ = this.DiscountCode;
        _ = this.DiscountCodes;
        this.EffectiveAt?.Validate();
        this.Invoice?.Validate();
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item.Validate();
            }
        }
        this.OnPaymentFailure?.Validate();
        _ = this.ReturnUrl;
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
    ProratedImmediatelyKeepCycle,
}

sealed class UpdateSubscriptionPlanReqProrationBillingModeConverter
    : JsonConverter<UpdateSubscriptionPlanReqProrationBillingMode>
{
    public override UpdateSubscriptionPlanReqProrationBillingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            "prorated_immediately_keep_cycle" =>
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediatelyKeepCycle,
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
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediatelyKeepCycle =>
                    "prorated_immediately_keep_cycle",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Where a downgrade credit goes. Only invoice-led subscriptions read it. The default
/// is `customer_balance`.
/// </summary>
[JsonConverter(typeof(UpdateSubscriptionPlanReqCreditConverter))]
public enum UpdateSubscriptionPlanReqCredit
{
    CustomerBalance,
    Refund,
}

sealed class UpdateSubscriptionPlanReqCreditConverter
    : JsonConverter<UpdateSubscriptionPlanReqCredit>
{
    public override UpdateSubscriptionPlanReqCredit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "customer_balance" => UpdateSubscriptionPlanReqCredit.CustomerBalance,
            "refund" => UpdateSubscriptionPlanReqCredit.Refund,
            _ => (UpdateSubscriptionPlanReqCredit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqCredit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateSubscriptionPlanReqCredit.CustomerBalance => "customer_balance",
                UpdateSubscriptionPlanReqCredit.Refund => "refund",
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
        System::Type typeToConvert,
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
/// The invoice of a plan change billed now. Only invoice-led subscriptions read it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UpdateSubscriptionPlanReqInvoice,
        UpdateSubscriptionPlanReqInvoiceFromRaw
    >)
)]
public sealed record class UpdateSubscriptionPlanReqInvoice : JsonModel
{
    /// <summary>
    /// The collection method of the invoice. The subscription value applies when absent.
    /// </summary>
    public ApiEnum<string, InvoiceCollectionMethod>? CollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InvoiceCollectionMethod>>(
                "collection_method"
            );
        }
        init { this._rawData.Set("collection_method", value); }
    }

    /// <summary>
    /// `false` keeps the invoice as a draft for review. Default `true`.
    /// </summary>
    public bool? Finalize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("finalize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("finalize", value);
        }
    }

    /// <summary>
    /// The terms of the plan-change invoice. The subscription terms apply when absent.
    /// </summary>
    public UpdateSubscriptionPlanReqInvoicePaymentTerms? PaymentTerms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UpdateSubscriptionPlanReqInvoicePaymentTerms>(
                "payment_terms"
            );
        }
        init { this._rawData.Set("payment_terms", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CollectionMethod?.Validate();
        _ = this.Finalize;
        this.PaymentTerms?.Validate();
    }

    public UpdateSubscriptionPlanReqInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateSubscriptionPlanReqInvoice(
        UpdateSubscriptionPlanReqInvoice updateSubscriptionPlanReqInvoice
    )
        : base(updateSubscriptionPlanReqInvoice) { }
#pragma warning restore CS8618

    public UpdateSubscriptionPlanReqInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateSubscriptionPlanReqInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateSubscriptionPlanReqInvoiceFromRaw.FromRawUnchecked"/>
    public static UpdateSubscriptionPlanReqInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateSubscriptionPlanReqInvoiceFromRaw : IFromRawJson<UpdateSubscriptionPlanReqInvoice>
{
    /// <inheritdoc/>
    public UpdateSubscriptionPlanReqInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateSubscriptionPlanReqInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The terms of the plan-change invoice. The subscription terms apply when absent.
/// </summary>
[JsonConverter(typeof(UpdateSubscriptionPlanReqInvoicePaymentTermsConverter))]
public record class UpdateSubscriptionPlanReqInvoicePaymentTerms : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UpdateSubscriptionPlanReqInvoicePaymentTerms(
        UpdateSubscriptionPlanReqInvoicePaymentTermsType value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateSubscriptionPlanReqInvoicePaymentTerms(
        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateSubscriptionPlanReqInvoicePaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateSubscriptionPlanReqInvoicePaymentTermsType"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `UpdateSubscriptionPlanReqInvoicePaymentTermsType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject(
        [NotNullWhen(true)] out UpdateSubscriptionPlanReqInvoicePaymentTermsType? value
    )
    {
        value = this.Value as UpdateSubscriptionPlanReqInvoicePaymentTermsType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(out var value)) {
    ///     // `value` is of type `UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(
        [NotNullWhen(true)] out UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1? value
    )
    {
        value = this.Value as UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UpdateSubscriptionPlanReqInvoicePaymentTermsType value) =&gt; {...},
    ///     (UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UpdateSubscriptionPlanReqInvoicePaymentTermsType> object_,
        System::Action<UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1> updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1
    )
    {
        switch (this.Value)
        {
            case UpdateSubscriptionPlanReqInvoicePaymentTermsType value:
                object_(value);
                break;
            case UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value:
                updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of UpdateSubscriptionPlanReqInvoicePaymentTerms"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UpdateSubscriptionPlanReqInvoicePaymentTermsType value) =&gt; {...},
    ///     (UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UpdateSubscriptionPlanReqInvoicePaymentTermsType, T> object_,
        System::Func<
            UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1,
            T
        > updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1
    )
    {
        return this.Value switch
        {
            UpdateSubscriptionPlanReqInvoicePaymentTermsType value => object_(value),
            UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value =>
                updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UpdateSubscriptionPlanReqInvoicePaymentTerms"
            ),
        };
    }

    public static implicit operator UpdateSubscriptionPlanReqInvoicePaymentTerms(
        UpdateSubscriptionPlanReqInvoicePaymentTermsType value
    ) => new(value);

    public static implicit operator UpdateSubscriptionPlanReqInvoicePaymentTerms(
        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UpdateSubscriptionPlanReqInvoicePaymentTerms"
            );
        }
        this.Switch(
            (object_) => object_.Validate(),
            (updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1) =>
                updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1.Validate()
        );
    }

    public virtual bool Equals(UpdateSubscriptionPlanReqInvoicePaymentTerms? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            UpdateSubscriptionPlanReqInvoicePaymentTermsType _ => 0,
            UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class UpdateSubscriptionPlanReqInvoicePaymentTermsConverter
    : JsonConverter<UpdateSubscriptionPlanReqInvoicePaymentTerms?>
{
    public override UpdateSubscriptionPlanReqInvoicePaymentTerms? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqInvoicePaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(UpdateSubscriptionPlanReqInvoicePaymentTermsTypeConverter))]
public record class UpdateSubscriptionPlanReqInvoicePaymentTermsType
{
    public JsonElement Element { get; private init; }

    public UpdateSubscriptionPlanReqInvoicePaymentTermsType()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal UpdateSubscriptionPlanReqInvoicePaymentTermsType(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UpdateSubscriptionPlanReqInvoicePaymentTermsType())
        {
            throw new DodoPaymentsInvalidDataException(
                "Invalid value given for 'UpdateSubscriptionPlanReqInvoicePaymentTermsType'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UpdateSubscriptionPlanReqInvoicePaymentTermsType? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UpdateSubscriptionPlanReqInvoicePaymentTermsTypeConverter
    : JsonConverter<UpdateSubscriptionPlanReqInvoicePaymentTermsType>
{
    public override UpdateSubscriptionPlanReqInvoicePaymentTermsType? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateSubscriptionPlanReqInvoicePaymentTermsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1,
        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1FromRaw
    >)
)]
public sealed record class UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 : JsonModel
{
    public required int Days
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("days");
        }
        init { this._rawData.Set("days", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Days;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("net")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(
        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1
    )
        : base(updateSubscriptionPlanReqInvoicePaymentTermsUnionMember1) { }
#pragma warning restore CS8618

    public UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1FromRaw.FromRawUnchecked"/>
    public static UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(int days)
        : this()
    {
        this.Days = days;
    }
}

class UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1FromRaw
    : IFromRawJson<UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1>
{
    /// <inheritdoc/>
    public UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls behavior when the plan change payment fails. - `prevent_change`: Keep
/// subscription on current plan until payment succeeds - `apply_change` (default):
/// Apply plan change immediately regardless of payment outcome
///
/// <para>With `effective_at: next_billing_date`, the plan change payment replaces
/// the renewal payment. If that payment fails with `prevent_change`, the plan change
/// is cancelled. The subscription then renews on the current plan, with the usual
/// payment retries.</para>
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
        System::Type typeToConvert,
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
