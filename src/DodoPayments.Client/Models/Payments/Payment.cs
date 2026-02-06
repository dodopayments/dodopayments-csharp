using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using Refunds = DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<Payment, PaymentFromRaw>))]
public sealed record class Payment : JsonModel
{
    /// <summary>
    /// Billing address details for payments
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillingAddress>("billing");
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

    /// <summary>
    /// Currency used for the payment
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Details about the customer who made the payment
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer");
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
    public required IReadOnlyList<Dispute> Disputes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Dispute>>("disputes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Dispute>>(
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
    public required IReadOnlyList<Refund> Refunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Refund>>("refunds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Refund>>(
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

    /// <summary>
    /// The currency in which the settlement_amount will be credited to your Dodo
    /// balance. This may differ from the customer's payment currency in adaptive
    /// pricing scenarios.
    /// </summary>
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
    /// ISO2 country code of the card
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
        init { this._rawData.Set("card_issuing_country", value); }
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
    public IReadOnlyList<CustomFieldResponse>? CustomFieldResponses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomFieldResponse>>(
                "custom_field_responses"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomFieldResponse>?>(
                "custom_field_responses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    public IReadOnlyList<ProductCart>? ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProductCart>>("product_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCart>?>(
                "product_cart",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Summary of the refund status for this payment. None if no succeeded refunds exist.
    /// </summary>
    public ApiEnum<string, RefundStatus>? RefundStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RefundStatus>>("refund_status");
        }
        init { this._rawData.Set("refund_status", value); }
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

    /// <summary>
    /// Current status of the payment intent
    /// </summary>
    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntentStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
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
        foreach (var item in this.CustomFieldResponses ?? [])
        {
            item.Validate();
        }
        _ = this.DiscountID;
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
    }

    public Payment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payment(Payment payment)
        : base(payment) { }
#pragma warning restore CS8618

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

    /// <summary>
    /// The current status of the refund.
    /// </summary>
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

    /// <summary>
    /// The currency of the refund, represented as an ISO 4217 currency code.
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsPartial;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
    }

    public Refund() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Refund(Refund refund)
        : base(refund) { }
#pragma warning restore CS8618

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

/// <summary>
/// Customer's response to a custom field
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomFieldResponse, CustomFieldResponseFromRaw>))]
public sealed record class CustomFieldResponse : JsonModel
{
    /// <summary>
    /// Key matching the custom field definition
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
    /// Value provided by customer
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public CustomFieldResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomFieldResponse(CustomFieldResponse customFieldResponse)
        : base(customFieldResponse) { }
#pragma warning restore CS8618

    public CustomFieldResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomFieldResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomFieldResponseFromRaw.FromRawUnchecked"/>
    public static CustomFieldResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomFieldResponseFromRaw : IFromRawJson<CustomFieldResponse>
{
    /// <inheritdoc/>
    public CustomFieldResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomFieldResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProductCart, ProductCartFromRaw>))]
public sealed record class ProductCart : JsonModel
{
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
    }

    public ProductCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCart(ProductCart productCart)
        : base(productCart) { }
#pragma warning restore CS8618

    public ProductCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCartFromRaw.FromRawUnchecked"/>
    public static ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCartFromRaw : IFromRawJson<ProductCart>
{
    /// <inheritdoc/>
    public ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Summary of the refund status for this payment. None if no succeeded refunds exist.
/// </summary>
[JsonConverter(typeof(RefundStatusConverter))]
public enum RefundStatus
{
    Partial,
    Full,
}

sealed class RefundStatusConverter : JsonConverter<RefundStatus>
{
    public override RefundStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "partial" => RefundStatus.Partial,
            "full" => RefundStatus.Full,
            _ => (RefundStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundStatus.Partial => "partial",
                RefundStatus.Full => "full",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
