using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters;

/// <summary>
/// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
///
/// <para>Supports up to 3 levels of nesting to create complex filter expressions.
/// Each filter has a conjunction (and/or) and clauses that can be either direct conditions
/// or nested filters.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterMeterFilter>))]
public sealed record class MeterMeterFilter : ModelBase, IFromRaw<MeterMeterFilter>
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required Clauses Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Clauses>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, MeterMeterFilterConjunction> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MeterMeterFilterConjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterMeterFilter() { }

    public MeterMeterFilter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterMeterFilter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public record class Clauses
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Clauses(IReadOnlyList<MeterFilterCondition> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public Clauses(IReadOnlyList<MeterFilter> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public Clauses(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDirectFilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterCondition>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterCondition>;
        return value != null;
    }

    public bool TryPickNestedMeterFilters([NotNullWhen(true)] out IReadOnlyList<MeterFilter>? value)
    {
        value = this.Value as IReadOnlyList<MeterFilter>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition>> directFilterConditions,
        System::Action<IReadOnlyList<MeterFilter>> nestedMeterFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterCondition> value:
                directFilterConditions(value);
                break;
            case List<MeterFilter> value:
                nestedMeterFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterCondition>, T> directFilterConditions,
        System::Func<IReadOnlyList<MeterFilter>, T> nestedMeterFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition> value => directFilterConditions(value),
            IReadOnlyList<MeterFilter> value => nestedMeterFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public static implicit operator Clauses(List<MeterFilterCondition> value) =>
        new((IReadOnlyList<MeterFilterCondition>)value);

    public static implicit operator Clauses(List<MeterFilter> value) =>
        new((IReadOnlyList<MeterFilter>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
    }
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterCondition>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilter>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterCondition>))]
public sealed record class MeterFilterCondition : ModelBase, IFromRaw<MeterFilterCondition>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required MeterFilterConditionValue Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterFilterConditionValue>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition() { }

    public MeterFilterCondition(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Operator.Equals,
            "not_equals" => Operator.NotEquals,
            "greater_than" => Operator.GreaterThan,
            "greater_than_or_equals" => Operator.GreaterThanOrEquals,
            "less_than" => Operator.LessThan,
            "less_than_or_equals" => Operator.LessThanOrEquals,
            "contains" => Operator.Contains,
            "does_not_contain" => Operator.DoesNotContain,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Equals => "equals",
                Operator.NotEquals => "not_equals",
                Operator.GreaterThan => "greater_than",
                Operator.GreaterThanOrEquals => "greater_than_or_equals",
                Operator.LessThan => "less_than",
                Operator.LessThanOrEquals => "less_than_or_equals",
                Operator.Contains => "contains",
                Operator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(MeterFilterConditionValueConverter))]
public record class MeterFilterConditionValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MeterFilterConditionValue(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionValue(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionValue(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionValue(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of MeterFilterConditionValue"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator MeterFilterConditionValue(string value) => new(value);

    public static implicit operator MeterFilterConditionValue(double value) => new(value);

    public static implicit operator MeterFilterConditionValue(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterConditionValue"
            );
        }
    }
}

sealed class MeterFilterConditionValueConverter : JsonConverter<MeterFilterConditionValue>
{
    public override MeterFilterConditionValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 1 nested filter - can contain Level 2 filters
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter>))]
public sealed record class MeterFilter : ModelBase, IFromRaw<MeterFilter>
{
    /// <summary>
    /// Level 1: Can be conditions or nested filters (2 more levels allowed)
    /// </summary>
    public required MeterFilterClauses Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterFilterClauses>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MeterFilterConjunction> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

    public MeterFilter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(MeterFilterClausesConverter))]
