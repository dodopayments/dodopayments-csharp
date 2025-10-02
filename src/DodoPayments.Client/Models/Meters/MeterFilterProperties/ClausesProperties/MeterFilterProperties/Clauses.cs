using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public abstract record class Clauses
{
    internal Clauses() { }

    public static implicit operator Clauses(List<ClausesProperties::MeterFilterCondition> value) =>
        new Level1FilterConditions(value);

    public static implicit operator Clauses(List<ClausesProperties::MeterFilter> value) =>
        new Level1NestedFilters(value);

    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilterCondition>? value
    )
    {
        value = (this as Level1FilterConditions)?.Value;
        return value != null;
    }

    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilter>? value
    )
    {
        value = (this as Level1NestedFilters)?.Value;
        return value != null;
    }

    public void Switch(
        Action<Level1FilterConditions> level1FilterConditions,
        Action<Level1NestedFilters> level1NestedFilters
    )
    {
        switch (this)
        {
            case Level1FilterConditions inner:
                level1FilterConditions(inner);
                break;
            case Level1NestedFilters inner:
                level1NestedFilters(inner);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    public T Match<T>(
        Func<Level1FilterConditions, T> level1FilterConditions,
        Func<Level1NestedFilters, T> level1NestedFilters
    )
    {
        return this switch
        {
            Level1FilterConditions inner => level1FilterConditions(inner),
            Level1NestedFilters inner => level1NestedFilters(inner),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new Level1FilterConditions(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant Level1FilterConditions",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Level1NestedFilters(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant Level1NestedFilters",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            Level1FilterConditions(var level1FilterConditions) => level1FilterConditions,
            Level1NestedFilters(var level1NestedFilters) => level1NestedFilters,
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
