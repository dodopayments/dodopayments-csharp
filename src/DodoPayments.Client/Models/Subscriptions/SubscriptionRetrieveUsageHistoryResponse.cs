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
    typeof(JsonModelConverter<
        SubscriptionRetrieveUsageHistoryResponse,
        SubscriptionRetrieveUsageHistoryResponseFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryResponse : JsonModel
{
    /// <summary>
    /// End date of the billing period
    /// </summary>
    public required DateTimeOffset EndDate
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required IReadOnlyList<SubscriptionRetrieveUsageHistoryResponseMeter> Meters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<SubscriptionRetrieveUsageHistoryResponseMeter>>(
                this.RawData,
                "meters"
            );
        }
        init { JsonModel.Set(this._rawData, "meters", value); }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { JsonModel.Set(this._rawData, "start_date", value); }
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

    public SubscriptionRetrieveUsageHistoryResponse() { }

    public SubscriptionRetrieveUsageHistoryResponse(
        SubscriptionRetrieveUsageHistoryResponse subscriptionRetrieveUsageHistoryResponse
    )
        : base(subscriptionRetrieveUsageHistoryResponse) { }

    public SubscriptionRetrieveUsageHistoryResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveUsageHistoryResponseFromRaw
    : IFromRawJson<SubscriptionRetrieveUsageHistoryResponse>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRetrieveUsageHistoryResponseMeter,
        SubscriptionRetrieveUsageHistoryResponseMeterFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryResponseMeter : JsonModel
{
    /// <summary>
    /// Meter identifier
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Chargeable units (after free threshold) as string for precision
    /// </summary>
    public required string ChargeableUnits
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "chargeable_units"); }
        init { JsonModel.Set(this._rawData, "chargeable_units", value); }
    }

    /// <summary>
    /// Total units consumed as string for precision
    /// </summary>
    public required string ConsumedUnits
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "consumed_units"); }
        init { JsonModel.Set(this._rawData, "consumed_units", value); }
    }

    /// <summary>
    /// Currency for the price per unit
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Free threshold units for this meter
    /// </summary>
    public required long FreeThreshold
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "free_threshold"); }
        init { JsonModel.Set(this._rawData, "free_threshold", value); }
    }

    /// <summary>
    /// Meter name
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Price per unit in string format for precision
    /// </summary>
    public required string PricePerUnit
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "price_per_unit"); }
        init { JsonModel.Set(this._rawData, "price_per_unit", value); }
    }

    /// <summary>
    /// Total price charged for this meter in smallest currency unit (cents)
    /// </summary>
    public required int TotalPrice
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "total_price"); }
        init { JsonModel.Set(this._rawData, "total_price", value); }
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

    public SubscriptionRetrieveUsageHistoryResponseMeter() { }

    public SubscriptionRetrieveUsageHistoryResponseMeter(
        SubscriptionRetrieveUsageHistoryResponseMeter subscriptionRetrieveUsageHistoryResponseMeter
    )
        : base(subscriptionRetrieveUsageHistoryResponseMeter) { }

    public SubscriptionRetrieveUsageHistoryResponseMeter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryResponseMeter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryResponseMeterFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryResponseMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveUsageHistoryResponseMeterFromRaw
    : IFromRawJson<SubscriptionRetrieveUsageHistoryResponseMeter>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryResponseMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryResponseMeter.FromRawUnchecked(rawData);
}