public record class MeterFilterClauses
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MeterFilterClauses(
        IReadOnlyList<MeterFilterConditionModel> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public MeterFilterClauses(IReadOnlyList<MeterFilterModel> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public MeterFilterClauses(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterConditionModel>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterConditionModel>;
        return value != null;
    }

    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterModel>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterModel>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterConditionModel>> level1FilterConditions,
        System::Action<IReadOnlyList<MeterFilterModel>> level1NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterConditionModel> value:
                level1FilterConditions(value);
                break;
            case List<MeterFilterModel> value:
                level1NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of MeterFilterClauses"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterConditionModel>, T> level1FilterConditions,
        System::Func<IReadOnlyList<MeterFilterModel>, T> level1NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterConditionModel> value => level1FilterConditions(value),
            IReadOnlyList<MeterFilterModel> value => level1NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterClauses"
            ),
        };
    }

    public static implicit operator MeterFilterClauses(List<MeterFilterConditionModel> value) =>
        new((IReadOnlyList<MeterFilterConditionModel>)value);

    public static implicit operator MeterFilterClauses(List<MeterFilterModel> value) =>
        new((IReadOnlyList<MeterFilterModel>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterClauses"
            );
        }
    }
}

sealed class MeterFilterClausesConverter : JsonConverter<MeterFilterClauses>
{
    public override MeterFilterClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterConditionModel>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterModel>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterConditionModel>))]
public sealed record class MeterFilterConditionModel
    : ModelBase,
        IFromRaw<MeterFilterConditionModel>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MeterFilterConditionModelOperator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConditionModelOperator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required MeterFilterConditionModelValue Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterFilterConditionModelValue>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterConditionModel() { }

    public MeterFilterConditionModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterConditionModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterConditionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(MeterFilterConditionModelOperatorConverter))]
public enum MeterFilterConditionModelOperator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class MeterFilterConditionModelOperatorConverter
    : JsonConverter<MeterFilterConditionModelOperator>
{
    public override MeterFilterConditionModelOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => MeterFilterConditionModelOperator.Equals,
            "not_equals" => MeterFilterConditionModelOperator.NotEquals,
            "greater_than" => MeterFilterConditionModelOperator.GreaterThan,
            "greater_than_or_equals" => MeterFilterConditionModelOperator.GreaterThanOrEquals,
            "less_than" => MeterFilterConditionModelOperator.LessThan,
            "less_than_or_equals" => MeterFilterConditionModelOperator.LessThanOrEquals,
            "contains" => MeterFilterConditionModelOperator.Contains,
            "does_not_contain" => MeterFilterConditionModelOperator.DoesNotContain,
            _ => (MeterFilterConditionModelOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterConditionModelOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterFilterConditionModelOperator.Equals => "equals",
                MeterFilterConditionModelOperator.NotEquals => "not_equals",
                MeterFilterConditionModelOperator.GreaterThan => "greater_than",
                MeterFilterConditionModelOperator.GreaterThanOrEquals => "greater_than_or_equals",
                MeterFilterConditionModelOperator.LessThan => "less_than",
                MeterFilterConditionModelOperator.LessThanOrEquals => "less_than_or_equals",
                MeterFilterConditionModelOperator.Contains => "contains",
                MeterFilterConditionModelOperator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(MeterFilterConditionModelValueConverter))]
public record class MeterFilterConditionModelValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MeterFilterConditionModelValue(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionModelValue(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionModelValue(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterConditionModelValue(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of MeterFilterConditionModelValue"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterConditionModelValue"
            ),
        };
    }

    public static implicit operator MeterFilterConditionModelValue(string value) => new(value);

    public static implicit operator MeterFilterConditionModelValue(double value) => new(value);

    public static implicit operator MeterFilterConditionModelValue(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterConditionModelValue"
            );
        }
    }
}

sealed class MeterFilterConditionModelValueConverter : JsonConverter<MeterFilterConditionModelValue>
{
    public override MeterFilterConditionModelValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterConditionModelValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 2 nested filter
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterModel>))]
public sealed record class MeterFilterModel : ModelBase, IFromRaw<MeterFilterModel>
{
    /// <summary>
    /// Level 2: Can be conditions or nested filters (1 more level allowed)
    /// </summary>
    public required MeterFilterModelClauses Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterFilterModelClauses>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MeterFilterModelConjunction> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MeterFilterModelConjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilterModel() { }

