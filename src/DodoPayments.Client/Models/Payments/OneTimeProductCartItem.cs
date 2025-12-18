using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<OneTimeProductCartItem, OneTimeProductCartItemFromRaw>))]
public sealed record class OneTimeProductCartItem : JsonModel
{
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public int? Amount
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.Amount;
    }

    public OneTimeProductCartItem() { }

    public OneTimeProductCartItem(OneTimeProductCartItem oneTimeProductCartItem)
        : base(oneTimeProductCartItem) { }

    public OneTimeProductCartItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimeProductCartItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OneTimeProductCartItemFromRaw.FromRawUnchecked"/>
    public static OneTimeProductCartItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OneTimeProductCartItemFromRaw : IFromRawJson<OneTimeProductCartItem>
{
    /// <inheritdoc/>
    public OneTimeProductCartItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OneTimeProductCartItem.FromRawUnchecked(rawData);
}
