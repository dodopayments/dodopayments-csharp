using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionRetrieveUsageHistoryPageResponse,
        SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponse : ModelBase
{
    /// <summary>
    /// List of usage history items
    /// </summary>
    public required IReadOnlyList<ItemModel> Items
    {
        get { return ModelBase.GetNotNullClass<List<ItemModel>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public SubscriptionRetrieveUsageHistoryPageResponse() { }

    public SubscriptionRetrieveUsageHistoryPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(List<ItemModel> items)
        : this()
    {
        this.Items = items;
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    : IFromRaw<SubscriptionRetrieveUsageHistoryPageResponse>
{
    public SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ItemModel, ItemModelFromRaw>))]
public sealed record class ItemModel : ModelBase
{
    /// <summary>
    /// End date of the billing period
    /// </summary>
    public required DateTimeOffset EndDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required IReadOnlyList<MeterModel> Meters
    {
        get { return ModelBase.GetNotNullClass<List<MeterModel>>(this.RawData, "meters"); }
        init { ModelBase.Set(this._rawData, "meters", value); }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        _ = this.StartDate;
    }

    public ItemModel() { }

    public ItemModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemModelFromRaw : IFromRaw<ItemModel>
{
    public ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<MeterModel, MeterModelFromRaw>))]
public sealed record class MeterModel : ModelBase
{
    /// <summary>
    /// Meter identifier
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Chargeable units (after free threshold) as string for precision
    /// </summary>
    public required string ChargeableUnits
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "chargeable_units"); }
        init { ModelBase.Set(this._rawData, "chargeable_units", value); }
    }

    /// <summary>
    /// Total units consumed as string for precision
    /// </summary>
    public required string ConsumedUnits
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "consumed_units"); }
        init { ModelBase.Set(this._rawData, "consumed_units", value); }
    }

    /// <summary>
    /// Currency for the price per unit
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Free threshold units for this meter
    /// </summary>
    public required long FreeThreshold
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "free_threshold"); }
        init { ModelBase.Set(this._rawData, "free_threshold", value); }
    }

    /// <summary>
    /// Meter name
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Price per unit in string format for precision
    /// </summary>
    public required string PricePerUnit
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_per_unit"); }
        init { ModelBase.Set(this._rawData, "price_per_unit", value); }
    }

    /// <summary>
    /// Total price charged for this meter in smallest currency unit (cents)
    /// </summary>
    public required int TotalPrice
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "total_price"); }
        init { ModelBase.Set(this._rawData, "total_price", value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChargeableUnits;
        _ = this.ConsumedUnits;
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.TotalPrice;
    }

    public MeterModel() { }

    public MeterModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MeterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterModelFromRaw : IFromRaw<MeterModel>
{
    public MeterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterModel.FromRawUnchecked(rawData);
}
