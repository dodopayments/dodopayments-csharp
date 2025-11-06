using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Disputes = DodoPayments.Client.Models.Disputes;
using Refunds = DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<Payment>))]
public sealed record class Payment : ModelBase, IFromRaw<Payment>
{
    /// <summary>
    /// Billing address details for payments
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            if (!this.Properties.TryGetValue("billing", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new ArgumentOutOfRangeException("billing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BillingAddress>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new ArgumentNullException("billing")
                );
        }
        set
        {
            this.Properties["billing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new ArgumentOutOfRangeException("brand_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new ArgumentNullException("brand_id")
                );
        }
        set
        {
            this.Properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Identifier of the business associated with the payment
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the payment was created
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Currency used for the payment
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Details about the customer who made the payment
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// brand id this payment belongs to
    /// </summary>
    public required bool DigitalProductsDelivered
    {
        get
        {
            if (!this.Properties.TryGetValue("digital_products_delivered", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'digital_products_delivered' cannot be null",
                    new ArgumentOutOfRangeException(
                        "digital_products_delivered",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["digital_products_delivered"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of disputes associated with this payment
    /// </summary>
    public required List<Disputes::Dispute> Disputes
    {
        get
        {
            if (!this.Properties.TryGetValue("disputes", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'disputes' cannot be null",
                    new ArgumentOutOfRangeException("disputes", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Disputes::Dispute>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'disputes' cannot be null",
                    new ArgumentNullException("disputes")
                );
        }
        set
        {
            this.Properties["disputes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional custom data associated with the payment
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentOutOfRangeException("payment_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentNullException("payment_id")
                );
        }
        set
        {
            this.Properties["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of refunds issued for this payment
    /// </summary>
    public required List<Refund> Refunds
    {
        get
        {
            if (!this.Properties.TryGetValue("refunds", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'refunds' cannot be null",
                    new ArgumentOutOfRangeException("refunds", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Refund>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'refunds' cannot be null",
                    new ArgumentNullException("refunds")
                );
        }
        set
        {
            this.Properties["refunds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("settlement_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'settlement_amount' cannot be null",
                    new ArgumentOutOfRangeException(
                        "settlement_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["settlement_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this.Properties.TryGetValue("settlement_currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'settlement_currency' cannot be null",
                    new ArgumentOutOfRangeException(
                        "settlement_currency",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["settlement_currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total amount charged to the customer including tax, in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("total_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'total_amount' cannot be null",
                    new ArgumentOutOfRangeException("total_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["total_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO2 country code of the card
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            if (!this.Properties.TryGetValue("card_issuing_country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["card_issuing_country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The last four digits of the card
    /// </summary>
    public string? CardLastFour
    {
        get
        {
            if (!this.Properties.TryGetValue("card_last_four", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["card_last_four"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Card network like VISA, MASTERCARD etc.
    /// </summary>
    public string? CardNetwork
    {
        get
        {
            if (!this.Properties.TryGetValue("card_network", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["card_network"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of card DEBIT or CREDIT
    /// </summary>
    public string? CardType
    {
        get
        {
            if (!this.Properties.TryGetValue("card_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["card_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If payment is made using a checkout session, this field is set to the id
    /// of the session.
    /// </summary>
    public string? CheckoutSessionID
    {
        get
        {
            if (!this.Properties.TryGetValue("checkout_session_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checkout_session_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An error message if the payment failed
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            if (!this.Properties.TryGetValue("error_message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["error_message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Checkout URL
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_link"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Payment method used by customer (e.g. "card", "bank_transfer")
    /// </summary>
    public string? PaymentMethod
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specific type of payment method (e.g. "visa", "mastercard")
    /// </summary>
    public string? PaymentMethodType
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_method_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_method_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of products purchased in a one-time payment
    /// </summary>
    public List<ProductCart>? ProductCart
    {
        get
        {
            if (!this.Properties.TryGetValue("product_cart", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ProductCart>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["product_cart"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("settlement_tax", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["settlement_tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the payment intent
    /// </summary>
    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Identifier of the subscription if payment is part of a subscription
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subscription_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount of tax collected in smallest currency unit (e.g. cents)
    /// </summary>
    public int? Tax
    {
        get
        {
            if (!this.Properties.TryGetValue("tax", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the payment was last updated
    /// </summary>
    public DateTime? UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    }

    public Payment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Payment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Refund>))]
public sealed record class Refund : ModelBase, IFromRaw<Refund>
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get
        {
            if (!this.Properties.TryGetValue("is_partial", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'is_partial' cannot be null",
                    new ArgumentOutOfRangeException("is_partial", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_partial"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentOutOfRangeException("payment_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentNullException("payment_id")
                );
        }
        set
        {
            this.Properties["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get
        {
            if (!this.Properties.TryGetValue("refund_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'refund_id' cannot be null",
                    new ArgumentOutOfRangeException("refund_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'refund_id' cannot be null",
                    new ArgumentNullException("refund_id")
                );
        }
        set
        {
            this.Properties["refund_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current status of the refund.
    /// </summary>
    public required ApiEnum<string, Refunds::RefundStatus> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Refunds::RefundStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency of the refund, represented as an ISO 4217 currency code.
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    Refund(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Refund FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<ProductCart>))]
public sealed record class ProductCart : ModelBase, IFromRaw<ProductCart>
{
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentOutOfRangeException("product_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentNullException("product_id")
                );
        }
        set
        {
            this.Properties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
    }

    public ProductCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProductCart FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
