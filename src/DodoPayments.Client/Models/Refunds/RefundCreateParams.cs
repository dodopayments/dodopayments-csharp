using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Refunds;

public sealed record class RefundCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The unique identifier of the payment to be refunded.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "payment_id"); }
        init { ModelBase.Set(this._rawBodyData, "payment_id", value); }
    }

    /// <summary>
    /// Partially Refund an Individual Item
    /// </summary>
    public IReadOnlyList<Item>? Items
    {
        get { return ModelBase.GetNullableClass<List<Item>>(this.RawBodyData, "items"); }
        init { ModelBase.Set(this._rawBodyData, "items", value); }
    }

    /// <summary>
    /// Additional metadata associated with the refund.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "metadata", value);
        }
    }

    /// <summary>
    /// The reason for the refund, if any. Maximum length is 3000 characters. Optional.
    /// </summary>
    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "reason"); }
        init { ModelBase.Set(this._rawBodyData, "reason", value); }
    }

    public RefundCreateParams() { }

    public RefundCreateParams(RefundCreateParams refundCreateParams)
        : base(refundCreateParams)
    {
        this._rawBodyData = [.. refundCreateParams._rawBodyData];
    }

    public RefundCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static RefundCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/refunds")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    /// <summary>
    /// The id of the item (i.e. `product_id` or `addon_id`)
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The amount to refund. if None the whole item is refunded
    /// </summary>
    public int? Amount
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// Specify if tax is inclusive of the refund. Default true.
    /// </summary>
    public bool? TaxInclusive
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "tax_inclusive"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tax_inclusive", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ItemID;
        _ = this.Amount;
        _ = this.TaxInclusive;
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

    [SetsRequiredMembers]
    public Item(string itemID)
        : this()
    {
        this.ItemID = itemID;
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
