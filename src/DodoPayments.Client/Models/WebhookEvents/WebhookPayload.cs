using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using Balances = DodoPayments.Client.Models.CreditEntitlements.Balances;
using Disputes = DodoPayments.Client.Models.Disputes;
using Grants = DodoPayments.Client.Models.Entitlements.Grants;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Payments = DodoPayments.Client.Models.Payments;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.WebhookEvents;

[JsonConverter(typeof(JsonModelConverter<WebhookPayload, WebhookPayloadFromRaw>))]
public sealed record class WebhookPayload : JsonModel
{
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
    /// The latest data at the time of delivery attempt
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred (not necessarily the same of when
    /// it was delivered)
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// Event types for Dodo events
    /// </summary>
    public required ApiEnum<string, WebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebhookEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public WebhookPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPayload(WebhookPayload webhookPayload)
        : base(webhookPayload) { }
#pragma warning restore CS8618

    public WebhookPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPayloadFromRaw.FromRawUnchecked"/>
    public static WebhookPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookPayloadFromRaw : IFromRawJson<WebhookPayload>
{
    /// <inheritdoc/>
    public WebhookPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookPayload.FromRawUnchecked(rawData);
}

/// <summary>
/// The latest data at the time of delivery attempt
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
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

    public Payments::BillingAddress? Billing
    {
        get
        {
            return Match<Payments::BillingAddress?>(
                payment: (x) => x.Billing,
                subscription: (x) => x.Billing,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public string BrandID
    {
        get
        {
            return Match(
                payment: (x) => x.BrandID,
                subscription: (x) => x.BrandID,
                refund: (x) => x.BrandID,
                dispute: (x) => x.BrandID,
                licenseKey: (x) => x.BrandID,
                creditLedgerEntry: (x) => x.BrandID,
                creditBalanceLow: (x) => x.BrandID,
                abandonedCheckout: (x) => x.BrandID,
                dunningAttempt: (x) => x.BrandID,
                entitlementGrant: (x) => x.BrandID
            );
        }
    }

    public string? BusinessID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.BusinessID,
                subscription: (_) => null,
                refund: (x) => x.BusinessID,
                dispute: (x) => x.BusinessID,
                licenseKey: (x) => x.BusinessID,
                creditLedgerEntry: (x) => x.BusinessID,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (x) => x.BusinessID
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                payment: (x) => x.CreatedAt,
                subscription: (x) => x.CreatedAt,
                refund: (x) => x.CreatedAt,
                dispute: (x) => x.CreatedAt,
                licenseKey: (x) => x.CreatedAt,
                creditLedgerEntry: (x) => x.CreatedAt,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (x) => x.CreatedAt,
                entitlementGrant: (x) => x.CreatedAt
            );
        }
    }

    public Payments::CustomerLimitedDetails? Customer
    {
        get
        {
            return Match<Payments::CustomerLimitedDetails?>(
                payment: (x) => x.Customer,
                subscription: (x) => x.Customer,
                refund: (x) => x.Customer,
                dispute: (x) => x.Customer,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public string? PaymentID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.PaymentID,
                subscription: (_) => null,
                refund: (x) => x.PaymentID,
                dispute: (x) => x.PaymentID,
                licenseKey: (x) => x.PaymentID,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (x) => x.PaymentID,
                dunningAttempt: (x) => x.PaymentID,
                entitlementGrant: (x) => x.PaymentID
            );
        }
    }

    public string? DiscountID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.DiscountID,
                subscription: (x) => x.DiscountID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public string? ErrorCode
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.ErrorCode,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (x) => x.ErrorCode
            );
        }
    }

    public string? ErrorMessage
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.ErrorMessage,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (x) => x.ErrorMessage
            );
        }
    }

    public string? SubscriptionID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.SubscriptionID,
                subscription: (x) => x.SubscriptionID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.SubscriptionID,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (x) => x.SubscriptionID,
                abandonedCheckout: (_) => null,
                dunningAttempt: (x) => x.SubscriptionID,
                entitlementGrant: (x) => x.SubscriptionID
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                payment: (x) => x.UpdatedAt,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (x) => x.UpdatedAt
            );
        }
    }

    public JsonElement PayloadType
    {
        get
        {
            return Match(
                payment: (x) => x.PayloadType,
                subscription: (x) => x.PayloadType,
                refund: (x) => x.PayloadType,
                dispute: (x) => x.PayloadType,
                licenseKey: (x) => x.PayloadType,
                creditLedgerEntry: (x) => x.PayloadType,
                creditBalanceLow: (x) => x.PayloadType,
                abandonedCheckout: (x) => x.PayloadType,
                dunningAttempt: (x) => x.PayloadType,
                entitlementGrant: (x) => x.PayloadType
            );
        }
    }

    public string? ProductID
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (x) => x.ProductID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.ProductID,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                payment: (_) => null,
                subscription: (x) => x.ExpiresAt,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.ExpiresAt,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (_) => null,
                refund: (x) => x.Reason,
                dispute: (x) => x.Reason,
                licenseKey: (_) => null,
                creditLedgerEntry: (_) => null,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.ID,
                creditLedgerEntry: (x) => x.ID,
                creditBalanceLow: (_) => null,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (x) => x.ID
            );
        }
    }

    public string? CustomerID
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.CustomerID,
                creditLedgerEntry: (x) => x.CustomerID,
                creditBalanceLow: (x) => x.CustomerID,
                abandonedCheckout: (x) => x.CustomerID,
                dunningAttempt: (x) => x.CustomerID,
                entitlementGrant: (x) => x.CustomerID
            );
        }
    }

    public string? CreditEntitlementID
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (_) => null,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null,
                creditLedgerEntry: (x) => x.CreditEntitlementID,
                creditBalanceLow: (x) => x.CreditEntitlementID,
                abandonedCheckout: (_) => null,
                dunningAttempt: (_) => null,
                entitlementGrant: (_) => null
            );
        }
    }

    public Data(Payment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(Subscription value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(Refund value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(Dispute value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(LicenseKey value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(CreditLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(CreditBalanceLow value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(AbandonedCheckout value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(DunningAttempt value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(EntitlementGrant value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Payment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayment(out var value)) {
    ///     // `value` is of type `Payment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayment([NotNullWhen(true)] out Payment? value)
    {
        value = this.Value as Payment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Subscription"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscription(out var value)) {
    ///     // `value` is of type `Subscription`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscription([NotNullWhen(true)] out Subscription? value)
    {
        value = this.Value as Subscription;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Refund"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRefund(out var value)) {
    ///     // `value` is of type `Refund`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRefund([NotNullWhen(true)] out Refund? value)
    {
        value = this.Value as Refund;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dispute"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDispute(out var value)) {
    ///     // `value` is of type `Dispute`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDispute([NotNullWhen(true)] out Dispute? value)
    {
        value = this.Value as Dispute;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LicenseKey"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `LicenseKey`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey([NotNullWhen(true)] out LicenseKey? value)
    {
        value = this.Value as LicenseKey;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditLedgerEntry(out var value)) {
    ///     // `value` is of type `CreditLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditLedgerEntry([NotNullWhen(true)] out CreditLedgerEntry? value)
    {
        value = this.Value as CreditLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditBalanceLow"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditBalanceLow(out var value)) {
    ///     // `value` is of type `CreditBalanceLow`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditBalanceLow([NotNullWhen(true)] out CreditBalanceLow? value)
    {
        value = this.Value as CreditBalanceLow;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AbandonedCheckout"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAbandonedCheckout(out var value)) {
    ///     // `value` is of type `AbandonedCheckout`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAbandonedCheckout([NotNullWhen(true)] out AbandonedCheckout? value)
    {
        value = this.Value as AbandonedCheckout;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DunningAttempt"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDunningAttempt(out var value)) {
    ///     // `value` is of type `DunningAttempt`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDunningAttempt([NotNullWhen(true)] out DunningAttempt? value)
    {
        value = this.Value as DunningAttempt;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementGrant"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEntitlementGrant(out var value)) {
    ///     // `value` is of type `EntitlementGrant`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEntitlementGrant([NotNullWhen(true)] out EntitlementGrant? value)
    {
        value = this.Value as EntitlementGrant;
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
    ///     (Payment value) =&gt; {...},
    ///     (Subscription value) =&gt; {...},
    ///     (Refund value) =&gt; {...},
    ///     (Dispute value) =&gt; {...},
    ///     (LicenseKey value) =&gt; {...},
    ///     (CreditLedgerEntry value) =&gt; {...},
    ///     (CreditBalanceLow value) =&gt; {...},
    ///     (AbandonedCheckout value) =&gt; {...},
    ///     (DunningAttempt value) =&gt; {...},
    ///     (EntitlementGrant value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Payment> payment,
        Action<Subscription> subscription,
        Action<Refund> refund,
        Action<Dispute> dispute,
        Action<LicenseKey> licenseKey,
        Action<CreditLedgerEntry> creditLedgerEntry,
        Action<CreditBalanceLow> creditBalanceLow,
        Action<AbandonedCheckout> abandonedCheckout,
        Action<DunningAttempt> dunningAttempt,
        Action<EntitlementGrant> entitlementGrant
    )
    {
        switch (this.Value)
        {
            case Payment value:
                payment(value);
                break;
            case Subscription value:
                subscription(value);
                break;
            case Refund value:
                refund(value);
                break;
            case Dispute value:
                dispute(value);
                break;
            case LicenseKey value:
                licenseKey(value);
                break;
            case CreditLedgerEntry value:
                creditLedgerEntry(value);
                break;
            case CreditBalanceLow value:
                creditBalanceLow(value);
                break;
            case AbandonedCheckout value:
                abandonedCheckout(value);
                break;
            case DunningAttempt value:
                dunningAttempt(value);
                break;
            case EntitlementGrant value:
                entitlementGrant(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Data"
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
    ///     (Payment value) =&gt; {...},
    ///     (Subscription value) =&gt; {...},
    ///     (Refund value) =&gt; {...},
    ///     (Dispute value) =&gt; {...},
    ///     (LicenseKey value) =&gt; {...},
    ///     (CreditLedgerEntry value) =&gt; {...},
    ///     (CreditBalanceLow value) =&gt; {...},
    ///     (AbandonedCheckout value) =&gt; {...},
    ///     (DunningAttempt value) =&gt; {...},
    ///     (EntitlementGrant value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Payment, T> payment,
        Func<Subscription, T> subscription,
        Func<Refund, T> refund,
        Func<Dispute, T> dispute,
        Func<LicenseKey, T> licenseKey,
        Func<CreditLedgerEntry, T> creditLedgerEntry,
        Func<CreditBalanceLow, T> creditBalanceLow,
        Func<AbandonedCheckout, T> abandonedCheckout,
        Func<DunningAttempt, T> dunningAttempt,
        Func<EntitlementGrant, T> entitlementGrant
    )
    {
        return this.Value switch
        {
            Payment value => payment(value),
            Subscription value => subscription(value),
            Refund value => refund(value),
            Dispute value => dispute(value),
            LicenseKey value => licenseKey(value),
            CreditLedgerEntry value => creditLedgerEntry(value),
            CreditBalanceLow value => creditBalanceLow(value),
            AbandonedCheckout value => abandonedCheckout(value),
            DunningAttempt value => dunningAttempt(value),
            EntitlementGrant value => entitlementGrant(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Data"
            ),
        };
    }

    public static implicit operator Data(Payment value) => new(value);

    public static implicit operator Data(Subscription value) => new(value);

    public static implicit operator Data(Refund value) => new(value);

    public static implicit operator Data(Dispute value) => new(value);

    public static implicit operator Data(LicenseKey value) => new(value);

    public static implicit operator Data(CreditLedgerEntry value) => new(value);

    public static implicit operator Data(CreditBalanceLow value) => new(value);

    public static implicit operator Data(AbandonedCheckout value) => new(value);

    public static implicit operator Data(DunningAttempt value) => new(value);

    public static implicit operator Data(EntitlementGrant value) => new(value);

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
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch(
            (payment) => payment.Validate(),
            (subscription) => subscription.Validate(),
            (refund) => refund.Validate(),
            (dispute) => dispute.Validate(),
            (licenseKey) => licenseKey.Validate(),
            (creditLedgerEntry) => creditLedgerEntry.Validate(),
            (creditBalanceLow) => creditBalanceLow.Validate(),
            (abandonedCheckout) => abandonedCheckout.Validate(),
            (dunningAttempt) => dunningAttempt.Validate(),
            (entitlementGrant) => entitlementGrant.Validate()
        );
    }

    public virtual bool Equals(Data? other) =>
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
            Payment _ => 0,
            Subscription _ => 1,
            Refund _ => 2,
            Dispute _ => 3,
            LicenseKey _ => 4,
            CreditLedgerEntry _ => 5,
            CreditBalanceLow _ => 6,
            AbandonedCheckout _ => 7,
            DunningAttempt _ => 8,
            EntitlementGrant _ => 9,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? payloadType;
        try
        {
            payloadType = element.GetProperty("payload_type").GetString();
        }
        catch
        {
            payloadType = null;
        }

        switch (payloadType)
        {
            case "Payment":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Payment>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "Subscription":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Subscription>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "Refund":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Refund>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "Dispute":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Dispute>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "LicenseKey":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<LicenseKey>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "CreditLedgerEntry":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "CreditBalanceLow":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditBalanceLow>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "AbandonedCheckout":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AbandonedCheckout>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "DunningAttempt":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DunningAttempt>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "EntitlementGrant":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EntitlementGrant>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Data(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Payment, PaymentFromRaw>))]
public sealed record class Payment : JsonModel
{
    public required Payments::BillingAddress Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::BillingAddress>("billing");
        }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Identifier of the business associated with the payment
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
    /// Timestamp when the payment was created
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

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required bool DigitalProductsDelivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("digital_products_delivered");
        }
        init { this._rawData.Set("digital_products_delivered", value); }
    }

    /// <summary>
    /// List of disputes associated with this payment
    /// </summary>
    public required IReadOnlyList<Disputes::Dispute> Disputes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Disputes::Dispute>>("disputes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Disputes::Dispute>>(
                "disputes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Additional custom data associated with the payment
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
    /// Unique identifier for the payment
    /// </summary>
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Which processor handled this payment. `stripe` / `adyen` for BYOP routes (the
    /// merchant's own Hyperswitch connector); `dodo` for everything Dodo processed itself.
    /// </summary>
    public required ApiEnum<string, Payments::PaymentProvider> PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Payments::PaymentProvider>>(
                "payment_provider"
            );
        }
        init { this._rawData.Set("payment_provider", value); }
    }

    /// <summary>
    /// List of refunds issued for this payment
    /// </summary>
    public required IReadOnlyList<Payments::RefundListItem> Refunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Payments::RefundListItem>>(
                "refunds"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payments::RefundListItem>>(
                "refunds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Retry attempt number for subscription renewal payments. `0` for the original
    /// payment, `1`+ for each scheduled off-session retry after a failed renewal.
    /// Always `0` for non-subscription payments.
    /// </summary>
    public required int RetryAttempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("retry_attempt");
        }
        init { this._rawData.Set("retry_attempt", value); }
    }

    /// <summary>
    /// The amount that will be credited to your Dodo balance after currency conversion
    /// and processing. Especially relevant for adaptive pricing where the customer's
    /// payment currency differs from your settlement currency.
    /// </summary>
    public required int SettlementAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("settlement_amount");
        }
        init { this._rawData.Set("settlement_amount", value); }
    }

    public required ApiEnum<string, Currency> SettlementCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("settlement_currency");
        }
        init { this._rawData.Set("settlement_currency", value); }
    }

    /// <summary>
    /// Total amount charged to the customer including tax, in the currency's smallest
    /// unit (e.g. cents for USD, yen for JPY, fils for KWD — see the currency's decimal places)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <summary>
    /// Cardholder name
    /// </summary>
    public string? CardHolderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_holder_name");
        }
        init { this._rawData.Set("card_holder_name", value); }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryCode>>(
                "card_issuing_country"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("card_issuing_country", value);
        }
    }

    /// <summary>
    /// The last four digits of the card
    /// </summary>
    public string? CardLastFour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_last_four");
        }
        init { this._rawData.Set("card_last_four", value); }
    }

    /// <summary>
    /// Card network like VISA, MASTERCARD etc.
    /// </summary>
    public string? CardNetwork
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_network");
        }
        init { this._rawData.Set("card_network", value); }
    }

    /// <summary>
    /// The type of card DEBIT or CREDIT
    /// </summary>
    public string? CardType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_type");
        }
        init { this._rawData.Set("card_type", value); }
    }

    /// <summary>
    /// If payment is made using a checkout session, this field is set to the id of
    /// the session.
    /// </summary>
    public string? CheckoutSessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkout_session_id");
        }
        init { this._rawData.Set("checkout_session_id", value); }
    }

    /// <summary>
    /// Customer's responses to custom fields collected during checkout
    /// </summary>
    public IReadOnlyList<Payments::CustomFieldResponse>? CustomFieldResponses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payments::CustomFieldResponse>>(
                "custom_field_responses"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payments::CustomFieldResponse>?>(
                "custom_field_responses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// DEPRECATED: Use discounts instead. Returns the first discount's ID if present.
    /// </summary>
    [Obsolete("Use `discounts` instead.")]
    public string? DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// All stacked discounts applied, ordered by position
    /// </summary>
    public IReadOnlyList<DiscountDetail>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DiscountDetail>>("discounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DiscountDetail>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An error code if the payment failed
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// An error message if the payment failed
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Invoice ID for this payment. Uses India-specific invoice ID if available.
    /// </summary>
    public string? InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_id");
        }
        init { this._rawData.Set("invoice_id", value); }
    }

    /// <summary>
    /// URL to download the invoice PDF for this payment.
    /// </summary>
    public string? InvoiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_url");
        }
        init { this._rawData.Set("invoice_url", value); }
    }

    /// <summary>
    /// Checkout URL
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_link");
        }
        init { this._rawData.Set("payment_link", value); }
    }

    /// <summary>
    /// Payment method used by customer (e.g. "card", "bank_transfer")
    /// </summary>
    public string? PaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method");
        }
        init { this._rawData.Set("payment_method", value); }
    }

    /// <summary>
    /// Specific type of payment method (e.g. "visa", "mastercard")
    /// </summary>
    public string? PaymentMethodType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method_type");
        }
        init { this._rawData.Set("payment_method_type", value); }
    }

    /// <summary>
    /// List of products purchased in a one-time payment
    /// </summary>
    public IReadOnlyList<Payments::ProductCart>? ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payments::ProductCart>>(
                "product_cart"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payments::ProductCart>?>(
                "product_cart",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, Payments::PaymentRefundStatus>? RefundStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Payments::PaymentRefundStatus>>(
                "refund_status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("refund_status", value);
        }
    }

    /// <summary>
    /// This represents the portion of settlement_amount that corresponds to taxes
    /// collected. Especially relevant for adaptive pricing where the tax component
    /// must be tracked separately in your Dodo balance.
    /// </summary>
    public int? SettlementTax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("settlement_tax");
        }
        init { this._rawData.Set("settlement_tax", value); }
    }

    public ApiEnum<string, Payments::IntentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Payments::IntentStatus>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Identifier of the subscription if payment is part of a subscription
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Amount of tax collected in the currency's smallest unit (e.g. cents for USD,
    /// yen for JPY, fils for KWD)
    /// </summary>
    public int? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// Timestamp when the payment was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Payments::Payment(Payment payment) =>
        new()
        {
            Billing = payment.Billing,
            BrandID = payment.BrandID,
            BusinessID = payment.BusinessID,
            CreatedAt = payment.CreatedAt,
            Currency = payment.Currency,
            Customer = payment.Customer,
            DigitalProductsDelivered = payment.DigitalProductsDelivered,
            Disputes = payment.Disputes,
            Metadata = payment.Metadata,
            PaymentID = payment.PaymentID,
            PaymentProvider = payment.PaymentProvider,
            Refunds = payment.Refunds,
            RetryAttempt = payment.RetryAttempt,
            SettlementAmount = payment.SettlementAmount,
            SettlementCurrency = payment.SettlementCurrency,
            TotalAmount = payment.TotalAmount,
            CardHolderName = payment.CardHolderName,
            CardIssuingCountry = payment.CardIssuingCountry,
            CardLastFour = payment.CardLastFour,
            CardNetwork = payment.CardNetwork,
            CardType = payment.CardType,
            CheckoutSessionID = payment.CheckoutSessionID,
            CustomFieldResponses = payment.CustomFieldResponses,
            DiscountID = payment.DiscountID,
            Discounts = payment.Discounts,
            ErrorCode = payment.ErrorCode,
            ErrorMessage = payment.ErrorMessage,
            InvoiceID = payment.InvoiceID,
            InvoiceUrl = payment.InvoiceUrl,
            PaymentLink = payment.PaymentLink,
            PaymentMethod = payment.PaymentMethod,
            PaymentMethodType = payment.PaymentMethodType,
            ProductCart = payment.ProductCart,
            RefundStatus = payment.RefundStatus,
            SettlementTax = payment.SettlementTax,
            Status = payment.Status,
            SubscriptionID = payment.SubscriptionID,
            Tax = payment.Tax,
            UpdatedAt = payment.UpdatedAt,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Billing.Validate();
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.DigitalProductsDelivered;
        foreach (var item in this.Disputes)
        {
            item.Validate();
        }
        _ = this.Metadata;
        _ = this.PaymentID;
        this.PaymentProvider.Validate();
        foreach (var item in this.Refunds)
        {
            item.Validate();
        }
        _ = this.RetryAttempt;
        _ = this.SettlementAmount;
        this.SettlementCurrency.Validate();
        _ = this.TotalAmount;
        _ = this.CardHolderName;
        this.CardIssuingCountry?.Validate();
        _ = this.CardLastFour;
        _ = this.CardNetwork;
        _ = this.CardType;
        _ = this.CheckoutSessionID;
        foreach (var item in this.CustomFieldResponses ?? [])
        {
            item.Validate();
        }
        _ = this.DiscountID;
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.InvoiceID;
        _ = this.InvoiceUrl;
        _ = this.PaymentLink;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodType;
        foreach (var item in this.ProductCart ?? [])
        {
            item.Validate();
        }
        this.RefundStatus?.Validate();
        _ = this.SettlementTax;
        this.Status?.Validate();
        _ = this.SubscriptionID;
        _ = this.Tax;
        _ = this.UpdatedAt;
        if (!JsonElement.DeepEquals(this.PayloadType, JsonSerializer.SerializeToElement("Payment")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public Payment()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("Payment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payment(Payment payment)
        : base(payment) { }
#pragma warning restore CS8618

    public Payment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("Payment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFromRaw.FromRawUnchecked"/>
    public static Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFromRaw : IFromRawJson<Payment>
{
    /// <inheritdoc/>
    public Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payment.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required IReadOnlyList<Subscriptions::AddonCartResponseItem> Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<Subscriptions::AddonCartResponseItem>
            >("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::AddonCartResponseItem>>(
                "addons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Payments::BillingAddress Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::BillingAddress>("billing");
        }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// Brand id this subscription belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("cancel_at_next_billing_date");
        }
        init { this._rawData.Set("cancel_at_next_billing_date", value); }
    }

    /// <summary>
    /// Timestamp when the subscription was created
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
    /// Credit entitlement cart settings for this subscription
    /// </summary>
    public required IReadOnlyList<Subscriptions::CreditEntitlementCartResponse> CreditEntitlementCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<Subscriptions::CreditEntitlementCartResponse>
            >("credit_entitlement_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::CreditEntitlementCartResponse>>(
                "credit_entitlement_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
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
    /// Meter credit entitlement cart settings for this subscription
    /// </summary>
    public required IReadOnlyList<Subscriptions::MeterCreditEntitlementCartResponse> MeterCreditEntitlementCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<Subscriptions::MeterCreditEntitlementCartResponse>
            >("meter_credit_entitlement_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::MeterCreditEntitlementCartResponse>>(
                "meter_credit_entitlement_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required IReadOnlyList<Subscriptions::MeterCartResponseItem> Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<Subscriptions::MeterCartResponseItem>
            >("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::MeterCartResponseItem>>(
                "meters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required DateTimeOffset NextBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("next_billing_date");
        }
        init { this._rawData.Set("next_billing_date", value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("on_demand");
        }
        init { this._rawData.Set("on_demand", value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("payment_frequency_count");
        }
        init { this._rawData.Set("payment_frequency_count", value); }
    }

    public required ApiEnum<string, Subscriptions::TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Subscriptions::TimeInterval>>(
                "payment_frequency_interval"
            );
        }
        init { this._rawData.Set("payment_frequency_interval", value); }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required DateTimeOffset PreviousBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("previous_billing_date");
        }
        init { this._rawData.Set("previous_billing_date", value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
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
    /// Number of units/items included in the subscription
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
    /// Amount charged before tax for each recurring payment in the currency's smallest
    /// unit (cents for USD, yen for JPY, fils for KWD)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("recurring_pre_tax_amount");
        }
        init { this._rawData.Set("recurring_pre_tax_amount", value); }
    }

    public required ApiEnum<string, Subscriptions::SubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, Subscriptions::SubscriptionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("subscription_period_count");
        }
        init { this._rawData.Set("subscription_period_count", value); }
    }

    public required ApiEnum<string, Subscriptions::TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Subscriptions::TimeInterval>>(
                "subscription_period_interval"
            );
        }
        init { this._rawData.Set("subscription_period_interval", value); }
    }

    /// <summary>
    /// Indicates if the recurring_pre_tax_amount is tax inclusive
    /// </summary>
    public required bool TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("trial_period_days");
        }
        init { this._rawData.Set("trial_period_days", value); }
    }

    /// <summary>
    /// Free-text cancellation comment, if any
    /// </summary>
    public string? CancellationComment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cancellation_comment");
        }
        init { this._rawData.Set("cancellation_comment", value); }
    }

    public ApiEnum<string, Subscriptions::CancellationFeedback>? CancellationFeedback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, Subscriptions::CancellationFeedback>
            >("cancellation_feedback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cancellation_feedback", value);
        }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public DateTimeOffset? CancelledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("cancelled_at");
        }
        init { this._rawData.Set("cancelled_at", value); }
    }

    /// <summary>
    /// Customer's responses to custom fields collected during checkout
    /// </summary>
    public IReadOnlyList<Payments::CustomFieldResponse>? CustomFieldResponses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payments::CustomFieldResponse>>(
                "custom_field_responses"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payments::CustomFieldResponse>?>(
                "custom_field_responses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Business / legal name associated with the tax id (B2B). When set this is
    /// used on the invoice in place of the customer's personal name.
    /// </summary>
    public string? CustomerBusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_business_name");
        }
        init { this._rawData.Set("customer_business_name", value); }
    }

    /// <summary>
    /// DEPRECATED: Use discounts[].cycles_remaining instead.
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("discount_cycles_remaining");
        }
        init { this._rawData.Set("discount_cycles_remaining", value); }
    }

    /// <summary>
    /// DEPRECATED: Use discounts instead. Returns the first discount's ID if present.
    /// </summary>
    public string? DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// All stacked discounts applied, ordered by position
    /// </summary>
    public IReadOnlyList<DiscountDetail>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DiscountDetail>>("discounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DiscountDetail>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
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
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method_id");
        }
        init { this._rawData.Set("payment_method_id", value); }
    }

    public Subscriptions::ScheduledPlanChange? ScheduledChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Subscriptions::ScheduledPlanChange>(
                "scheduled_change"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduled_change", value);
        }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Subscriptions::Subscription(Subscription subscription) =>
        new()
        {
            Addons = subscription.Addons,
            Billing = subscription.Billing,
            BrandID = subscription.BrandID,
            CancelAtNextBillingDate = subscription.CancelAtNextBillingDate,
            CreatedAt = subscription.CreatedAt,
            CreditEntitlementCart = subscription.CreditEntitlementCart,
            Currency = subscription.Currency,
            Customer = subscription.Customer,
            Metadata = subscription.Metadata,
            MeterCreditEntitlementCart = subscription.MeterCreditEntitlementCart,
            Meters = subscription.Meters,
            NextBillingDate = subscription.NextBillingDate,
            OnDemand = subscription.OnDemand,
            PaymentFrequencyCount = subscription.PaymentFrequencyCount,
            PaymentFrequencyInterval = subscription.PaymentFrequencyInterval,
            PreviousBillingDate = subscription.PreviousBillingDate,
            ProductID = subscription.ProductID,
            Quantity = subscription.Quantity,
            RecurringPreTaxAmount = subscription.RecurringPreTaxAmount,
            Status = subscription.Status,
            SubscriptionID = subscription.SubscriptionID,
            SubscriptionPeriodCount = subscription.SubscriptionPeriodCount,
            SubscriptionPeriodInterval = subscription.SubscriptionPeriodInterval,
            TaxInclusive = subscription.TaxInclusive,
            TrialPeriodDays = subscription.TrialPeriodDays,
            CancellationComment = subscription.CancellationComment,
            CancellationFeedback = subscription.CancellationFeedback,
            CancelledAt = subscription.CancelledAt,
            CustomFieldResponses = subscription.CustomFieldResponses,
            CustomerBusinessName = subscription.CustomerBusinessName,
            DiscountCyclesRemaining = subscription.DiscountCyclesRemaining,
            DiscountID = subscription.DiscountID,
            Discounts = subscription.Discounts,
            ExpiresAt = subscription.ExpiresAt,
            PaymentMethodID = subscription.PaymentMethodID,
            ScheduledChange = subscription.ScheduledChange,
            TaxID = subscription.TaxID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Addons)
        {
            item.Validate();
        }
        this.Billing.Validate();
        _ = this.BrandID;
        _ = this.CancelAtNextBillingDate;
        _ = this.CreatedAt;
        foreach (var item in this.CreditEntitlementCart)
        {
            item.Validate();
        }
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.Metadata;
        foreach (var item in this.MeterCreditEntitlementCart)
        {
            item.Validate();
        }
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        _ = this.NextBillingDate;
        _ = this.OnDemand;
        _ = this.PaymentFrequencyCount;
        this.PaymentFrequencyInterval.Validate();
        _ = this.PreviousBillingDate;
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.RecurringPreTaxAmount;
        this.Status.Validate();
        _ = this.SubscriptionID;
        _ = this.SubscriptionPeriodCount;
        this.SubscriptionPeriodInterval.Validate();
        _ = this.TaxInclusive;
        _ = this.TrialPeriodDays;
        _ = this.CancellationComment;
        this.CancellationFeedback?.Validate();
        _ = this.CancelledAt;
        foreach (var item in this.CustomFieldResponses ?? [])
        {
            item.Validate();
        }
        _ = this.CustomerBusinessName;
        _ = this.DiscountCyclesRemaining;
        _ = this.DiscountID;
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.ExpiresAt;
        _ = this.PaymentMethodID;
        this.ScheduledChange?.Validate();
        _ = this.TaxID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("Subscription")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public Subscription()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("Subscription");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("Subscription");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Refund, RefundFromRaw>))]
