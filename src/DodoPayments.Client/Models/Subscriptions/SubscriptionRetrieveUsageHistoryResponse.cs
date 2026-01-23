using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required IReadOnlyList<SubscriptionRetrieveUsageHistoryResponseMeter> Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SubscriptionRetrieveUsageHistoryResponseMeter>
            >("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionRetrieveUsageHistoryResponseMeter>>(
                "meters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryResponse(
        SubscriptionRetrieveUsageHistoryResponse subscriptionRetrieveUsageHistoryResponse
    )
        : base(subscriptionRetrieveUsageHistoryResponse) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveUsageHistoryResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Chargeable units (after free threshold) as string for precision
    /// </summary>
    public required string ChargeableUnits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargeable_units");
        }
        init { this._rawData.Set("chargeable_units", value); }
    }

    /// <summary>
    /// Total units consumed as string for precision
    /// </summary>
    public required string ConsumedUnits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("consumed_units");
        }
        init { this._rawData.Set("consumed_units", value); }
    }

    /// <summary>
    /// Currency for the price per unit
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Free threshold units for this meter
    /// </summary>
    public required long FreeThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("free_threshold");
        }
        init { this._rawData.Set("free_threshold", value); }
    }

    /// <summary>
    /// Meter name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Price per unit in string format for precision
    /// </summary>
    public required string PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    /// <summary>
    /// Total price charged for this meter in smallest currency unit (cents)
    /// </summary>
    public required int TotalPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_price");
        }
        init { this._rawData.Set("total_price", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryResponseMeter(
        SubscriptionRetrieveUsageHistoryResponseMeter subscriptionRetrieveUsageHistoryResponseMeter
    )
        : base(subscriptionRetrieveUsageHistoryResponseMeter) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveUsageHistoryResponseMeter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryResponseMeter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
