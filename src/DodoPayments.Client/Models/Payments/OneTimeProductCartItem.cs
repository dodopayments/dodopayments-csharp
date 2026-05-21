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

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public int? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.Amount;
    }

    public OneTimeProductCartItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OneTimeProductCartItem(OneTimeProductCartItem oneTimeProductCartItem)
        : base(oneTimeProductCartItem) { }
#pragma warning restore CS8618

    public OneTimeProductCartItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimeProductCartItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
