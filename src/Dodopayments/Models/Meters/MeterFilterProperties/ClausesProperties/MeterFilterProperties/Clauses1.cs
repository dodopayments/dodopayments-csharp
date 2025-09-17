using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClausesProperties = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;
using ClausesVariants = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(Clauses1Converter))]
public abstract record class Clauses1
{
    internal Clauses1() { }

    public static implicit operator Clauses1(
        List<ClausesProperties::MeterFilterCondition1> value
    ) => new ClausesVariants::Level1FilterConditions(value);

    public static implicit operator Clauses1(List<ClausesProperties::MeterFilter2> value) =>
        new ClausesVariants::Level1NestedFilters(value);

    public abstract void Validate();
}

sealed class Clauses1Converter : JsonConverter<Clauses1>
{
    public override Clauses1? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition1>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new ClausesVariants::Level1FilterConditions(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter2>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ClausesVariants::Level1NestedFilters(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses1 value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ClausesVariants::Level1FilterConditions(var level1FilterConditions) =>
                level1FilterConditions,
            ClausesVariants::Level1NestedFilters(var level1NestedFilters) => level1NestedFilters,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
