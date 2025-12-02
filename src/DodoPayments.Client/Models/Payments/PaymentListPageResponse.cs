using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<PaymentListPageResponse, PaymentListPageResponseFromRaw>))]
public sealed record class PaymentListPageResponse : ModelBase
{
    public required IReadOnlyList<Item> Items
    {
        get { return ModelBase.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PaymentListPageResponse() { }

    public PaymentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaymentListPageResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class PaymentListPageResponseFromRaw : IFromRaw<PaymentListPageResponse>
{
    public PaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    public required string BrandID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
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

    public required bool DigitalProductsDelivered
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "digital_products_delivered"); }
        init { ModelBase.Set(this._rawData, "digital_products_delivered", value); }
    }

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    public required int TotalAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { ModelBase.Set(this._rawData, "total_amount", value); }
    }

    public string? PaymentMethod
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_method"); }
        init { ModelBase.Set(this._rawData, "payment_method", value); }
    }

    public string? PaymentMethodType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_method_type"); }
        init { ModelBase.Set(this._rawData, "payment_method_type", value); }
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
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { ModelBase.Set(this._rawData, "subscription_id", value); }
    }

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

    public Item() { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
