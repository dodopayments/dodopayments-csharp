using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRetrieveLineItemsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string ItemsID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("items_id");
        }
        init { this._rawData.Set("items_id", value); }
    }

    public required int RefundableAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("refundable_amount");
        }
        init { this._rawData.Set("refundable_amount", value); }
    }

    public required int Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
