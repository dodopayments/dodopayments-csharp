using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Disputes = DodoPayments.Client.Models.Disputes;
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

    public WebhookPayload(WebhookPayload webhookPayload)
        : base(webhookPayload) { }

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
                licenseKey: (_) => null
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
                licenseKey: (x) => x.BusinessID
            );
        }
    }

    public DateTimeOffset CreatedAt
    {
        get
        {
            return Match(
                payment: (x) => x.CreatedAt,
                subscription: (x) => x.CreatedAt,
                refund: (x) => x.CreatedAt,
                dispute: (x) => x.CreatedAt,
                licenseKey: (x) => x.CreatedAt
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
                licenseKey: (_) => null
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
                licenseKey: (x) => x.PaymentID
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
                licenseKey: (_) => null
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
                licenseKey: (x) => x.SubscriptionID
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
                licenseKey: (x) => x.ProductID
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
                licenseKey: (x) => x.ExpiresAt
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
                licenseKey: (_) => null
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

    public Data(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Payment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (Payment value) => {...},
    ///     (Subscription value) => {...},
    ///     (Refund value) => {...},
    ///     (Dispute value) => {...},
    ///     (LicenseKey value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Payment> payment,
        Action<Subscription> subscription,
        Action<Refund> refund,
        Action<Dispute> dispute,
        Action<LicenseKey> licenseKey
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (Payment value) => {...},
    ///     (Subscription value) => {...},
    ///     (Refund value) => {...},
    ///     (Dispute value) => {...},
    ///     (LicenseKey value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Payment, T> payment,
        Func<Subscription, T> subscription,
        Func<Refund, T> refund,
        Func<Dispute, T> dispute,
        Func<LicenseKey, T> licenseKey
    )
    {
        return this.Value switch
        {
            Payment value => payment(value),
            Subscription value => subscription(value),
            Refund value => refund(value),
            Dispute value => dispute(value),
            LicenseKey value => licenseKey(value),
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
            (licenseKey) => licenseKey.Validate()
        );
    }

    public virtual bool Equals(Data? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
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
        try
        {
            var deserialized = JsonSerializer.Deserialize<Payment>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Subscription>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Refund>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dispute>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LicenseKey>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
    /// List of refunds issued for this payment
    /// </summary>
    public required IReadOnlyList<Payments::Refund> Refunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Payments::Refund>>("refunds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payments::Refund>>(
                "refunds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Total amount charged to the customer including tax, in smallest currency unit
    /// (e.g. cents)
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
    /// The discount id if discount is applied
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
    /// Amount of tax collected in smallest currency unit (e.g. cents)
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

    public required ApiEnum<string, PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PayloadType>>("payload_type");
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
            Refunds = payment.Refunds,
            SettlementAmount = payment.SettlementAmount,
            SettlementCurrency = payment.SettlementCurrency,
            TotalAmount = payment.TotalAmount,
            CardHolderName = payment.CardHolderName,
            CardIssuingCountry = payment.CardIssuingCountry,
            CardLastFour = payment.CardLastFour,
            CardNetwork = payment.CardNetwork,
            CardType = payment.CardType,
            CheckoutSessionID = payment.CheckoutSessionID,
            DiscountID = payment.DiscountID,
            ErrorCode = payment.ErrorCode,
            ErrorMessage = payment.ErrorMessage,
            InvoiceID = payment.InvoiceID,
            PaymentLink = payment.PaymentLink,
            PaymentMethod = payment.PaymentMethod,
            PaymentMethodType = payment.PaymentMethodType,
            ProductCart = payment.ProductCart,
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
        foreach (var item in this.Refunds)
        {
            item.Validate();
        }
        _ = this.SettlementAmount;
        this.SettlementCurrency.Validate();
        _ = this.TotalAmount;
        _ = this.CardHolderName;
        this.CardIssuingCountry?.Validate();
        _ = this.CardLastFour;
        _ = this.CardNetwork;
        _ = this.CardType;
        _ = this.CheckoutSessionID;
        _ = this.DiscountID;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.InvoiceID;
        _ = this.PaymentLink;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodType;
        foreach (var item in this.ProductCart ?? [])
        {
            item.Validate();
        }
        _ = this.SettlementTax;
        this.Status?.Validate();
        _ = this.SubscriptionID;
        _ = this.Tax;
        _ = this.UpdatedAt;
        this.PayloadType.Validate();
    }

    public Payment() { }

    public Payment(Payment payment)
        : base(payment) { }

    public Payment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public required ApiEnum<string, PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PayloadType>>("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public IntersectionMember1() { }

    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(ApiEnum<string, PayloadType> payloadType)
        : this()
    {
        this.PayloadType = payloadType;
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayloadTypeConverter))]
public enum PayloadType
{
    Payment,
}

sealed class PayloadTypeConverter : JsonConverter<PayloadType>
{
    public override PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Payment" => PayloadType.Payment,
            _ => (PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayloadType.Payment => "Payment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required IReadOnlyList<Subscriptions::Meter> Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Subscriptions::Meter>>("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::Meter>>(
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
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
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
    /// Number of remaining discount cycles if discount is applied
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
    /// The discount id if discount is applied
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

    public required ApiEnum<string, SubscriptionIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Subscriptions::Subscription(Subscription subscription) =>
        new()
        {
            Addons = subscription.Addons,
            Billing = subscription.Billing,
            CancelAtNextBillingDate = subscription.CancelAtNextBillingDate,
            CreatedAt = subscription.CreatedAt,
            Currency = subscription.Currency,
            Customer = subscription.Customer,
            Metadata = subscription.Metadata,
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
            CancelledAt = subscription.CancelledAt,
            DiscountCyclesRemaining = subscription.DiscountCyclesRemaining,
            DiscountID = subscription.DiscountID,
            ExpiresAt = subscription.ExpiresAt,
            PaymentMethodID = subscription.PaymentMethodID,
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
        _ = this.CancelAtNextBillingDate;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.Metadata;
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
        _ = this.CancelledAt;
        _ = this.DiscountCyclesRemaining;
        _ = this.DiscountID;
        _ = this.ExpiresAt;
        _ = this.PaymentMethodID;
        _ = this.TaxID;
        this.PayloadType.Validate();
    }

    public Subscription() { }

    public Subscription(Subscription subscription)
        : base(subscription) { }

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionIntersectionMember1,
        SubscriptionIntersectionMember1FromRaw
    >)
)]
public sealed record class SubscriptionIntersectionMember1 : JsonModel
{
    public required ApiEnum<string, SubscriptionIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public SubscriptionIntersectionMember1() { }

    public SubscriptionIntersectionMember1(
        SubscriptionIntersectionMember1 subscriptionIntersectionMember1
    )
        : base(subscriptionIntersectionMember1) { }

    public SubscriptionIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static SubscriptionIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionIntersectionMember1(
        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> payloadType
    )
        : this()
    {
        this.PayloadType = payloadType;
    }
}

class SubscriptionIntersectionMember1FromRaw : IFromRawJson<SubscriptionIntersectionMember1>
{
    /// <inheritdoc/>
    public SubscriptionIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubscriptionIntersectionMember1PayloadTypeConverter))]
public enum SubscriptionIntersectionMember1PayloadType
{
    Subscription,
}

sealed class SubscriptionIntersectionMember1PayloadTypeConverter
    : JsonConverter<SubscriptionIntersectionMember1PayloadType>
{
    public override SubscriptionIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Subscription" => SubscriptionIntersectionMember1PayloadType.Subscription,
            _ => (SubscriptionIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionIntersectionMember1PayloadType.Subscription => "Subscription",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Refund, RefundFromRaw>))]
public sealed record class Refund : JsonModel
{
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

    public required ApiEnum<string, RefundIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RefundIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Refunds::Refund(Refund refund) =>
        new()
        {
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
        this.PayloadType.Validate();
    }

    public Refund() { }

    public Refund(Refund refund)
        : base(refund) { }

    public Refund(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(
    typeof(JsonModelConverter<RefundIntersectionMember1, RefundIntersectionMember1FromRaw>)
)]
public sealed record class RefundIntersectionMember1 : JsonModel
{
    public required ApiEnum<string, RefundIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RefundIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public RefundIntersectionMember1() { }

    public RefundIntersectionMember1(RefundIntersectionMember1 refundIntersectionMember1)
        : base(refundIntersectionMember1) { }

    public RefundIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static RefundIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RefundIntersectionMember1(
        ApiEnum<string, RefundIntersectionMember1PayloadType> payloadType
    )
        : this()
    {
        this.PayloadType = payloadType;
    }
}

class RefundIntersectionMember1FromRaw : IFromRawJson<RefundIntersectionMember1>
{
    /// <inheritdoc/>
    public RefundIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RefundIntersectionMember1PayloadTypeConverter))]
