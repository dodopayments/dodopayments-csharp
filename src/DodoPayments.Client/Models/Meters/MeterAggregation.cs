using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(JsonModelConverter<MeterAggregation, MeterAggregationFromRaw>))]
public sealed record class MeterAggregation : JsonModel
{
    /// <summary>
    /// Aggregation type for the meter
    /// </summary>
    public required ApiEnum<string, global::DodoPayments.Client.Models.Meters.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Meters.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Required when type is not COUNT
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Key;
    }

    public MeterAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterAggregation(MeterAggregation meterAggregation)
        : base(meterAggregation) { }
#pragma warning restore CS8618

    public MeterAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterAggregationFromRaw.FromRawUnchecked"/>
    public static MeterAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MeterAggregation(ApiEnum<string, global::DodoPayments.Client.Models.Meters.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class MeterAggregationFromRaw : IFromRawJson<MeterAggregation>
{
    /// <inheritdoc/>
    public MeterAggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation type for the meter
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Count,
    Sum,
    Max,
    Last,
}

sealed class TypeConverter : JsonConverter<global::DodoPayments.Client.Models.Meters.Type>
{
    public override global::DodoPayments.Client.Models.Meters.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => global::DodoPayments.Client.Models.Meters.Type.Count,
            "sum" => global::DodoPayments.Client.Models.Meters.Type.Sum,
            "max" => global::DodoPayments.Client.Models.Meters.Type.Max,
            "last" => global::DodoPayments.Client.Models.Meters.Type.Last,
            _ => (global::DodoPayments.Client.Models.Meters.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Meters.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Meters.Type.Count => "count",
                global::DodoPayments.Client.Models.Meters.Type.Sum => "sum",
                global::DodoPayments.Client.Models.Meters.Type.Max => "max",
                global::DodoPayments.Client.Models.Meters.Type.Last => "last",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