public sealed record class Refund : JsonModel
{
    /// <summary>
    /// Brand id this refund belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// The unique identifier of the business issuing the refund.
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
    /// The timestamp of when the refund was created in UTC.
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

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_partial");
        }
        init { this._rawData.Set("is_partial", value); }
    }

    /// <summary>
    /// Additional metadata stored with the refund.
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
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("refund_id");
        }
        init { this._rawData.Set("refund_id", value); }
    }

    public required ApiEnum<string, Refunds::RefundStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Refunds::RefundStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Refunds::Refund(Refund refund) =>
        new()
        {
            BrandID = refund.BrandID,
            BusinessID = refund.BusinessID,
            CreatedAt = refund.CreatedAt,
            Customer = refund.Customer,
            IsPartial = refund.IsPartial,
            Metadata = refund.Metadata,
            PaymentID = refund.PaymentID,
            RefundID = refund.RefundID,
            Status = refund.Status,
            Amount = refund.Amount,
            Currency = refund.Currency,
            Reason = refund.Reason,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Customer.Validate();
        _ = this.IsPartial;
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
        if (!JsonElement.DeepEquals(this.PayloadType, JsonSerializer.SerializeToElement("Refund")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public Refund()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("Refund");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Refund(Refund refund)
        : base(refund) { }
#pragma warning restore CS8618

    public Refund(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("Refund");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Refund(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFromRaw.FromRawUnchecked"/>
    public static Refund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFromRaw : IFromRawJson<Refund>
{
    /// <inheritdoc/>
    public Refund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Refund.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Dispute, DisputeFromRaw>))]
public sealed record class Dispute : JsonModel
{
    /// <summary>
    /// The amount involved in the dispute, represented as a string to accommodate precision.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Brand id this dispute belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// The unique identifier of the business involved in the dispute.
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
    /// The timestamp of when the dispute was created, in UTC.
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
    /// The currency of the disputed amount, represented as an ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payments::CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// The unique identifier of the dispute.
    /// </summary>
    public required string DisputeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dispute_id");
        }
        init { this._rawData.Set("dispute_id", value); }
    }

    public required ApiEnum<string, Disputes::DisputeDisputeStage> DisputeStage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Disputes::DisputeDisputeStage>>(
                "dispute_stage"
            );
        }
        init { this._rawData.Set("dispute_stage", value); }
    }

    public required ApiEnum<string, Disputes::DisputeDisputeStatus> DisputeStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Disputes::DisputeDisputeStatus>>(
                "dispute_status"
            );
        }
        init { this._rawData.Set("dispute_status", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the dispute.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Which processor handled the underlying payment. `stripe` / `adyen` for BYOP
    /// routes (the merchant's own Hyperswitch connector); `dodo` for everything
    /// Dodo processed itself.
    /// </summary>
    public required ApiEnum<string, Disputes::PaymentProvider> PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Disputes::PaymentProvider>>(
                "payment_provider"
            );
        }
        init { this._rawData.Set("payment_provider", value); }
    }

    /// <summary>
    /// Whether the dispute was resolved by Rapid Dispute Resolution
    /// </summary>
    public bool? IsResolvedByRdr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_resolved_by_rdr");
        }
        init { this._rawData.Set("is_resolved_by_rdr", value); }
    }

    /// <summary>
    /// Reason for the dispute
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Remarks
    /// </summary>
    public string? Remarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("remarks");
        }
        init { this._rawData.Set("remarks", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Disputes::GetDispute(Dispute dispute) =>
        new()
        {
            Amount = dispute.Amount,
            BrandID = dispute.BrandID,
            BusinessID = dispute.BusinessID,
            CreatedAt = dispute.CreatedAt,
            Currency = dispute.Currency,
            Customer = dispute.Customer,
            DisputeID = dispute.DisputeID,
            DisputeStage = dispute.DisputeStage,
            DisputeStatus = dispute.DisputeStatus,
            PaymentID = dispute.PaymentID,
            PaymentProvider = dispute.PaymentProvider,
            IsResolvedByRdr = dispute.IsResolvedByRdr,
            Reason = dispute.Reason,
            Remarks = dispute.Remarks,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        this.PaymentProvider.Validate();
        _ = this.IsResolvedByRdr;
        _ = this.Reason;
        _ = this.Remarks;
        if (!JsonElement.DeepEquals(this.PayloadType, JsonSerializer.SerializeToElement("Dispute")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public Dispute()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("Dispute");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dispute(Dispute dispute)
        : base(dispute) { }
#pragma warning restore CS8618

    public Dispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("Dispute");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dispute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeFromRaw.FromRawUnchecked"/>
    public static Dispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeFromRaw : IFromRawJson<Dispute>
{
    /// <inheritdoc/>
    public Dispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dispute.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LicenseKey, LicenseKeyFromRaw>))]
public sealed record class LicenseKey : JsonModel
{
    /// <summary>
    /// The unique identifier of the license key.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Brand id this license key belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the license key.
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
    /// The timestamp indicating when the license key was created, in UTC.
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
    /// The unique identifier of the customer associated with the license key.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// The current number of instances activated for this license key.
    /// </summary>
    public required int InstancesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("instances_count");
        }
        init { this._rawData.Set("instances_count", value); }
    }

    /// <summary>
    /// The license key string.
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// The unique identifier of the product associated with the license key.
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
    /// The source of the license key - 'auto' for keys generated by payment/subscription
    /// flows, 'import' for merchant-imported keys.
    /// </summary>
    public required ApiEnum<string, LicenseKeys::LicenseKeySource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LicenseKeys::LicenseKeySource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    public required ApiEnum<string, LicenseKeys::LicenseKeyStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LicenseKeys::LicenseKeyStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The maximum number of activations allowed for this license key.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key expires, in UTC.
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
    /// The unique identifier of the payment associated with the license key, if any.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription associated with the license key,
    /// if any.
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator LicenseKeys::LicenseKey(LicenseKey licenseKey) =>
        new()
        {
            ID = licenseKey.ID,
            BrandID = licenseKey.BrandID,
            BusinessID = licenseKey.BusinessID,
            CreatedAt = licenseKey.CreatedAt,
            CustomerID = licenseKey.CustomerID,
            InstancesCount = licenseKey.InstancesCount,
            Key = licenseKey.Key,
            ProductID = licenseKey.ProductID,
            Source = licenseKey.Source,
            Status = licenseKey.Status,
            ActivationsLimit = licenseKey.ActivationsLimit,
            ExpiresAt = licenseKey.ExpiresAt,
            PaymentID = licenseKey.PaymentID,
            SubscriptionID = licenseKey.SubscriptionID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.InstancesCount;
        _ = this.Key;
        _ = this.ProductID;
        this.Source.Validate();
        this.Status.Validate();
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
        _ = this.PaymentID;
        _ = this.SubscriptionID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("LicenseKey")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public LicenseKey()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("LicenseKey");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKey(LicenseKey licenseKey)
        : base(licenseKey) { }
#pragma warning restore CS8618

    public LicenseKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("LicenseKey");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyFromRaw.FromRawUnchecked"/>
    public static LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyFromRaw : IFromRawJson<LicenseKey>
{
    /// <inheritdoc/>
    public LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Response for a ledger entry
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditLedgerEntry, CreditLedgerEntryFromRaw>))]
public sealed record class CreditLedgerEntry : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string BalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance_after");
        }
        init { this._rawData.Set("balance_after", value); }
    }

    public required string BalanceBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance_before");
        }
        init { this._rawData.Set("balance_before", value); }
    }

    /// <summary>
    /// Brand id this credit ledger entry belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required bool IsCredit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_credit");
        }
        init { this._rawData.Set("is_credit", value); }
    }

    public required string OverageAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_after");
        }
        init { this._rawData.Set("overage_after", value); }
    }

    public required string OverageBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_before");
        }
        init { this._rawData.Set("overage_before", value); }
    }

    public required ApiEnum<string, Balances::TransactionType> TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Balances::TransactionType>>(
                "transaction_type"
            );
        }
        init { this._rawData.Set("transaction_type", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? GrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grant_id");
        }
        init { this._rawData.Set("grant_id", value); }
    }

    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    public string? ReferenceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_type");
        }
        init { this._rawData.Set("reference_type", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Balances::CreditLedgerEntry(
        CreditLedgerEntry creditLedgerEntry
    ) =>
        new()
        {
            ID = creditLedgerEntry.ID,
            Amount = creditLedgerEntry.Amount,
            BalanceAfter = creditLedgerEntry.BalanceAfter,
            BalanceBefore = creditLedgerEntry.BalanceBefore,
            BrandID = creditLedgerEntry.BrandID,
            BusinessID = creditLedgerEntry.BusinessID,
            CreatedAt = creditLedgerEntry.CreatedAt,
            CreditEntitlementID = creditLedgerEntry.CreditEntitlementID,
            CustomerID = creditLedgerEntry.CustomerID,
            IsCredit = creditLedgerEntry.IsCredit,
            OverageAfter = creditLedgerEntry.OverageAfter,
            OverageBefore = creditLedgerEntry.OverageBefore,
            TransactionType = creditLedgerEntry.TransactionType,
            Description = creditLedgerEntry.Description,
            GrantID = creditLedgerEntry.GrantID,
            ReferenceID = creditLedgerEntry.ReferenceID,
            ReferenceType = creditLedgerEntry.ReferenceType,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.BalanceAfter;
        _ = this.BalanceBefore;
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CreditEntitlementID;
        _ = this.CustomerID;
        _ = this.IsCredit;
        _ = this.OverageAfter;
        _ = this.OverageBefore;
        this.TransactionType.Validate();
        _ = this.Description;
        _ = this.GrantID;
        _ = this.ReferenceID;
        _ = this.ReferenceType;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("CreditLedgerEntry")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public CreditLedgerEntry()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("CreditLedgerEntry");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditLedgerEntry(CreditLedgerEntry creditLedgerEntry)
        : base(creditLedgerEntry) { }
#pragma warning restore CS8618

    public CreditLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("CreditLedgerEntry");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditLedgerEntryFromRaw.FromRawUnchecked"/>
    public static CreditLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditLedgerEntryFromRaw : IFromRawJson<CreditLedgerEntry>
{
    /// <inheritdoc/>
    public CreditLedgerEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CreditBalanceLow, CreditBalanceLowFromRaw>))]
public sealed record class CreditBalanceLow : JsonModel
{
    public required string AvailableBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("available_balance");
        }
        init { this._rawData.Set("available_balance", value); }
    }

    /// <summary>
    /// Brand id this credit entitlement belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

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

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public required string SubscriptionCreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_credits_amount");
        }
        init { this._rawData.Set("subscription_credits_amount", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public required string ThresholdAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("threshold_amount");
        }
        init { this._rawData.Set("threshold_amount", value); }
    }

    public required int ThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("threshold_percent");
        }
        init { this._rawData.Set("threshold_percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvailableBalance;
        _ = this.BrandID;
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.CustomerID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("CreditBalanceLow")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        _ = this.SubscriptionCreditsAmount;
        _ = this.SubscriptionID;
        _ = this.ThresholdAmount;
        _ = this.ThresholdPercent;
    }

    public CreditBalanceLow()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("CreditBalanceLow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBalanceLow(CreditBalanceLow creditBalanceLow)
        : base(creditBalanceLow) { }
#pragma warning restore CS8618

    public CreditBalanceLow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("CreditBalanceLow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBalanceLow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBalanceLowFromRaw.FromRawUnchecked"/>
    public static CreditBalanceLow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBalanceLowFromRaw : IFromRawJson<CreditBalanceLow>
{
    /// <inheritdoc/>
    public CreditBalanceLow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditBalanceLow.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AbandonedCheckout, AbandonedCheckoutFromRaw>))]
public sealed record class AbandonedCheckout : JsonModel
{
    public required DateTimeOffset AbandonedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("abandoned_at");
        }
        init { this._rawData.Set("abandoned_at", value); }
    }

    public required ApiEnum<string, AbandonmentReason> AbandonmentReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AbandonmentReason>>(
                "abandonment_reason"
            );
        }
        init { this._rawData.Set("abandonment_reason", value); }
    }

    /// <summary>
    /// Brand id this abandoned checkout belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? RecoveredPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recovered_payment_id");
        }
        init { this._rawData.Set("recovered_payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AbandonedAt;
        this.AbandonmentReason.Validate();
        _ = this.BrandID;
        _ = this.CustomerID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("AbandonedCheckout")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        _ = this.PaymentID;
        this.Status.Validate();
        _ = this.RecoveredPaymentID;
    }

    public AbandonedCheckout()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("AbandonedCheckout");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AbandonedCheckout(AbandonedCheckout abandonedCheckout)
        : base(abandonedCheckout) { }
#pragma warning restore CS8618

    public AbandonedCheckout(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("AbandonedCheckout");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AbandonedCheckout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbandonedCheckoutFromRaw.FromRawUnchecked"/>
    public static AbandonedCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbandonedCheckoutFromRaw : IFromRawJson<AbandonedCheckout>
{
    /// <inheritdoc/>
    public AbandonedCheckout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AbandonedCheckout.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AbandonmentReasonConverter))]
