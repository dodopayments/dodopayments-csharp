using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PaymentSucceededWebhookEvent, PaymentSucceededWebhookEventFromRaw>)
)]
public sealed record class PaymentSucceededWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required PaymentSucceededWebhookEventData Data
    {
        get
        {
            return JsonModel.GetNotNullClass<PaymentSucceededWebhookEventData>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, PaymentSucceededWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, PaymentSucceededWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public PaymentSucceededWebhookEvent() { }

    public PaymentSucceededWebhookEvent(PaymentSucceededWebhookEvent paymentSucceededWebhookEvent)
        : base(paymentSucceededWebhookEvent) { }

    public PaymentSucceededWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSucceededWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSucceededWebhookEventFromRaw.FromRawUnchecked"/>
    public static PaymentSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSucceededWebhookEventFromRaw : IFromRawJson<PaymentSucceededWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentSucceededWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PaymentSucceededWebhookEventData,
        PaymentSucceededWebhookEventDataFromRaw
    >)
)]
public sealed record class PaymentSucceededWebhookEventData : JsonModel
{
    public required BillingAddress Billing
    {
        get { return JsonModel.GetNotNullClass<BillingAddress>(this.RawData, "billing"); }
        init { JsonModel.Set(this._rawData, "billing", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required string BrandID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { JsonModel.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// Identifier of the business associated with the payment
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Timestamp when the payment was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required bool DigitalProductsDelivered
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "digital_products_delivered"); }
        init { JsonModel.Set(this._rawData, "digital_products_delivered", value); }
    }

    /// <summary>
    /// List of disputes associated with this payment
    /// </summary>
    public required IReadOnlyList<Dispute> Disputes
    {
        get { return JsonModel.GetNotNullClass<List<Dispute>>(this.RawData, "disputes"); }
        init { JsonModel.Set(this._rawData, "disputes", value); }
    }

    /// <summary>
    /// Additional custom data associated with the payment
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Unique identifier for the payment
    /// </summary>
    public required string PaymentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// List of refunds issued for this payment
    /// </summary>
    public required IReadOnlyList<Refund> Refunds
    {
        get { return JsonModel.GetNotNullClass<List<Refund>>(this.RawData, "refunds"); }
        init { JsonModel.Set(this._rawData, "refunds", value); }
    }

    /// <summary>
    /// The amount that will be credited to your Dodo balance after currency conversion
    /// and processing. Especially relevant for adaptive pricing where the customer's
    /// payment currency differs from your settlement currency.
    /// </summary>
    public required int SettlementAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "settlement_amount"); }
        init { JsonModel.Set(this._rawData, "settlement_amount", value); }
    }

    public required ApiEnum<string, Currency> SettlementCurrency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(
                this.RawData,
                "settlement_currency"
            );
        }
        init { JsonModel.Set(this._rawData, "settlement_currency", value); }
    }

    /// <summary>
    /// Total amount charged to the customer including tax, in smallest currency unit
    /// (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { JsonModel.Set(this._rawData, "total_amount", value); }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, CountryCode>>(
                this.RawData,
                "card_issuing_country"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "card_issuing_country", value);
        }
    }

    /// <summary>
    /// The last four digits of the card
    /// </summary>
    public string? CardLastFour
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "card_last_four"); }
        init { JsonModel.Set(this._rawData, "card_last_four", value); }
    }

    /// <summary>
    /// Card network like VISA, MASTERCARD etc.
    /// </summary>
    public string? CardNetwork
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "card_network"); }
        init { JsonModel.Set(this._rawData, "card_network", value); }
    }

    /// <summary>
    /// The type of card DEBIT or CREDIT
    /// </summary>
    public string? CardType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "card_type"); }
        init { JsonModel.Set(this._rawData, "card_type", value); }
    }

    /// <summary>
    /// If payment is made using a checkout session, this field is set to the id of
    /// the session.
    /// </summary>
    public string? CheckoutSessionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "checkout_session_id"); }
        init { JsonModel.Set(this._rawData, "checkout_session_id", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { JsonModel.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// An error code if the payment failed
    /// </summary>
    public string? ErrorCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "error_code"); }
        init { JsonModel.Set(this._rawData, "error_code", value); }
    }

    /// <summary>
    /// An error message if the payment failed
    /// </summary>
    public string? ErrorMessage
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "error_message"); }
        init { JsonModel.Set(this._rawData, "error_message", value); }
    }

    /// <summary>
    /// Invoice ID for this payment. Uses India-specific invoice ID if available.
    /// </summary>
    public string? InvoiceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_id"); }
        init { JsonModel.Set(this._rawData, "invoice_id", value); }
    }

    /// <summary>
    /// Checkout URL
    /// </summary>
    public string? PaymentLink
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_link"); }
        init { JsonModel.Set(this._rawData, "payment_link", value); }
    }

    /// <summary>
    /// Payment method used by customer (e.g. "card", "bank_transfer")
    /// </summary>
    public string? PaymentMethod
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_method"); }
        init { JsonModel.Set(this._rawData, "payment_method", value); }
    }

    /// <summary>
    /// Specific type of payment method (e.g. "visa", "mastercard")
    /// </summary>
    public string? PaymentMethodType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_method_type"); }
        init { JsonModel.Set(this._rawData, "payment_method_type", value); }
    }

    /// <summary>
    /// List of products purchased in a one-time payment
    /// </summary>
    public IReadOnlyList<ProductCart>? ProductCart
    {
        get { return JsonModel.GetNullableClass<List<ProductCart>>(this.RawData, "product_cart"); }
        init { JsonModel.Set(this._rawData, "product_cart", value); }
    }

    /// <summary>
    /// This represents the portion of settlement_amount that corresponds to taxes
    /// collected. Especially relevant for adaptive pricing where the tax component
    /// must be tracked separately in your Dodo balance.
    /// </summary>
    public int? SettlementTax
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "settlement_tax"); }
        init { JsonModel.Set(this._rawData, "settlement_tax", value); }
    }

    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, IntentStatus>>(
                this.RawData,
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Identifier of the subscription if payment is part of a subscription
    /// </summary>
    public string? SubscriptionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { JsonModel.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// Amount of tax collected in smallest currency unit (e.g. cents)
    /// </summary>
    public int? Tax
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "tax"); }
        init { JsonModel.Set(this._rawData, "tax", value); }
    }

    /// <summary>
    /// Timestamp when the payment was last updated
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "updated_at");
        }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        PaymentSucceededWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, PaymentSucceededWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Payment(
        PaymentSucceededWebhookEventData paymentSucceededWebhookEventData
    ) =>
        new()
        {
            Billing = paymentSucceededWebhookEventData.Billing,
            BrandID = paymentSucceededWebhookEventData.BrandID,
            BusinessID = paymentSucceededWebhookEventData.BusinessID,
            CreatedAt = paymentSucceededWebhookEventData.CreatedAt,
            Currency = paymentSucceededWebhookEventData.Currency,
            Customer = paymentSucceededWebhookEventData.Customer,
            DigitalProductsDelivered = paymentSucceededWebhookEventData.DigitalProductsDelivered,
            Disputes = paymentSucceededWebhookEventData.Disputes,
            Metadata = paymentSucceededWebhookEventData.Metadata,
            PaymentID = paymentSucceededWebhookEventData.PaymentID,
            Refunds = paymentSucceededWebhookEventData.Refunds,
            SettlementAmount = paymentSucceededWebhookEventData.SettlementAmount,
            SettlementCurrency = paymentSucceededWebhookEventData.SettlementCurrency,
            TotalAmount = paymentSucceededWebhookEventData.TotalAmount,
            CardIssuingCountry = paymentSucceededWebhookEventData.CardIssuingCountry,
            CardLastFour = paymentSucceededWebhookEventData.CardLastFour,
            CardNetwork = paymentSucceededWebhookEventData.CardNetwork,
            CardType = paymentSucceededWebhookEventData.CardType,
            CheckoutSessionID = paymentSucceededWebhookEventData.CheckoutSessionID,
            DiscountID = paymentSucceededWebhookEventData.DiscountID,
            ErrorCode = paymentSucceededWebhookEventData.ErrorCode,
            ErrorMessage = paymentSucceededWebhookEventData.ErrorMessage,
            InvoiceID = paymentSucceededWebhookEventData.InvoiceID,
            PaymentLink = paymentSucceededWebhookEventData.PaymentLink,
            PaymentMethod = paymentSucceededWebhookEventData.PaymentMethod,
            PaymentMethodType = paymentSucceededWebhookEventData.PaymentMethodType,
            ProductCart = paymentSucceededWebhookEventData.ProductCart,
            SettlementTax = paymentSucceededWebhookEventData.SettlementTax,
            Status = paymentSucceededWebhookEventData.Status,
            SubscriptionID = paymentSucceededWebhookEventData.SubscriptionID,
            Tax = paymentSucceededWebhookEventData.Tax,
            UpdatedAt = paymentSucceededWebhookEventData.UpdatedAt,
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
        this.PayloadType?.Validate();
    }

    public PaymentSucceededWebhookEventData() { }

    public PaymentSucceededWebhookEventData(
        PaymentSucceededWebhookEventData paymentSucceededWebhookEventData
    )
        : base(paymentSucceededWebhookEventData) { }

    public PaymentSucceededWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSucceededWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSucceededWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PaymentSucceededWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSucceededWebhookEventDataFromRaw : IFromRawJson<PaymentSucceededWebhookEventData>
{
    /// <inheritdoc/>
    public PaymentSucceededWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentSucceededWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PaymentSucceededWebhookEventDataIntersectionMember1,
        PaymentSucceededWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class PaymentSucceededWebhookEventDataIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        PaymentSucceededWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, PaymentSucceededWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public PaymentSucceededWebhookEventDataIntersectionMember1() { }

    public PaymentSucceededWebhookEventDataIntersectionMember1(
        PaymentSucceededWebhookEventDataIntersectionMember1 paymentSucceededWebhookEventDataIntersectionMember1
    )
        : base(paymentSucceededWebhookEventDataIntersectionMember1) { }

    public PaymentSucceededWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSucceededWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSucceededWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static PaymentSucceededWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSucceededWebhookEventDataIntersectionMember1FromRaw
    : IFromRawJson<PaymentSucceededWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public PaymentSucceededWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentSucceededWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PaymentSucceededWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum PaymentSucceededWebhookEventDataIntersectionMember1PayloadType
{
    Payment,
}

sealed class PaymentSucceededWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<PaymentSucceededWebhookEventDataIntersectionMember1PayloadType>
{
    public override PaymentSucceededWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Payment" => PaymentSucceededWebhookEventDataIntersectionMember1PayloadType.Payment,
            _ => (PaymentSucceededWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentSucceededWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentSucceededWebhookEventDataIntersectionMember1PayloadType.Payment => "Payment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(PaymentSucceededWebhookEventTypeConverter))]
public enum PaymentSucceededWebhookEventType
{
    PaymentSucceeded,
}

sealed class PaymentSucceededWebhookEventTypeConverter
    : JsonConverter<PaymentSucceededWebhookEventType>
{
    public override PaymentSucceededWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.succeeded" => PaymentSucceededWebhookEventType.PaymentSucceeded,
            _ => (PaymentSucceededWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentSucceededWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentSucceededWebhookEventType.PaymentSucceeded => "payment.succeeded",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
