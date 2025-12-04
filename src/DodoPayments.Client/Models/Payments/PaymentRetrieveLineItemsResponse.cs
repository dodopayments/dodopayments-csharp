using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(
    typeof(ModelConverter<
        PaymentRetrieveLineItemsResponse,
        PaymentRetrieveLineItemsResponseFromRaw
    >)
)]
public sealed record class PaymentRetrieveLineItemsResponse : ModelBase
{
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required IReadOnlyList<PaymentRetrieveLineItemsResponseItem> Items
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PaymentRetrieveLineItemsResponseItem>>(
                this.RawData,
                "items"
            );
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public override void Validate()
    {
        this.Currency.Validate();
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PaymentRetrieveLineItemsResponse() { }

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

    public static PaymentRetrieveLineItemsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentRetrieveLineItemsResponseFromRaw : IFromRaw<PaymentRetrieveLineItemsResponse>
{
    public PaymentRetrieveLineItemsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentRetrieveLineItemsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        PaymentRetrieveLineItemsResponseItem,
        PaymentRetrieveLineItemsResponseItemFromRaw
    >)
)]
public sealed record class PaymentRetrieveLineItemsResponseItem : ModelBase
{
    public required int Amount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public required string ItemsID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "items_id"); }
        init { ModelBase.Set(this._rawData, "items_id", value); }
    }

    public required int RefundableAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "refundable_amount"); }
        init { ModelBase.Set(this._rawData, "refundable_amount", value); }
    }

    public required int Tax
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.ItemsID;
        _ = this.RefundableAmount;
        _ = this.Tax;
        _ = this.Description;
        _ = this.Name;
    }

    public PaymentRetrieveLineItemsResponseItem() { }

    public PaymentRetrieveLineItemsResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRetrieveLineItemsResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PaymentRetrieveLineItemsResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentRetrieveLineItemsResponseItemFromRaw : IFromRaw<PaymentRetrieveLineItemsResponseItem>
{
    public PaymentRetrieveLineItemsResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentRetrieveLineItemsResponseItem.FromRawUnchecked(rawData);
}