public enum RefundIntersectionMember1PayloadType
{
    Refund,
}

sealed class RefundIntersectionMember1PayloadTypeConverter
    : JsonConverter<RefundIntersectionMember1PayloadType>
{
    public override RefundIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Refund" => RefundIntersectionMember1PayloadType.Refund,
            _ => (RefundIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundIntersectionMember1PayloadType.Refund => "Refund",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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

    public required ApiEnum<string, DisputeIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DisputeIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator Disputes::GetDispute(Dispute dispute) =>
        new()
        {
            Amount = dispute.Amount,
            BusinessID = dispute.BusinessID,
            CreatedAt = dispute.CreatedAt,
            Currency = dispute.Currency,
            Customer = dispute.Customer,
            DisputeID = dispute.DisputeID,
            DisputeStage = dispute.DisputeStage,
            DisputeStatus = dispute.DisputeStatus,
            PaymentID = dispute.PaymentID,
            Reason = dispute.Reason,
            Remarks = dispute.Remarks,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        _ = this.Reason;
        _ = this.Remarks;
        this.PayloadType.Validate();
    }

    public Dispute() { }

    public Dispute(Dispute dispute)
        : base(dispute) { }

    public Dispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(
    typeof(JsonModelConverter<DisputeIntersectionMember1, DisputeIntersectionMember1FromRaw>)
)]
public sealed record class DisputeIntersectionMember1 : JsonModel
{
    public required ApiEnum<string, DisputeIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DisputeIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public DisputeIntersectionMember1() { }

    public DisputeIntersectionMember1(DisputeIntersectionMember1 disputeIntersectionMember1)
        : base(disputeIntersectionMember1) { }

    public DisputeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DisputeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DisputeIntersectionMember1(
        ApiEnum<string, DisputeIntersectionMember1PayloadType> payloadType
    )
        : this()
    {
        this.PayloadType = payloadType;
    }
}

class DisputeIntersectionMember1FromRaw : IFromRawJson<DisputeIntersectionMember1>
{
    /// <inheritdoc/>
    public DisputeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DisputeIntersectionMember1PayloadTypeConverter))]