    public MeterFilterModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(MeterFilterModelClausesConverter))]
public record class MeterFilterModelClauses
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MeterFilterModelClauses(
        IReadOnlyList<MeterFilterCondition1> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public MeterFilterModelClauses(IReadOnlyList<MeterFilter1> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public MeterFilterModelClauses(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickLevel2FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterCondition1>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterCondition1>;
        return value != null;
    }

    public bool TryPickLevel2NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilter1>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilter1>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition1>> level2FilterConditions,
        System::Action<IReadOnlyList<MeterFilter1>> level2NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterCondition1> value:
                level2FilterConditions(value);
                break;
            case List<MeterFilter1> value:
                level2NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of MeterFilterModelClauses"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterCondition1>, T> level2FilterConditions,
        System::Func<IReadOnlyList<MeterFilter1>, T> level2NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition1> value => level2FilterConditions(value),
            IReadOnlyList<MeterFilter1> value => level2NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterModelClauses"
            ),
        };
    }

    public static implicit operator MeterFilterModelClauses(List<MeterFilterCondition1> value) =>
        new((IReadOnlyList<MeterFilterCondition1>)value);

    public static implicit operator MeterFilterModelClauses(List<MeterFilter1> value) =>
        new((IReadOnlyList<MeterFilter1>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterModelClauses"
            );
        }
    }
}

sealed class MeterFilterModelClausesConverter : JsonConverter<MeterFilterModelClauses>
{
    public override MeterFilterModelClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterCondition1>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilter1>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterModelClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterCondition1>))]
public sealed record class MeterFilterCondition1 : ModelBase, IFromRaw<MeterFilterCondition1>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MeterFilterCondition1Operator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MeterFilterCondition1Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required MeterFilterCondition1Value Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterFilterCondition1Value>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition1() { }

    public MeterFilterCondition1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterCondition1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(MeterFilterCondition1OperatorConverter))]
public enum MeterFilterCondition1Operator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class MeterFilterCondition1OperatorConverter : JsonConverter<MeterFilterCondition1Operator>
{
    public override MeterFilterCondition1Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => MeterFilterCondition1Operator.Equals,
            "not_equals" => MeterFilterCondition1Operator.NotEquals,
            "greater_than" => MeterFilterCondition1Operator.GreaterThan,
            "greater_than_or_equals" => MeterFilterCondition1Operator.GreaterThanOrEquals,
            "less_than" => MeterFilterCondition1Operator.LessThan,
            "less_than_or_equals" => MeterFilterCondition1Operator.LessThanOrEquals,
            "contains" => MeterFilterCondition1Operator.Contains,
            "does_not_contain" => MeterFilterCondition1Operator.DoesNotContain,
            _ => (MeterFilterCondition1Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterCondition1Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterFilterCondition1Operator.Equals => "equals",
                MeterFilterCondition1Operator.NotEquals => "not_equals",
                MeterFilterCondition1Operator.GreaterThan => "greater_than",
                MeterFilterCondition1Operator.GreaterThanOrEquals => "greater_than_or_equals",
                MeterFilterCondition1Operator.LessThan => "less_than",
                MeterFilterCondition1Operator.LessThanOrEquals => "less_than_or_equals",
                MeterFilterCondition1Operator.Contains => "contains",
                MeterFilterCondition1Operator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(MeterFilterCondition1ValueConverter))]
public record class MeterFilterCondition1Value
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MeterFilterCondition1Value(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterCondition1Value(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterCondition1Value(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MeterFilterCondition1Value(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of MeterFilterCondition1Value"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterCondition1Value"
            ),
        };
    }

    public static implicit operator MeterFilterCondition1Value(string value) => new(value);

    public static implicit operator MeterFilterCondition1Value(double value) => new(value);

    public static implicit operator MeterFilterCondition1Value(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterCondition1Value"
            );
        }
    }
}

sealed class MeterFilterCondition1ValueConverter : JsonConverter<MeterFilterCondition1Value>
{
    public override MeterFilterCondition1Value? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterCondition1Value value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter1>))]
