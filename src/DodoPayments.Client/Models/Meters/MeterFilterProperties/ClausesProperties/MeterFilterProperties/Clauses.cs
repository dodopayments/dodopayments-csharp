using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public record class Clauses
{
    public object Value { get; private init; }

    public Clauses(List<ClausesProperties::MeterFilterCondition> value)
    {
        Value = value;
    }

    public Clauses(List<ClausesProperties::MeterFilter> value)
    {
        Value = value;
    }

    Clauses(UnknownVariant value)
    {
        Value = value;
    }

    public static Clauses CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilterCondition>? value
    )
    {
        value = this.Value as List<ClausesProperties::MeterFilterCondition>;
        return value != null;
    }

    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilter>? value
    )
    {
        value = this.Value as List<ClausesProperties::MeterFilter>;
        return value != null;
    }

    public void Switch(
        Action<List<ClausesProperties::MeterFilterCondition>> level1FilterConditions,
        Action<List<ClausesProperties::MeterFilter>> level1NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<ClausesProperties::MeterFilterCondition> value:
                level1FilterConditions(value);
                break;
            case List<ClausesProperties::MeterFilter> value:
                level1NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    public T Match<T>(
        Func<List<ClausesProperties::MeterFilterCondition>, T> level1FilterConditions,
        Func<List<ClausesProperties::MeterFilter>, T> level1NestedFilters
    )
    {
        return this.Value switch
        {
            List<ClausesProperties::MeterFilterCondition> value => level1FilterConditions(value),
            List<ClausesProperties::MeterFilter> value => level1NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                return new Clauses(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<ClausesProperties::MeterFilterCondition>'",
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
                return new Clauses(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<ClausesProperties::MeterFilter>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
