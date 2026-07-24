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
using DodoPayments.Client.Models.Disputes;
using Misc = DodoPayments.Client.Models.Misc;

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
    public required ApiEnum<string, Misc::Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Misc::Currency>>("currency");
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
    /// Whether the digital products purchased in this payment have been delivered.
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
    /// Whether this payment was created solely to update a subscription's payment
    /// method (a zero-/setup-amount charge). `false` for normal charges.
    /// </summary>
    public required bool IsUpdatePaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_update_payment_method");
        }
        init { this._rawData.Set("is_update_payment_method", value); }
    }

    /// <summary>
    /// Additional custom data associated with the payment
    /// </summary>
    public required IReadOnlyDictionary<string, Misc::MetadataItem> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, Misc::MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Misc::MetadataItem>>(
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
    /// merchant's own payment connector); `dodo` for everything Dodo processed itself.
    /// </summary>
    public required ApiEnum<
        string,
        global::DodoPayments.Client.Models.Payments.PaymentProvider
    > PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Payments.PaymentProvider>
            >("payment_provider");
        }
        init { this._rawData.Set("payment_provider", value); }
    }

    /// <summary>
    /// List of refunds issued for this payment
    /// </summary>
    public required IReadOnlyList<RefundListItem> Refunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RefundListItem>>("refunds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RefundListItem>>(
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

    /// <summary>
    /// The currency in which the settlement_amount will be credited to your Dodo
    /// balance. This may differ from the customer's payment currency in adaptive
    /// pricing scenarios.
    /// </summary>
    public required ApiEnum<string, Misc::Currency> SettlementCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Misc::Currency>>(
                "settlement_currency"
            );
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
    /// ISO2 country code of the card
    /// </summary>
    public ApiEnum<string, Misc::CountryCode>? CardIssuingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Misc::CountryCode>>(
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
    /// Purpose-built failure messaging for the merchant and the customer, derived
    /// from `error_code`. Present whenever `error_code` is set, regardless of payment
    /// status; unrecognised codes still resolve via a generic fallback rather than
    /// being omitted. The customer copy is always generic for fraud-sensitive declines
    /// (lost/stolen/pickup/fraudulent) so the true reason is never leaked.
    /// </summary>
    public FailureDetails? FailureDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FailureDetails>("failure_details");
        }
        init { this._rawData.Set("failure_details", value); }
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
    /// Identifier of the saved payment method used for this payment, if any.
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
    public ApiEnum<string, PaymentRefundStatus>? RefundStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentRefundStatus>>(
                "refund_status"
            );
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
        _ = this.IsUpdatePaymentMethod;
        foreach (var item in this.Metadata.Values)
        {
            item.Validate();
        }
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
        this.FailureDetails?.Validate();
        _ = this.InvoiceID;
        _ = this.InvoiceUrl;
        _ = this.PaymentLink;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodID;
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

/// <summary>
/// Which processor handled this payment. `stripe` / `adyen` for BYOP routes (the
/// merchant's own payment connector); `dodo` for everything Dodo processed itself.
/// </summary>
[JsonConverter(typeof(global::DodoPayments.Client.Models.Payments.PaymentProviderConverter))]
public enum PaymentProvider
{
    Stripe,
    Adyen,
    Dodo,
}

sealed class PaymentProviderConverter
    : JsonConverter<global::DodoPayments.Client.Models.Payments.PaymentProvider>
{
    public override global::DodoPayments.Client.Models.Payments.PaymentProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => global::DodoPayments.Client.Models.Payments.PaymentProvider.Stripe,
            "adyen" => global::DodoPayments.Client.Models.Payments.PaymentProvider.Adyen,
            "dodo" => global::DodoPayments.Client.Models.Payments.PaymentProvider.Dodo,
            _ => (global::DodoPayments.Client.Models.Payments.PaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Payments.PaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Payments.PaymentProvider.Stripe => "stripe",
                global::DodoPayments.Client.Models.Payments.PaymentProvider.Adyen => "adyen",
                global::DodoPayments.Client.Models.Payments.PaymentProvider.Dodo => "dodo",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Purpose-built failure messaging for the merchant and the customer, derived from
/// `error_code`. Present whenever `error_code` is set, regardless of payment status;
/// unrecognised codes still resolve via a generic fallback rather than being omitted.
/// The customer copy is always generic for fraud-sensitive declines (lost/stolen/pickup/fraudulent)
/// so the true reason is never leaked.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FailureDetails, FailureDetailsFromRaw>))]
public sealed record class FailureDetails : JsonModel
{
    /// <summary>
    /// The unified error code (echoes `error_code`).
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// The primary CTA to show the customer.
    /// </summary>
    public required ApiEnum<string, CustomerCta> CustomerCta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomerCta>>("customer_cta");
        }
        init { this._rawData.Set("customer_cta", value); }
    }

    /// <summary>
    /// Whether the customer can resolve this themselves (e.g. fix CVC).
    /// </summary>
    public required bool CustomerFixable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("customer_fixable");
        }
        init { this._rawData.Set("customer_fixable", value); }
    }

    /// <summary>
    /// The customer-facing string. Always generic (`C11`) for the fraud-4.
    /// </summary>
    public required string CustomerMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_message");
        }
        init { this._rawData.Set("customer_message", value); }
    }

    /// <summary>
    /// The customer message template identifier (C1..C20).
    /// </summary>
    public required ApiEnum<string, CustomerTemplate> CustomerTemplate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomerTemplate>>(
                "customer_template"
            );
        }
        init { this._rawData.Set("customer_template", value); }
    }

    /// <summary>
    /// Soft or hard decline.
    /// </summary>
    public required ApiEnum<string, DeclineType> DeclineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeclineType>>("decline_type");
        }
        init { this._rawData.Set("decline_type", value); }
    }

    /// <summary>
    /// Merchant-facing headline + recommended action (Payment Details). For the fraud-4
    /// this includes the operator "do not reveal" warning.
    /// </summary>
    public required string MerchantMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_message");
        }
        init { this._rawData.Set("merchant_message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        this.CustomerCta.Validate();
        _ = this.CustomerFixable;
        _ = this.CustomerMessage;
        this.CustomerTemplate.Validate();
        this.DeclineType.Validate();
        _ = this.MerchantMessage;
    }

    public FailureDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailureDetails(FailureDetails failureDetails)
        : base(failureDetails) { }
#pragma warning restore CS8618

    public FailureDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FailureDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailureDetailsFromRaw.FromRawUnchecked"/>
    public static FailureDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailureDetailsFromRaw : IFromRawJson<FailureDetails>
{
    /// <inheritdoc/>
    public FailureDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FailureDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The primary CTA to show the customer.
/// </summary>
[JsonConverter(typeof(CustomerCtaConverter))]
public enum CustomerCta
{
    EditAndRetry,
    UseAnotherMethod,
    TryAgain,
    TryLater,
    RetryAndVerify,
    Restart,
    UpdateMethod,
}

sealed class CustomerCtaConverter : JsonConverter<CustomerCta>
{
    public override CustomerCta Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "edit_and_retry" => CustomerCta.EditAndRetry,
            "use_another_method" => CustomerCta.UseAnotherMethod,
            "try_again" => CustomerCta.TryAgain,
            "try_later" => CustomerCta.TryLater,
            "retry_and_verify" => CustomerCta.RetryAndVerify,
            "restart" => CustomerCta.Restart,
            "update_method" => CustomerCta.UpdateMethod,
            _ => (CustomerCta)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerCta value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerCta.EditAndRetry => "edit_and_retry",
                CustomerCta.UseAnotherMethod => "use_another_method",
                CustomerCta.TryAgain => "try_again",
                CustomerCta.TryLater => "try_later",
                CustomerCta.RetryAndVerify => "retry_and_verify",
                CustomerCta.Restart => "restart",
                CustomerCta.UpdateMethod => "update_method",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The customer message template identifier (C1..C20).
/// </summary>
[JsonConverter(typeof(CustomerTemplateConverter))]
public enum CustomerTemplate
{
    C1,
    C2,
    C3,
    C4,
    C5,
    C6,
    C7,
    C8,
    C9,
    C10,
    C11,
    C12,
    C13,
    C14,
    C15,
    C16,
    C17,
    C18,
    C19,
    C20,
}

sealed class CustomerTemplateConverter : JsonConverter<CustomerTemplate>
{
    public override CustomerTemplate Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "C1" => CustomerTemplate.C1,
            "C2" => CustomerTemplate.C2,
            "C3" => CustomerTemplate.C3,
            "C4" => CustomerTemplate.C4,
            "C5" => CustomerTemplate.C5,
            "C6" => CustomerTemplate.C6,
            "C7" => CustomerTemplate.C7,
            "C8" => CustomerTemplate.C8,
            "C9" => CustomerTemplate.C9,
            "C10" => CustomerTemplate.C10,
            "C11" => CustomerTemplate.C11,
            "C12" => CustomerTemplate.C12,
            "C13" => CustomerTemplate.C13,
            "C14" => CustomerTemplate.C14,
            "C15" => CustomerTemplate.C15,
            "C16" => CustomerTemplate.C16,
            "C17" => CustomerTemplate.C17,
            "C18" => CustomerTemplate.C18,
            "C19" => CustomerTemplate.C19,
            "C20" => CustomerTemplate.C20,
            _ => (CustomerTemplate)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerTemplate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerTemplate.C1 => "C1",
                CustomerTemplate.C2 => "C2",
                CustomerTemplate.C3 => "C3",
                CustomerTemplate.C4 => "C4",
                CustomerTemplate.C5 => "C5",
                CustomerTemplate.C6 => "C6",
                CustomerTemplate.C7 => "C7",
                CustomerTemplate.C8 => "C8",
                CustomerTemplate.C9 => "C9",
                CustomerTemplate.C10 => "C10",
                CustomerTemplate.C11 => "C11",
                CustomerTemplate.C12 => "C12",
                CustomerTemplate.C13 => "C13",
                CustomerTemplate.C14 => "C14",
                CustomerTemplate.C15 => "C15",
                CustomerTemplate.C16 => "C16",
                CustomerTemplate.C17 => "C17",
                CustomerTemplate.C18 => "C18",
                CustomerTemplate.C19 => "C19",
                CustomerTemplate.C20 => "C20",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Soft or hard decline.
/// </summary>
[JsonConverter(typeof(DeclineTypeConverter))]
public enum DeclineType
{
    Soft,
    Hard,
}

sealed class DeclineTypeConverter : JsonConverter<DeclineType>
{
    public override DeclineType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "soft" => DeclineType.Soft,
            "hard" => DeclineType.Hard,
            _ => (DeclineType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeclineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeclineType.Soft => "soft",
                DeclineType.Hard => "hard",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