public sealed record class MeterFilter1 : ModelBase, IFromRaw<MeterFilter1>
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required List<Clause> Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Clause>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public MeterFilter1() { }

    public MeterFilter1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilter1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<Clause>))]
public sealed record class Clause : ModelBase, IFromRaw<Clause>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ClauseOperator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ClauseOperator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClauseValue Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ClauseValue>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public Clause() { }

    public Clause(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ClauseOperatorConverter))]
public enum ClauseOperator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class ClauseOperatorConverter : JsonConverter<ClauseOperator>
{
    public override ClauseOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => ClauseOperator.Equals,
            "not_equals" => ClauseOperator.NotEquals,
            "greater_than" => ClauseOperator.GreaterThan,
            "greater_than_or_equals" => ClauseOperator.GreaterThanOrEquals,
            "less_than" => ClauseOperator.LessThan,
            "less_than_or_equals" => ClauseOperator.LessThanOrEquals,
            "contains" => ClauseOperator.Contains,
            "does_not_contain" => ClauseOperator.DoesNotContain,
            _ => (ClauseOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClauseOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClauseOperator.Equals => "equals",
                ClauseOperator.NotEquals => "not_equals",
                ClauseOperator.GreaterThan => "greater_than",
                ClauseOperator.GreaterThanOrEquals => "greater_than_or_equals",
                ClauseOperator.LessThan => "less_than",
                ClauseOperator.LessThanOrEquals => "less_than_or_equals",
                ClauseOperator.Contains => "contains",
                ClauseOperator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(ClauseValueConverter))]
public record class ClauseValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClauseValue(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ClauseValue(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ClauseValue(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ClauseValue(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClauseValue"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClauseValue"
            ),
        };
    }

    public static implicit operator ClauseValue(string value) => new(value);

    public static implicit operator ClauseValue(double value) => new(value);

    public static implicit operator ClauseValue(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClauseValue"
            );
        }
    }
}

sealed class ClauseValueConverter : JsonConverter<ClauseValue>
{
    public override ClauseValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClauseValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ConjunctionConverter))]
public enum Conjunction
{
    And,
    Or,
}

sealed class ConjunctionConverter : JsonConverter<Conjunction>
{
    public override Conjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Conjunction.And,
            "or" => Conjunction.Or,
            _ => (Conjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Conjunction.And => "and",
                Conjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MeterFilterModelConjunctionConverter))]
public enum MeterFilterModelConjunction
{
    And,
    Or,
}

sealed class MeterFilterModelConjunctionConverter : JsonConverter<MeterFilterModelConjunction>
{
    public override MeterFilterModelConjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => MeterFilterModelConjunction.And,
            "or" => MeterFilterModelConjunction.Or,
            _ => (MeterFilterModelConjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterModelConjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterFilterModelConjunction.And => "and",
                MeterFilterModelConjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MeterFilterConjunctionConverter))]
public enum MeterFilterConjunction
{
    And,
    Or,
}

sealed class MeterFilterConjunctionConverter : JsonConverter<MeterFilterConjunction>
{
    public override MeterFilterConjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => MeterFilterConjunction.And,
            "or" => MeterFilterConjunction.Or,
            _ => (MeterFilterConjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterConjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterFilterConjunction.And => "and",
                MeterFilterConjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Logical conjunction to apply between clauses (and/or)
/// </summary>
[JsonConverter(typeof(MeterMeterFilterConjunctionConverter))]
public enum MeterMeterFilterConjunction
{
    And,
    Or,
}

sealed class MeterMeterFilterConjunctionConverter : JsonConverter<MeterMeterFilterConjunction>
{
    public override MeterMeterFilterConjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => MeterMeterFilterConjunction.And,
            "or" => MeterMeterFilterConjunction.Or,
            _ => (MeterMeterFilterConjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterMeterFilterConjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterMeterFilterConjunction.And => "and",
                MeterMeterFilterConjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
