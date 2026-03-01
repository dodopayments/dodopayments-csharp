using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing usage-based meter cart details for a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeterCartResponseItem, MeterCartResponseItemFromRaw>))]
public sealed record class MeterCartResponseItem : JsonModel
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

    public required long FreeThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("free_threshold");
        }
        init { this._rawData.Set("free_threshold", value); }
    }

    public required string MeasurementUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("measurement_unit");
        }
        init { this._rawData.Set("measurement_unit", value); }
    }

    public required string MeterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_id");
        }
        init { this._rawData.Set("meter_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    public string? PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.MeterID;
        _ = this.Name;
        _ = this.Description;
        _ = this.PricePerUnit;
    }

    public MeterCartResponseItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterCartResponseItem(MeterCartResponseItem meterCartResponseItem)
        : base(meterCartResponseItem) { }
#pragma warning restore CS8618

    public MeterCartResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterCartResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterCartResponseItemFromRaw.FromRawUnchecked"/>
    public static MeterCartResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterCartResponseItemFromRaw : IFromRawJson<MeterCartResponseItem>
{
    /// <inheritdoc/>
    public MeterCartResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterCartResponseItem.FromRawUnchecked(rawData);
}
