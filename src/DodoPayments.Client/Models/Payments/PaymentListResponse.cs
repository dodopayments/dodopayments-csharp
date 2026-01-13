using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentListResponse, PaymentListResponseFromRaw>))]
public sealed record class PaymentListResponse : JsonModel
{
    public required string BrandID
    {
        get { return this._rawData.GetNotNullClass<string>("brand_id"); }
        init { this._rawData.Set("brand_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get { return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer"); }
        init { this._rawData.Set("customer", value); }
    }

    public required bool DigitalProductsDelivered
    {
        get { return this._rawData.GetNotNullStruct<bool>("digital_products_delivered"); }
        init { this._rawData.Set("digital_products_delivered", value); }
    }

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata"); }
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
        get { return this._rawData.GetNotNullClass<string>("payment_id"); }
        init { this._rawData.Set("payment_id", value); }
    }

    public required int TotalAmount
    {
        get { return this._rawData.GetNotNullStruct<int>("total_amount"); }
        init { this._rawData.Set("total_amount", value); }
    }

    public string? PaymentMethod
    {
        get { return this._rawData.GetNullableClass<string>("payment_method"); }
        init { this._rawData.Set("payment_method", value); }
    }

    public string? PaymentMethodType
    {
        get { return this._rawData.GetNullableClass<string>("payment_method_type"); }
        init { this._rawData.Set("payment_method_type", value); }
    }

    public ApiEnum<string, IntentStatus>? Status
    {
        get { return this._rawData.GetNullableClass<ApiEnum<string, IntentStatus>>("status"); }
        init { this._rawData.Set("status", value); }
    }

    public string? SubscriptionID
    {
        get { return this._rawData.GetNullableClass<string>("subscription_id"); }
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
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.TotalAmount;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodType;
        this.Status?.Validate();
        _ = this.SubscriptionID;
    }

    public PaymentListResponse() { }

    public PaymentListResponse(PaymentListResponse paymentListResponse)
        : base(paymentListResponse) { }

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
