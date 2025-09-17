using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;
using ClausesVariants = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesVariants;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties;

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public abstract record class Clauses
{
    internal Clauses() { }

    public static implicit operator Clauses(List<ClausesProperties::MeterFilterCondition> value) =>
        new ClausesVariants::DirectFilterConditions(value);

    public static implicit operator Clauses(List<ClausesProperties::MeterFilter1> value) =>
        new ClausesVariants::NestedMeterFilters(value);

    public abstract void Validate();
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new ClausesVariants::DirectFilterConditions(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter1>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ClausesVariants::NestedMeterFilters(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ClausesVariants::DirectFilterConditions(var directFilterConditions) =>
                directFilterConditions,
            ClausesVariants::NestedMeterFilters(var nestedMeterFilters) => nestedMeterFilters,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
