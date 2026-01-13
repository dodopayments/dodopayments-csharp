using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(JsonModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required MeterAggregation Aggregation
    {
        get { return this._rawData.GetNotNullClass<MeterAggregation>("aggregation"); }
        init { this._rawData.Set("aggregation", value); }
    }

    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required string EventName
    {
        get { return this._rawData.GetNotNullClass<string>("event_name"); }
        init { this._rawData.Set("event_name", value); }
    }

    public required string MeasurementUnit
    {
        get { return this._rawData.GetNotNullClass<string>("measurement_unit"); }
        init { this._rawData.Set("measurement_unit", value); }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
    ///
    /// <para>Supports up to 3 levels of nesting to create complex filter expressions.
    /// Each filter has a conjunction (and/or) and clauses that can be either direct
    /// conditions or nested filters.</para>
    /// </summary>
    public MeterFilter? Filter
    {
        get { return this._rawData.GetNullableClass<MeterFilter>("filter"); }
        init { this._rawData.Set("filter", value); }
    }

    /// <inheritdoc/>
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

    public Meter(Meter meter)
        : base(meter) { }

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFromRaw.FromRawUnchecked"/>
    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRawJson<Meter>
{
    /// <inheritdoc/>
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}
