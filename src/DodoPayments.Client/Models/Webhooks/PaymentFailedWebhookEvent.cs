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

[JsonConverter(typeof(ModelConverter<PaymentFailedWebhookEvent, PaymentFailedWebhookEventFromRaw>))]
public sealed record class PaymentFailedWebhookEvent : ModelBase
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required PaymentFailedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<PaymentFailedWebhookEventData>(this.RawData, "data");
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, PaymentFailedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PaymentFailedWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public PaymentFailedWebhookEvent() { }

    public PaymentFailedWebhookEvent(PaymentFailedWebhookEvent paymentFailedWebhookEvent)
        : base(paymentFailedWebhookEvent) { }

    public PaymentFailedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentFailedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static PaymentFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFailedWebhookEventFromRaw : IFromRaw<PaymentFailedWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentFailedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<PaymentFailedWebhookEventData, PaymentFailedWebhookEventDataFromRaw>)
)]
public sealed record class PaymentFailedWebhookEventData : ModelBase
{
    public required BillingAddress Billing
    {
        get { return ModelBase.GetNotNullClass<BillingAddress>(this.RawData, "billing"); }
        init { ModelBase.Set(this._rawData, "billing", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required string BrandID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// Identifier of the business associated with the payment
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Timestamp when the payment was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required bool DigitalProductsDelivered
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "digital_products_delivered"); }
        init { ModelBase.Set(this._rawData, "digital_products_delivered", value); }
    }

    /// <summary>
    /// List of disputes associated with this payment
    /// </summary>
    public required IReadOnlyList<Dispute> Disputes
    {
        get { return ModelBase.GetNotNullClass<List<Dispute>>(this.RawData, "disputes"); }
        init { ModelBase.Set(this._rawData, "disputes", value); }
    }

    /// <summary>
    /// Additional custom data associated with the payment
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Unique identifier for the payment
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// List of refunds issued for this payment
    /// </summary>
    public required IReadOnlyList<Refund> Refunds
    {
        get { return ModelBase.GetNotNullClass<List<Refund>>(this.RawData, "refunds"); }
        init { ModelBase.Set(this._rawData, "refunds", value); }
    }