public enum AbandonmentReason
{
    PaymentFailed,
    CheckoutIncomplete,
}

sealed class AbandonmentReasonConverter : JsonConverter<AbandonmentReason>
{
    public override AbandonmentReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_failed" => AbandonmentReason.PaymentFailed,
            "checkout_incomplete" => AbandonmentReason.CheckoutIncomplete,
            _ => (AbandonmentReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AbandonmentReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AbandonmentReason.PaymentFailed => "payment_failed",
                AbandonmentReason.CheckoutIncomplete => "checkout_incomplete",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Abandoned,
    Recovering,
    Recovered,
    Exhausted,
    OptedOut,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "abandoned" => Status.Abandoned,
            "recovering" => Status.Recovering,
            "recovered" => Status.Recovered,
            "exhausted" => Status.Exhausted,
            "opted_out" => Status.OptedOut,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Abandoned => "abandoned",
                Status.Recovering => "recovering",
                Status.Recovered => "recovered",
                Status.Exhausted => "exhausted",
                Status.OptedOut => "opted_out",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<DunningAttempt, DunningAttemptFromRaw>))]
public sealed record class DunningAttempt : JsonModel
{
    /// <summary>
    /// Brand id this dunning attempt belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public required ApiEnum<string, DunningAttemptStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DunningAttemptStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public required ApiEnum<string, TriggerState> TriggerState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TriggerState>>("trigger_state");
        }
        init { this._rawData.Set("trigger_state", value); }
    }

    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("DunningAttempt")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        this.Status.Validate();
        _ = this.SubscriptionID;
        this.TriggerState.Validate();
        _ = this.PaymentID;
    }

    public DunningAttempt()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("DunningAttempt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DunningAttempt(DunningAttempt dunningAttempt)
        : base(dunningAttempt) { }
#pragma warning restore CS8618

    public DunningAttempt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("DunningAttempt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DunningAttempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningAttemptFromRaw.FromRawUnchecked"/>
    public static DunningAttempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DunningAttemptFromRaw : IFromRawJson<DunningAttempt>
{
    /// <inheritdoc/>
    public DunningAttempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DunningAttempt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DunningAttemptStatusConverter))]
