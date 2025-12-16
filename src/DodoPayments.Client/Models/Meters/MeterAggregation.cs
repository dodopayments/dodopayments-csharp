using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(ModelConverter<MeterAggregation, MeterAggregationFromRaw>))]
public sealed record class MeterAggregation : ModelBase
{
    /// <summary>
    /// Aggregation type for the meter
    /// </summary>
    public required ApiEnum<string, global::DodoPayments.Client.Models.Meters.Type> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    ApiEnum<string, global::DodoPayments.Client.Models.Meters.Type>
                >(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentNullException("type")
                );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Required when type is not COUNT
    /// </summary>
    public string? Key
    {
        get
        {
            if (!this._rawData.TryGetValue("key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Key;
    }

    public MeterAggregation() { }

    public MeterAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class MeterAggregationFromRaw : IFromRaw<MeterAggregation>
{
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
