using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(
    typeof(JsonModelConverter<
        PaymentRetrieveLineItemsResponse,
        PaymentRetrieveLineItemsResponseFromRaw
    >)
)]
public sealed record class PaymentRetrieveLineItemsResponse : JsonModel
{
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required IReadOnlyList<Item> Items
    {
        get { return JsonModel.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PaymentRetrieveLineItemsResponse() { }

    public PaymentRetrieveLineItemsResponse(
        PaymentRetrieveLineItemsResponse paymentRetrieveLineItemsResponse
    )
        : base(paymentRetrieveLineItemsResponse) { }

    public PaymentRetrieveLineItemsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRetrieveLineItemsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentRetrieveLineItemsResponseFromRaw.FromRawUnchecked"/>
    public static PaymentRetrieveLineItemsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentRetrieveLineItemsResponseFromRaw : IFromRawJson<PaymentRetrieveLineItemsResponse>
{
    /// <inheritdoc/>
    public PaymentRetrieveLineItemsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentRetrieveLineItemsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required int Amount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    public required string ItemsID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "items_id"); }
        init { JsonModel.Set(this._rawData, "items_id", value); }
    }

    public required int RefundableAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "refundable_amount"); }
        init { JsonModel.Set(this._rawData, "refundable_amount", value); }
    }

    public required int Tax
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "tax"); }
        init { JsonModel.Set(this._rawData, "tax", value); }
    }

    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.ItemsID;
        _ = this.RefundableAmount;
        _ = this.Tax;
        _ = this.Description;
        _ = this.Name;
    }

    public Item() { }

    public Item(Item item)
        : base(item) { }

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

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
