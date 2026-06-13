using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentListResponse, PaymentListResponseFromRaw>))]
public sealed record class PaymentListResponse : JsonModel
{
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

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    public required bool DigitalProductsDelivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("digital_products_delivered");
        }
        init { this._rawData.Set("digital_products_delivered", value); }
    }

    public required bool HasLicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_license_key");
        }
        init { this._rawData.Set("has_license_key", value); }
    }

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
    public required ApiEnum<string, PaymentListResponsePaymentProvider> PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PaymentListResponsePaymentProvider>
            >("payment_provider");
        }
        init { this._rawData.Set("payment_provider", value); }
    }

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
    /// The most recent dispute status for this payment. None if no disputes exist.
    /// </summary>
    public ApiEnum<string, DisputeDisputeStatus>? DisputeStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DisputeDisputeStatus>>(
                "dispute_status"
            );
        }
        init { this._rawData.Set("dispute_status", value); }
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

    public string? PaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method");
        }
        init { this._rawData.Set("payment_method", value); }
    }

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

    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntentStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.DigitalProductsDelivered;
        _ = this.HasLicenseKey;
        _ = this.Metadata;
        _ = this.PaymentID;
        this.PaymentProvider.Validate();
        _ = this.TotalAmount;
        _ = this.CardLastFour;
        _ = this.CardNetwork;
        this.DisputeStatus?.Validate();
        _ = this.InvoiceID;
        _ = this.InvoiceUrl;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodType;
        this.RefundStatus?.Validate();
        this.Status?.Validate();
        _ = this.SubscriptionID;
    }

    public PaymentListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentListResponse(PaymentListResponse paymentListResponse)
        : base(paymentListResponse) { }
#pragma warning restore CS8618

    public PaymentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentListResponseFromRaw.FromRawUnchecked"/>
    public static PaymentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentListResponseFromRaw : IFromRawJson<PaymentListResponse>
{
    /// <inheritdoc/>
    public PaymentListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Which processor handled this payment. `stripe` / `adyen` for BYOP routes (the
/// merchant's own payment connector); `dodo` for everything Dodo processed itself.
/// </summary>
[JsonConverter(typeof(PaymentListResponsePaymentProviderConverter))]
public enum PaymentListResponsePaymentProvider
{
    Stripe,
    Adyen,
    Dodo,
}

sealed class PaymentListResponsePaymentProviderConverter
    : JsonConverter<PaymentListResponsePaymentProvider>
{
    public override PaymentListResponsePaymentProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => PaymentListResponsePaymentProvider.Stripe,
            "adyen" => PaymentListResponsePaymentProvider.Adyen,
            "dodo" => PaymentListResponsePaymentProvider.Dodo,
            _ => (PaymentListResponsePaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentListResponsePaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentListResponsePaymentProvider.Stripe => "stripe",
                PaymentListResponsePaymentProvider.Adyen => "adyen",
                PaymentListResponsePaymentProvider.Dodo => "dodo",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
