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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { JsonModel.Set(this._rawData, "brand_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
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

    public required bool DigitalProductsDelivered
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "digital_products_delivered"); }
        init { JsonModel.Set(this._rawData, "digital_products_delivered", value); }
    }

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    public required string PaymentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    public required int TotalAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { JsonModel.Set(this._rawData, "total_amount", value); }
    }

    public string? PaymentMethod
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_method"); }
        init { JsonModel.Set(this._rawData, "payment_method", value); }
    }

    public string? PaymentMethodType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_method_type"); }
        init { JsonModel.Set(this._rawData, "payment_method_type", value); }
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
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public string? SubscriptionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { JsonModel.Set(this._rawData, "subscription_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