    /// <summary>
    /// The amount that will be credited to your Dodo balance after currency conversion
    /// and processing. Especially relevant for adaptive pricing where the customer's
    /// payment currency differs from your settlement currency.
    /// </summary>
    public required int SettlementAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "settlement_amount"); }
        init { ModelBase.Set(this._rawData, "settlement_amount", value); }
    }

    public required ApiEnum<string, Currency> SettlementCurrency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(
                this.RawData,
                "settlement_currency"
            );
        }
        init { ModelBase.Set(this._rawData, "settlement_currency", value); }
    }

    /// <summary>
    /// Total amount charged to the customer including tax, in smallest currency unit
    /// (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { ModelBase.Set(this._rawData, "total_amount", value); }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, CountryCode>>(
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

            ModelBase.Set(this._rawData, "card_issuing_country", value);
        }
    }

    /// <summary>
    /// The last four digits of the card
    /// </summary>
    public string? CardLastFour
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "card_last_four"); }
        init { ModelBase.Set(this._rawData, "card_last_four", value); }
    }

    /// <summary>
    /// Card network like VISA, MASTERCARD etc.
    /// </summary>
    public string? CardNetwork
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "card_network"); }
        init { ModelBase.Set(this._rawData, "card_network", value); }
    }

    /// <summary>
    /// The type of card DEBIT or CREDIT
    /// </summary>
    public string? CardType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "card_type"); }
        init { ModelBase.Set(this._rawData, "card_type", value); }
    }

    /// <summary>
    /// If payment is made using a checkout session, this field is set to the id of
    /// the session.
    /// </summary>
    public string? CheckoutSessionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "checkout_session_id"); }
        init { ModelBase.Set(this._rawData, "checkout_session_id", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { ModelBase.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// An error code if the payment failed
    /// </summary>
    public string? ErrorCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "error_code"); }
        init { ModelBase.Set(this._rawData, "error_code", value); }
    }

    /// <summary>
    /// An error message if the payment failed
    /// </summary>
    public string? ErrorMessage
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "error_message"); }
        init { ModelBase.Set(this._rawData, "error_message", value); }
    }

    /// <summary>
    /// Checkout URL
    /// </summary>
    public string? PaymentLink
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_link"); }
        init { ModelBase.Set(this._rawData, "payment_link", value); }
    }

    /// <summary>
    /// Payment method used by customer (e.g. "card", "bank_transfer")
    /// </summary>
    public string? PaymentMethod
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_method"); }
        init { ModelBase.Set(this._rawData, "payment_method", value); }
    }

    /// <summary>
    /// Specific type of payment method (e.g. "visa", "mastercard")
    /// </summary>
    public string? PaymentMethodType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_method_type"); }
        init { ModelBase.Set(this._rawData, "payment_method_type", value); }
    }

    /// <summary>
    /// List of products purchased in a one-time payment
    /// </summary>
    public IReadOnlyList<ProductCart>? ProductCart
    {
        get { return ModelBase.GetNullableClass<List<ProductCart>>(this.RawData, "product_cart"); }
        init { ModelBase.Set(this._rawData, "product_cart", value); }
    }

    /// <summary>
    /// This represents the portion of settlement_amount that corresponds to taxes
    /// collected. Especially relevant for adaptive pricing where the tax component
    /// must be tracked separately in your Dodo balance.
    /// </summary>
    public int? SettlementTax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "settlement_tax"); }
        init { ModelBase.Set(this._rawData, "settlement_tax", value); }
    }

    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, IntentStatus>>(
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

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Identifier of the subscription if payment is part of a subscription
    /// </summary>
    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { ModelBase.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// Amount of tax collected in smallest currency unit (e.g. cents)
    /// </summary>
    public int? Tax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    /// <summary>
    /// Timestamp when the payment was last updated
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "updated_at");
        }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PaymentFailedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, PaymentFailedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Payment(
        PaymentFailedWebhookEventData paymentFailedWebhookEventData
    ) =>
        new()
        {
            Billing = paymentFailedWebhookEventData.Billing,
            BrandID = paymentFailedWebhookEventData.BrandID,
            BusinessID = paymentFailedWebhookEventData.BusinessID,
            CreatedAt = paymentFailedWebhookEventData.CreatedAt,
            Currency = paymentFailedWebhookEventData.Currency,
            Customer = paymentFailedWebhookEventData.Customer,
            DigitalProductsDelivered = paymentFailedWebhookEventData.DigitalProductsDelivered,
            Disputes = paymentFailedWebhookEventData.Disputes,
            Metadata = paymentFailedWebhookEventData.Metadata,
            PaymentID = paymentFailedWebhookEventData.PaymentID,
            Refunds = paymentFailedWebhookEventData.Refunds,
            SettlementAmount = paymentFailedWebhookEventData.SettlementAmount,
            SettlementCurrency = paymentFailedWebhookEventData.SettlementCurrency,
            TotalAmount = paymentFailedWebhookEventData.TotalAmount,
            CardIssuingCountry = paymentFailedWebhookEventData.CardIssuingCountry,
            CardLastFour = paymentFailedWebhookEventData.CardLastFour,
            CardNetwork = paymentFailedWebhookEventData.CardNetwork,
            CardType = paymentFailedWebhookEventData.CardType,
            CheckoutSessionID = paymentFailedWebhookEventData.CheckoutSessionID,
            DiscountID = paymentFailedWebhookEventData.DiscountID,
            ErrorCode = paymentFailedWebhookEventData.ErrorCode,
            ErrorMessage = paymentFailedWebhookEventData.ErrorMessage,
            PaymentLink = paymentFailedWebhookEventData.PaymentLink,
            PaymentMethod = paymentFailedWebhookEventData.PaymentMethod,
            PaymentMethodType = paymentFailedWebhookEventData.PaymentMethodType,
            ProductCart = paymentFailedWebhookEventData.ProductCart,
            SettlementTax = paymentFailedWebhookEventData.SettlementTax,
            Status = paymentFailedWebhookEventData.Status,
            SubscriptionID = paymentFailedWebhookEventData.SubscriptionID,
            Tax = paymentFailedWebhookEventData.Tax,
            UpdatedAt = paymentFailedWebhookEventData.UpdatedAt,
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

    public PaymentFailedWebhookEventData() { }

    public PaymentFailedWebhookEventData(
        PaymentFailedWebhookEventData paymentFailedWebhookEventData
    )
        : base(paymentFailedWebhookEventData) { }

    public PaymentFailedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentFailedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFailedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PaymentFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFailedWebhookEventDataFromRaw : IFromRaw<PaymentFailedWebhookEventData>
{
    /// <inheritdoc/>
    public PaymentFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentFailedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        PaymentFailedWebhookEventDataIntersectionMember1,
        PaymentFailedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class PaymentFailedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PaymentFailedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, PaymentFailedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public PaymentFailedWebhookEventDataIntersectionMember1() { }

    public PaymentFailedWebhookEventDataIntersectionMember1(
        PaymentFailedWebhookEventDataIntersectionMember1 paymentFailedWebhookEventDataIntersectionMember1
    )
        : base(paymentFailedWebhookEventDataIntersectionMember1) { }

    public PaymentFailedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentFailedWebhookEventDataIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFailedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static PaymentFailedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFailedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<PaymentFailedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public PaymentFailedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentFailedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PaymentFailedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum PaymentFailedWebhookEventDataIntersectionMember1PayloadType
{
    Payment,
}

sealed class PaymentFailedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<PaymentFailedWebhookEventDataIntersectionMember1PayloadType>
{
    public override PaymentFailedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Payment" => PaymentFailedWebhookEventDataIntersectionMember1PayloadType.Payment,
            _ => (PaymentFailedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentFailedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentFailedWebhookEventDataIntersectionMember1PayloadType.Payment => "Payment",
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
[JsonConverter(typeof(PaymentFailedWebhookEventTypeConverter))]
public enum PaymentFailedWebhookEventType
{
    PaymentFailed,
}

sealed class PaymentFailedWebhookEventTypeConverter : JsonConverter<PaymentFailedWebhookEventType>
{
    public override PaymentFailedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.failed" => PaymentFailedWebhookEventType.PaymentFailed,
            _ => (PaymentFailedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentFailedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentFailedWebhookEventType.PaymentFailed => "payment.failed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
