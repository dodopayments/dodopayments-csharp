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
    typeof(ModelConverter<PaymentProcessingWebhookEvent, PaymentProcessingWebhookEventFromRaw1>)
)]
public sealed record class PaymentProcessingWebhookEvent : ModelBase
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
    public required Data9 Data
    {
        get { return ModelBase.GetNotNullClass<Data9>(this.RawData, "data"); }
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
    public required ApiEnum<string, Type9> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Type9>>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public PaymentProcessingWebhookEvent() { }

    public PaymentProcessingWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentProcessingWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentProcessingWebhookEventFromRaw1 : IFromRaw<PaymentProcessingWebhookEvent>
{
    public PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentProcessingWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<Data9, Data9FromRaw>))]
public sealed record class Data9 : ModelBase
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
    public ApiEnum<string, Data9IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Data9IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
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

    public static implicit operator Payment(Data9 data9) =>
        new()
        {
            Billing = data9.Billing,
            BrandID = data9.BrandID,
            BusinessID = data9.BusinessID,
            CreatedAt = data9.CreatedAt,
            Currency = data9.Currency,
            Customer = data9.Customer,
            DigitalProductsDelivered = data9.DigitalProductsDelivered,
            Disputes = data9.Disputes,
            Metadata = data9.Metadata,
            PaymentID = data9.PaymentID,
            Refunds = data9.Refunds,
            SettlementAmount = data9.SettlementAmount,
            SettlementCurrency = data9.SettlementCurrency,
            TotalAmount = data9.TotalAmount,
            CardIssuingCountry = data9.CardIssuingCountry,
            CardLastFour = data9.CardLastFour,
            CardNetwork = data9.CardNetwork,
            CardType = data9.CardType,
            CheckoutSessionID = data9.CheckoutSessionID,
            DiscountID = data9.DiscountID,
            ErrorCode = data9.ErrorCode,
            ErrorMessage = data9.ErrorMessage,
            PaymentLink = data9.PaymentLink,
            PaymentMethod = data9.PaymentMethod,
            PaymentMethodType = data9.PaymentMethodType,
            ProductCart = data9.ProductCart,
            SettlementTax = data9.SettlementTax,
            Status = data9.Status,
            SubscriptionID = data9.SubscriptionID,
            Tax = data9.Tax,
            UpdatedAt = data9.UpdatedAt,
        };

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

    public Data9() { }

    public Data9(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data9(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Data9 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data9FromRaw : IFromRaw<Data9>
{
    public Data9 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data9.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data9IntersectionMember1, Data9IntersectionMember1FromRaw>))]
public sealed record class Data9IntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data9IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Data9IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
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

    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public Data9IntersectionMember1() { }

    public Data9IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data9IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Data9IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data9IntersectionMember1FromRaw : IFromRaw<Data9IntersectionMember1>
{
    public Data9IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Data9IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(Data9IntersectionMember1PayloadTypeConverter))]
public enum Data9IntersectionMember1PayloadType
{
    Payment,
}

sealed class Data9IntersectionMember1PayloadTypeConverter
    : JsonConverter<Data9IntersectionMember1PayloadType>
{
    public override Data9IntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Payment" => Data9IntersectionMember1PayloadType.Payment,
            _ => (Data9IntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Data9IntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Data9IntersectionMember1PayloadType.Payment => "Payment",
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
[JsonConverter(typeof(Type9Converter))]
public enum Type9
{
    PaymentProcessing,
}

sealed class Type9Converter : JsonConverter<Type9>
{
    public override Type9 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.processing" => Type9.PaymentProcessing,
            _ => (Type9)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type9 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type9.PaymentProcessing => "payment.processing",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
