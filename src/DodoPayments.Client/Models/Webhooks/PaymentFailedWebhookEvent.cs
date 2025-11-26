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
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required PaymentFailedWebhookEventData Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<PaymentFailedWebhookEventData>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'timestamp' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timestamp",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, PaymentFailedWebhookEventType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PaymentFailedWebhookEventType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public PaymentFailedWebhookEvent() { }

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

    public static PaymentFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFailedWebhookEventFromRaw : IFromRaw<PaymentFailedWebhookEvent>
{
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
        get
        {
            if (!this._rawData.TryGetValue("billing", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new System::ArgumentOutOfRangeException("billing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BillingAddress>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new System::ArgumentNullException("billing")
                );
        }
        init
        {
            this._rawData["billing"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("brand_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentOutOfRangeException("brand_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentNullException("brand_id")
                );
        }
        init
        {
            this._rawData["brand_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the payment was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this._rawData.TryGetValue("customer", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        init
        {
            this._rawData["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("digital_products_delivered", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'digital_products_delivered' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "digital_products_delivered",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["digital_products_delivered"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of disputes associated with this payment
    /// </summary>
    public required List<Dispute> Disputes
    {
        get
        {
            if (!this._rawData.TryGetValue("disputes", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'disputes' cannot be null",
                    new System::ArgumentOutOfRangeException("disputes", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Dispute>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'disputes' cannot be null",
                    new System::ArgumentNullException("disputes")
                );
        }
        init
        {
            this._rawData["disputes"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("payment_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "payment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new System::ArgumentNullException("payment_id")
                );
        }
        init
        {
            this._rawData["payment_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("refunds", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'refunds' cannot be null",
                    new System::ArgumentOutOfRangeException("refunds", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Refund>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'refunds' cannot be null",
                    new System::ArgumentNullException("refunds")
                );
        }
        init
        {
            this._rawData["refunds"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("settlement_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'settlement_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "settlement_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["settlement_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Currency> SettlementCurrency
    {
        get
        {
            if (!this._rawData.TryGetValue("settlement_currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'settlement_currency' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "settlement_currency",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["settlement_currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total amount charged to the customer including tax, in smallest currency unit
    /// (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("total_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'total_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "total_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["total_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            if (!this._rawData.TryGetValue("card_issuing_country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["card_issuing_country"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("card_last_four", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card_last_four"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("card_network", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card_network"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("card_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If payment is made using a checkout session, this field is set to the id of
    /// the session.
    /// </summary>
    public string? CheckoutSessionID
    {
        get
        {
            if (!this._rawData.TryGetValue("checkout_session_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["checkout_session_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["discount_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("error_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_code"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("error_message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_message"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_link"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("payment_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_method"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("payment_method_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_method_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("product_cart", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ProductCart>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["product_cart"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("settlement_tax", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["settlement_tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["subscription_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("tax", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the payment was last updated
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PaymentFailedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            if (!this._rawData.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                PaymentFailedWebhookEventDataIntersectionMember1PayloadType
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

    public static PaymentFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFailedWebhookEventDataFromRaw : IFromRaw<PaymentFailedWebhookEventData>
{
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
            if (!this._rawData.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                PaymentFailedWebhookEventDataIntersectionMember1PayloadType
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public PaymentFailedWebhookEventDataIntersectionMember1() { }

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
