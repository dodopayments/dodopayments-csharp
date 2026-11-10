using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Invoices = DodoPayments.Client.Models.Invoices;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class SubscriptionChangePlanParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("product_id");
        }
        init { this._rawBodyData.Set("product_id", value); }
    }

    /// <summary>
    /// Proration Billing Mode
    /// </summary>
    public required ApiEnum<string, ProrationBillingMode> ProrationBillingMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ProrationBillingMode>>(
                "proration_billing_mode"
            );
        }
        init { this._rawBodyData.Set("proration_billing_mode", value); }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawBodyData.Set("quantity", value); }
    }

    /// <summary>
    /// Whether adaptive currency fees should be included in the price (true) or
    /// added on top (false). If not specified, uses the subscription's stored setting.
    /// </summary>
    public bool? AdaptiveCurrencyFeesInclusive
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("adaptive_currency_fees_inclusive");
        }
        init { this._rawBodyData.Set("adaptive_currency_fees_inclusive", value); }
    }

    /// <summary>
    /// Addons for the new plan. Note : Leaving this empty would remove any existing addons
    /// </summary>
    public IReadOnlyList<AttachAddon>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AttachAddon>>("addons");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AttachAddon>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("cancel_older_payment_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cancel_older_payment_link", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("cancel_scheduled_change_plan");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cancel_scheduled_change_plan", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("collect_via_payment_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("collect_via_payment_link", value);
        }
    }

    /// <summary>
    /// Where a downgrade credit goes. Only invoice-led subscriptions read it. The
    /// default is `customer_balance`.
    /// </summary>
    public ApiEnum<string, Credit>? Credit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Credit>>("credit");
        }
        init { this._rawBodyData.Set("credit", value); }
    }

    /// <summary>
    /// DEPRECATED: Use discount_codes instead. Cannot be used together with discount_codes.
    /// </summary>
    [System::Obsolete("Use `discount_id` instead.")]
    public string? DiscountCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("discount_code");
        }
        init { this._rawBodyData.Set("discount_code", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("discount_codes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
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
    public ApiEnum<string, EffectiveAt>? EffectiveAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EffectiveAt>>("effective_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("effective_at", value);
        }
    }

    /// <summary>
    /// The invoice of a plan change billed now. Only invoice-led subscriptions read it.
    /// </summary>
    public Invoice? Invoice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Invoice>("invoice");
        }
        init { this._rawBodyData.Set("invoice", value); }
    }

    /// <summary>
    /// Metadata for the payment. If not passed, the metadata of the subscription
    /// will be taken
    /// </summary>
    public IReadOnlyDictionary<string, MetadataItem>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, MetadataItem>?>(
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
    public ApiEnum<string, OnPaymentFailure>? OnPaymentFailure
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OnPaymentFailure>>(
                "on_payment_failure"
            );
        }
        init { this._rawBodyData.Set("on_payment_failure", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("return_url");
        }
        init { this._rawBodyData.Set("return_url", value); }
    }

    public SubscriptionChangePlanParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangePlanParams(SubscriptionChangePlanParams subscriptionChangePlanParams)
        : base(subscriptionChangePlanParams)
    {
        this.SubscriptionID = subscriptionChangePlanParams.SubscriptionID;

        this._rawBodyData = new(subscriptionChangePlanParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionChangePlanParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangePlanParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string subscriptionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SubscriptionID = subscriptionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionChangePlanParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string subscriptionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            subscriptionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SubscriptionID"] = JsonSerializer.SerializeToElement(this.SubscriptionID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionChangePlanParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SubscriptionID?.Equals(other.SubscriptionID) ?? other.SubscriptionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/change-plan", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(ProrationBillingModeConverter))]
public enum ProrationBillingMode
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
    ProratedImmediatelyKeepCycle,
}

