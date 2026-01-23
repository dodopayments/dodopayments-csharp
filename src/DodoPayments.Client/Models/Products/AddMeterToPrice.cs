using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<AddMeterToPrice, AddMeterToPriceFromRaw>))]
public sealed record class AddMeterToPrice : JsonModel
{
    public required string MeterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_id");
        }
        init { this._rawData.Set("meter_id", value); }
    }

    /// <summary>
    /// The price per unit in lowest denomination. Must be greater than zero. Supports
    /// up to 5 digits before decimal point and 12 decimal places.
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
    /// Meter description. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public long? FreeThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("free_threshold");
        }
        init { this._rawData.Set("free_threshold", value); }
    }

    /// <summary>
    /// Meter measurement unit. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? MeasurementUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("measurement_unit");
        }
        init { this._rawData.Set("measurement_unit", value); }
    }

    /// <summary>
    /// Meter name. Will ignored on Request, but will be shown in response
    /// </summary>
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
        _ = this.MeterID;
        _ = this.PricePerUnit;
        _ = this.Description;
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.Name;
    }

    public AddMeterToPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddMeterToPrice(AddMeterToPrice addMeterToPrice)
        : base(addMeterToPrice) { }
#pragma warning restore CS8618

    public AddMeterToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddMeterToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddMeterToPriceFromRaw.FromRawUnchecked"/>
    public static AddMeterToPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddMeterToPriceFromRaw : IFromRawJson<AddMeterToPrice>
{
    /// <inheritdoc/>
    public AddMeterToPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddMeterToPrice.FromRawUnchecked(rawData);
}