public enum DunningAttemptStatus
{
    Recovering,
    Recovered,
    Exhausted,
}

sealed class DunningAttemptStatusConverter : JsonConverter<DunningAttemptStatus>
{
    public override DunningAttemptStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recovering" => DunningAttemptStatus.Recovering,
            "recovered" => DunningAttemptStatus.Recovered,
            "exhausted" => DunningAttemptStatus.Exhausted,
            _ => (DunningAttemptStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DunningAttemptStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DunningAttemptStatus.Recovering => "recovering",
                DunningAttemptStatus.Recovered => "recovered",
                DunningAttemptStatus.Exhausted => "exhausted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TriggerStateConverter))]
public enum TriggerState
{
    OnHold,
    Cancelled,
}

sealed class TriggerStateConverter : JsonConverter<TriggerState>
{
    public override TriggerState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "on_hold" => TriggerState.OnHold,
            "cancelled" => TriggerState.Cancelled,
            _ => (TriggerState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TriggerState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TriggerState.OnHold => "on_hold",
                TriggerState.Cancelled => "cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Detailed view of a single entitlement grant: who it's for, its lifecycle state,
/// and any integration-specific delivery payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntitlementGrant, EntitlementGrantFromRaw>))]
public sealed record class EntitlementGrant : JsonModel
{
    /// <summary>
    /// Unique identifier of the grant.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Brand id this grant belongs to.
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Identifier of the business that owns the grant.
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
    /// Timestamp when the grant was created.
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
    /// Identifier of the customer the grant was issued to.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// Identifier of the entitlement this grant was issued from.
    /// </summary>
    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_id");
        }
        init { this._rawData.Set("entitlement_id", value); }
    }

    public required ApiEnum<string, EntitlementIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementIntegrationType>>(
                "integration_type"
            );
        }
        init { this._rawData.Set("integration_type", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata recorded on the grant.
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
    /// Lifecycle status of the grant.
    /// </summary>
    public required ApiEnum<string, Grants::EntitlementGrantStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Grants::EntitlementGrantStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp when the grant was last modified.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Timestamp when the grant transitioned to `delivered`, when applicable.
    /// </summary>
    public DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("delivered_at");
        }
        init { this._rawData.Set("delivered_at", value); }
    }

    /// <summary>
    /// Digital-product-delivery payload, present on grants for `digital_files` entitlements.
    /// Each file carries a short-lived presigned download URL.
    /// </summary>
    public ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("digital_product_delivery", value);
        }
    }

    /// <summary>
    /// Machine-readable code reported when delivery failed, when applicable.
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// Human-readable message reported when delivery failed, when applicable.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// License-key delivery payload, present on grants for `license_key` entitlements.
    /// The grant's top-level `status` is the source of truth for the grant's lifecycle.
    /// </summary>
    public Grants::LicenseKeyGrant? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Grants::LicenseKeyGrant>("license_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("license_key", value);
        }
    }

    /// <summary>
    /// Timestamp when `oauth_url` stops being valid, when applicable.
    /// </summary>
    public DateTimeOffset? OAuthExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("oauth_expires_at");
        }
        init { this._rawData.Set("oauth_expires_at", value); }
    }

    /// <summary>
    /// Customer-facing OAuth URL for OAuth-style integrations. Populated during
    /// the customer-portal accept flow; `null` until the customer completes that
    /// step, and on grants for non-OAuth integrations.
    /// </summary>
    public string? OAuthUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("oauth_url");
        }
        init { this._rawData.Set("oauth_url", value); }
    }

    /// <summary>
    /// Identifier of the payment that triggered this grant, when applicable.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Reason recorded when the grant was revoked, when applicable.
    /// </summary>
    public string? RevocationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("revocation_reason");
        }
        init { this._rawData.Set("revocation_reason", value); }
    }

    /// <summary>
    /// Timestamp when the grant transitioned to `revoked`, when applicable.
    /// </summary>
    public DateTimeOffset? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("revoked_at");
        }
        init { this._rawData.Set("revoked_at", value); }
    }

    /// <summary>
    /// Identifier of the subscription that triggered this grant, when applicable.
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public JsonElement PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Grants::EntitlementGrant(EntitlementGrant entitlementGrant) =>
        new()
        {
            ID = entitlementGrant.ID,
            BrandID = entitlementGrant.BrandID,
            BusinessID = entitlementGrant.BusinessID,
            CreatedAt = entitlementGrant.CreatedAt,
            CustomerID = entitlementGrant.CustomerID,
            EntitlementID = entitlementGrant.EntitlementID,
            IntegrationType = entitlementGrant.IntegrationType,
            Metadata = entitlementGrant.Metadata,
            Status = entitlementGrant.Status,
            UpdatedAt = entitlementGrant.UpdatedAt,
            DeliveredAt = entitlementGrant.DeliveredAt,
            DigitalProductDelivery = entitlementGrant.DigitalProductDelivery,
            ErrorCode = entitlementGrant.ErrorCode,
            ErrorMessage = entitlementGrant.ErrorMessage,
            LicenseKey = entitlementGrant.LicenseKey,
            OAuthExpiresAt = entitlementGrant.OAuthExpiresAt,
            OAuthUrl = entitlementGrant.OAuthUrl,
            PaymentID = entitlementGrant.PaymentID,
            RevocationReason = entitlementGrant.RevocationReason,
            RevokedAt = entitlementGrant.RevokedAt,
            SubscriptionID = entitlementGrant.SubscriptionID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.EntitlementID;
        this.IntegrationType.Validate();
        _ = this.Metadata;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.DeliveredAt;
        this.DigitalProductDelivery?.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        this.LicenseKey?.Validate();
        _ = this.OAuthExpiresAt;
        _ = this.OAuthUrl;
        _ = this.PaymentID;
        _ = this.RevocationReason;
        _ = this.RevokedAt;
        _ = this.SubscriptionID;
        if (
            !JsonElement.DeepEquals(
                this.PayloadType,
                JsonSerializer.SerializeToElement("EntitlementGrant")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public EntitlementGrant()
    {
        this.PayloadType = JsonSerializer.SerializeToElement("EntitlementGrant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrant(EntitlementGrant entitlementGrant)
        : base(entitlementGrant) { }
#pragma warning restore CS8618

    public EntitlementGrant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.PayloadType = JsonSerializer.SerializeToElement("EntitlementGrant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFromRaw.FromRawUnchecked"/>
    public static EntitlementGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFromRaw : IFromRawJson<EntitlementGrant>
{
    /// <inheritdoc/>
    public EntitlementGrant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntitlementGrant.FromRawUnchecked(rawData);
}