sealed class ProrationBillingModeConverter : JsonConverter<ProrationBillingMode>
{
    public override ProrationBillingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" => ProrationBillingMode.ProratedImmediately,
            "full_immediately" => ProrationBillingMode.FullImmediately,
            "difference_immediately" => ProrationBillingMode.DifferenceImmediately,
            "do_not_bill" => ProrationBillingMode.DoNotBill,
            "prorated_immediately_keep_cycle" => ProrationBillingMode.ProratedImmediatelyKeepCycle,
            _ => (ProrationBillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBillingMode.ProratedImmediately => "prorated_immediately",
                ProrationBillingMode.FullImmediately => "full_immediately",
                ProrationBillingMode.DifferenceImmediately => "difference_immediately",
                ProrationBillingMode.DoNotBill => "do_not_bill",
                ProrationBillingMode.ProratedImmediatelyKeepCycle =>
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
[JsonConverter(typeof(CreditConverter))]
public enum Credit
{
    CustomerBalance,
    Refund,
}

sealed class CreditConverter : JsonConverter<Credit>
{
    public override Credit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "customer_balance" => Credit.CustomerBalance,
            "refund" => Credit.Refund,
            _ => (Credit)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Credit value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Credit.CustomerBalance => "customer_balance",
                Credit.Refund => "refund",
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
[JsonConverter(typeof(EffectiveAtConverter))]
public enum EffectiveAt
{
    Immediately,
    NextBillingDate,
}

sealed class EffectiveAtConverter : JsonConverter<EffectiveAt>
{
    public override EffectiveAt Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => EffectiveAt.Immediately,
            "next_billing_date" => EffectiveAt.NextBillingDate,
            _ => (EffectiveAt)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EffectiveAt value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EffectiveAt.Immediately => "immediately",
                EffectiveAt.NextBillingDate => "next_billing_date",
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
[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
{
    /// <summary>
    /// The collection method of the invoice. The subscription value applies when absent.
    /// </summary>
    public ApiEnum<string, Invoices::InvoiceCollectionMethod>? CollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, Invoices::InvoiceCollectionMethod>
            >("collection_method");
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
    public PaymentTerms? PaymentTerms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentTerms>("payment_terms");
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

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invoice(Invoice invoice)
        : base(invoice) { }
#pragma warning restore CS8618

    public Invoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceFromRaw.FromRawUnchecked"/>
    public static Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceFromRaw : IFromRawJson<Invoice>
{
    /// <inheritdoc/>
    public Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The terms of the plan-change invoice. The subscription terms apply when absent.
/// </summary>
[JsonConverter(typeof(PaymentTermsConverter))]
public record class PaymentTerms : ModelBase
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

    public PaymentTerms(Type value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PaymentTerms(UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Type"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `Type`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject([NotNullWhen(true)] out Type? value)
    {
        value = this.Value as Type;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
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
    ///     (Type value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Type> object_, System::Action<UnionMember1> unionMember1)
    {
        switch (this.Value)
        {
            case Type value:
                object_(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of PaymentTerms"
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
    ///     (Type value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Type, T> object_, System::Func<UnionMember1, T> unionMember1)
    {
        return this.Value switch
        {
            Type value => object_(value),
            UnionMember1 value => unionMember1(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of PaymentTerms"
            ),
        };
    }

    public static implicit operator PaymentTerms(Type value) => new(value);

    public static implicit operator PaymentTerms(UnionMember1 value) => new(value);

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
                "Data did not match any variant of PaymentTerms"
            );
        }
        this.Switch((object_) => object_.Validate(), (unionMember1) => unionMember1.Validate());
    }

    public virtual bool Equals(PaymentTerms? other) =>
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
            Type _ => 0,
            UnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class PaymentTermsConverter : JsonConverter<PaymentTerms?>
{
    public override PaymentTerms? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Type>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
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
        PaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(TypeConverter))]
public record class Type
{
    public JsonElement Element { get; private init; }

    public Type()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal Type(JsonElement element)
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
        if (this != new Type())
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for 'Type'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Type? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TypeConverter : JsonConverter<Type>
{
    public override Type? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : JsonModel
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

    public UnionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }
#pragma warning restore CS8618

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember1(int days)
        : this()
    {
        this.Days = days;
    }
}

class UnionMember1FromRaw : IFromRawJson<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(OnPaymentFailureConverter))]
public enum OnPaymentFailure
{
    PreventChange,
    ApplyChange,
}

sealed class OnPaymentFailureConverter : JsonConverter<OnPaymentFailure>
{
    public override OnPaymentFailure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prevent_change" => OnPaymentFailure.PreventChange,
            "apply_change" => OnPaymentFailure.ApplyChange,
            _ => (OnPaymentFailure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OnPaymentFailure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OnPaymentFailure.PreventChange => "prevent_change",
                OnPaymentFailure.ApplyChange => "apply_change",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
