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
    public required IReadOnlyList<SubscriptionRetrieveUsageHistoryPageResponseItem> Items
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<SubscriptionRetrieveUsageHistoryPageResponseItem>
            >(this.RawData, "items");
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public SubscriptionRetrieveUsageHistoryPageResponse() { }

    public SubscriptionRetrieveUsageHistoryPageResponse(
        SubscriptionRetrieveUsageHistoryPageResponse subscriptionRetrieveUsageHistoryPageResponse
    )
        : base(subscriptionRetrieveUsageHistoryPageResponse) { }

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

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryPageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(
        List<SubscriptionRetrieveUsageHistoryPageResponseItem> items
    )
        : this()
    {
        this.Items = items;
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    : IFromRaw<SubscriptionRetrieveUsageHistoryPageResponse>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionRetrieveUsageHistoryPageResponseItem,
        SubscriptionRetrieveUsageHistoryPageResponseItemFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponseItem : ModelBase
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
    public required IReadOnlyList<SubscriptionRetrieveUsageHistoryPageResponseItemMeter> Meters
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<SubscriptionRetrieveUsageHistoryPageResponseItemMeter>
            >(this.RawData, "meters");
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndDate;
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        _ = this.StartDate;
    }

    public SubscriptionRetrieveUsageHistoryPageResponseItem() { }

    public SubscriptionRetrieveUsageHistoryPageResponseItem(
        SubscriptionRetrieveUsageHistoryPageResponseItem subscriptionRetrieveUsageHistoryPageResponseItem
    )
        : base(subscriptionRetrieveUsageHistoryPageResponseItem) { }

    public SubscriptionRetrieveUsageHistoryPageResponseItem(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryPageResponseItemFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseItemFromRaw
    : IFromRaw<SubscriptionRetrieveUsageHistoryPageResponseItem>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponseItem.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionRetrieveUsageHistoryPageResponseItemMeter,
        SubscriptionRetrieveUsageHistoryPageResponseItemMeterFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponseItemMeter : ModelBase
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

    /// <inheritdoc/>
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

    public SubscriptionRetrieveUsageHistoryPageResponseItemMeter() { }

    public SubscriptionRetrieveUsageHistoryPageResponseItemMeter(
        SubscriptionRetrieveUsageHistoryPageResponseItemMeter subscriptionRetrieveUsageHistoryPageResponseItemMeter
    )
        : base(subscriptionRetrieveUsageHistoryPageResponseItemMeter) { }

    public SubscriptionRetrieveUsageHistoryPageResponseItemMeter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponseItemMeter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryPageResponseItemMeterFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryPageResponseItemMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseItemMeterFromRaw
    : IFromRaw<SubscriptionRetrieveUsageHistoryPageResponseItemMeter>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryPageResponseItemMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponseItemMeter.FromRawUnchecked(rawData);
}