public enum DisputeIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DisputeIntersectionMember1PayloadTypeConverter
    : JsonConverter<DisputeIntersectionMember1PayloadType>
{
    public override DisputeIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DisputeIntersectionMember1PayloadType.Dispute,
            _ => (DisputeIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeIntersectionMember1PayloadType.Dispute => "Dispute",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
    /// The unique identifier of the payment associated with the license key.
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

    public required ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    public static implicit operator LicenseKeys::LicenseKey(LicenseKey licenseKey) =>
        new()
        {
            ID = licenseKey.ID,
            BusinessID = licenseKey.BusinessID,
            CreatedAt = licenseKey.CreatedAt,
            CustomerID = licenseKey.CustomerID,
            InstancesCount = licenseKey.InstancesCount,
            Key = licenseKey.Key,
            PaymentID = licenseKey.PaymentID,
            ProductID = licenseKey.ProductID,
            Status = licenseKey.Status,
            ActivationsLimit = licenseKey.ActivationsLimit,
            ExpiresAt = licenseKey.ExpiresAt,
            SubscriptionID = licenseKey.SubscriptionID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.InstancesCount;
        _ = this.Key;
        _ = this.PaymentID;
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
        _ = this.SubscriptionID;
        this.PayloadType.Validate();
    }

    public LicenseKey() { }

    public LicenseKey(LicenseKey licenseKey)
        : base(licenseKey) { }

    public LicenseKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(
    typeof(JsonModelConverter<LicenseKeyIntersectionMember1, LicenseKeyIntersectionMember1FromRaw>)
)]
public sealed record class LicenseKeyIntersectionMember1 : JsonModel
{
    public required ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> PayloadType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
            >("payload_type");
        }
        init { this._rawData.Set("payload_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public LicenseKeyIntersectionMember1() { }

    public LicenseKeyIntersectionMember1(
        LicenseKeyIntersectionMember1 licenseKeyIntersectionMember1
    )
        : base(licenseKeyIntersectionMember1) { }

    public LicenseKeyIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static LicenseKeyIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LicenseKeyIntersectionMember1(
        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> payloadType
    )
        : this()
    {
        this.PayloadType = payloadType;
    }
}

class LicenseKeyIntersectionMember1FromRaw : IFromRawJson<LicenseKeyIntersectionMember1>
{
    /// <inheritdoc/>
    public LicenseKeyIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LicenseKeyIntersectionMember1PayloadTypeConverter))]
public enum LicenseKeyIntersectionMember1PayloadType
{
    LicenseKey,
}

sealed class LicenseKeyIntersectionMember1PayloadTypeConverter
    : JsonConverter<LicenseKeyIntersectionMember1PayloadType>
{
    public override LicenseKeyIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LicenseKey" => LicenseKeyIntersectionMember1PayloadType.LicenseKey,
            _ => (LicenseKeyIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseKeyIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseKeyIntersectionMember1PayloadType.LicenseKey => "LicenseKey",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
