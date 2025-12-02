using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(ModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required MeterAggregation Aggregation
    {
        get { return ModelBase.GetNotNullClass<MeterAggregation>(this.RawData, "aggregation"); }
        init { ModelBase.Set(this._rawData, "aggregation", value); }
    }

    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required string EventName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "event_name"); }
        init { ModelBase.Set(this._rawData, "event_name", value); }
    }

    public required string MeasurementUnit
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "measurement_unit"); }
        init { ModelBase.Set(this._rawData, "measurement_unit", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "updated_at"); }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
    ///
    /// <para>Supports up to 3 levels of nesting to create complex filter expressions.
    /// Each filter has a conjunction (and/or) and clauses that can be either direct
    /// conditions or nested filters.</para>
    /// </summary>
    public MeterMeterFilter? Filter
    {
        get { return ModelBase.GetNullableClass<MeterMeterFilter>(this.RawData, "filter"); }
        init { ModelBase.Set(this._rawData, "filter", value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Aggregation.Validate();
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.EventName;
        _ = this.MeasurementUnit;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
        this.Filter?.Validate();
    }

    public Meter() { }

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRaw<Meter>
{
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}
