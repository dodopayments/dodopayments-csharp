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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "meter_id"); }
        init { JsonModel.Set(this._rawData, "meter_id", value); }
    }

    /// <summary>
    /// The price per unit in lowest denomination. Must be greater than zero. Supports
    /// up to 5 digits before decimal point and 12 decimal places.
    /// </summary>
    public required string PricePerUnit
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "price_per_unit"); }
        init { JsonModel.Set(this._rawData, "price_per_unit", value); }
    }

    /// <summary>
    /// Meter description. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    public long? FreeThreshold
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "free_threshold"); }
        init { JsonModel.Set(this._rawData, "free_threshold", value); }
    }

    /// <summary>
    /// Meter measurement unit. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? MeasurementUnit
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "measurement_unit"); }
        init { JsonModel.Set(this._rawData, "measurement_unit", value); }
    }

    /// <summary>
    /// Meter name. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
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

    public AddMeterToPrice(AddMeterToPrice addMeterToPrice)
        : base(addMeterToPrice) { }

    public AddMeterToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddMeterToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
