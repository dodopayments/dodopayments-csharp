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
[JsonConverter(typeof(ModelConverter<MeterFilter, MeterFilterFromRaw>))]
public sealed record class MeterFilter : ModelBase
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required Clauses Clauses
    {
        get { return ModelBase.GetNotNullClass<Clauses>(this.RawData, "clauses"); }
        init { ModelBase.Set(this._rawData, "clauses", value); }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, MeterFilterConjunction> Conjunction
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MeterFilterConjunction>>(
                this.RawData,
                "conjunction"
            );
        }
        init { ModelBase.Set(this._rawData, "conjunction", value); }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

    public MeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFilterFromRaw : IFromRaw<MeterFilter>
{
    public MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterFilter.FromRawUnchecked(rawData);
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

    public Clauses(IReadOnlyList<ClausesMeterFilter> value, JsonElement? json = null)
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

    public bool TryPickNestedMeterFilters(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilter>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition>> directFilterConditions,
        System::Action<IReadOnlyList<ClausesMeterFilter>> nestedMeterFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterCondition> value:
                directFilterConditions(value);
                break;
            case List<ClausesMeterFilter> value:
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
        System::Func<IReadOnlyList<ClausesMeterFilter>, T> nestedMeterFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition> value => directFilterConditions(value),
            IReadOnlyList<ClausesMeterFilter> value => nestedMeterFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public static implicit operator Clauses(List<MeterFilterCondition> value) =>
        new((IReadOnlyList<MeterFilterCondition>)value);

    public static implicit operator Clauses(List<ClausesMeterFilter> value) =>
        new((IReadOnlyList<ClausesMeterFilter>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
    }

    public virtual bool Equals(Clauses? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
            var deserialized = JsonSerializer.Deserialize<List<ClausesMeterFilter>>(json, options);
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
[JsonConverter(typeof(ModelConverter<MeterFilterCondition, MeterFilterConditionFromRaw>))]
public sealed record class MeterFilterCondition : ModelBase
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Operator>>(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required MeterFilterConditionValue Value
    {
        get { return ModelBase.GetNotNullClass<MeterFilterConditionValue>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition() { }

    public MeterFilterCondition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFilterConditionFromRaw : IFromRaw<MeterFilterCondition>
{
    public MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterFilterCondition.FromRawUnchecked(rawData);
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

    public virtual bool Equals(MeterFilterConditionValue? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
[JsonConverter(typeof(ModelConverter<ClausesMeterFilter, ClausesMeterFilterFromRaw>))]
public sealed record class ClausesMeterFilter : ModelBase
{
    /// <summary>
    /// Level 1: Can be conditions or nested filters (2 more levels allowed)
    /// </summary>
    public required ClausesMeterFilterClauses Clauses
    {
        get
        {
            return ModelBase.GetNotNullClass<ClausesMeterFilterClauses>(this.RawData, "clauses");
        }
        init { ModelBase.Set(this._rawData, "clauses", value); }
    }

    public required ApiEnum<string, ClausesMeterFilterConjunction> Conjunction
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ClausesMeterFilterConjunction>>(
                this.RawData,
                "conjunction"
            );
        }
        init { ModelBase.Set(this._rawData, "conjunction", value); }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public ClausesMeterFilter() { }

    public ClausesMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterFromRaw : IFromRaw<ClausesMeterFilter>
{
    public ClausesMeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(ClausesMeterFilterClausesConverter))]
public record class ClausesMeterFilterClauses
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ClausesMeterFilterClauses(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>;
        return value != null;
    }

    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilterClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilter>;
        return value != null;
    }

    public void Switch(
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>
        > level1FilterConditions,
        System::Action<IReadOnlyList<ClausesMeterFilterClausesMeterFilter>> level1NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<ClausesMeterFilterClausesMeterFilterCondition> value:
                level1FilterConditions(value);
                break;
            case List<ClausesMeterFilterClausesMeterFilter> value:
                level1NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClausesMeterFilterClauses"
                );
        }
    }

    public T Match<T>(
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>,
            T
        > level1FilterConditions,
        System::Func<IReadOnlyList<ClausesMeterFilterClausesMeterFilter>, T> level1NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value =>
                level1FilterConditions(value),
            IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value => level1NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClauses"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterCondition> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>)value);

    public static implicit operator ClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilter> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilter>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClauses"
            );
        }
    }

    public virtual bool Equals(ClausesMeterFilterClauses? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ClausesMeterFilterClausesConverter : JsonConverter<ClausesMeterFilterClauses>
{
    public override ClausesMeterFilterClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterCondition>
            >(json, options);
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
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilter>
            >(json, options);
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
        ClausesMeterFilterClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ClausesMeterFilterClausesMeterFilterCondition,
        ClausesMeterFilterClausesMeterFilterConditionFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterCondition : ModelBase
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    public required ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator>
            >(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterConditionValue Value
    {
        get
        {
            return ModelBase.GetNotNullClass<ClausesMeterFilterClausesMeterFilterConditionValue>(
                this.RawData,
                "value"
            );
        }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterCondition() { }

    public ClausesMeterFilterClausesMeterFilterCondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterConditionFromRaw
    : IFromRaw<ClausesMeterFilterClausesMeterFilterCondition>
{
    public ClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterCondition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterConditionOperatorConverter))]
public enum ClausesMeterFilterClausesMeterFilterConditionOperator
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

sealed class ClausesMeterFilterClausesMeterFilterConditionOperatorConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterConditionOperator>
{
    public override ClausesMeterFilterClausesMeterFilterConditionOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            "not_equals" => ClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals,
            "greater_than" => ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan,
            "greater_than_or_equals" =>
                ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals,
            "less_than" => ClausesMeterFilterClausesMeterFilterConditionOperator.LessThan,
            "less_than_or_equals" =>
                ClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals,
            "contains" => ClausesMeterFilterClausesMeterFilterConditionOperator.Contains,
            "does_not_contain" =>
                ClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain,
            _ => (ClausesMeterFilterClausesMeterFilterConditionOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterConditionOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClausesMeterFilterClausesMeterFilterConditionOperator.Equals => "equals",
                ClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals => "not_equals",
                ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan => "greater_than",
                ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals =>
                    "greater_than_or_equals",
                ClausesMeterFilterClausesMeterFilterConditionOperator.LessThan => "less_than",
                ClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals =>
                    "less_than_or_equals",
                ClausesMeterFilterClausesMeterFilterConditionOperator.Contains => "contains",
                ClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain =>
                    "does_not_contain",
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
[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterConditionValueConverter))]
public record class ClausesMeterFilterClausesMeterFilterConditionValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(
        string value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(
        double value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(JsonElement json)
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
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
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
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        string value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        double value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        bool value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
            );
        }
    }

    public virtual bool Equals(ClausesMeterFilterClausesMeterFilterConditionValue? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ClausesMeterFilterClausesMeterFilterConditionValueConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterConditionValue>
{
    public override ClausesMeterFilterClausesMeterFilterConditionValue? Read(
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
        ClausesMeterFilterClausesMeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 2 nested filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ClausesMeterFilterClausesMeterFilter,
        ClausesMeterFilterClausesMeterFilterFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilter : ModelBase
{
    /// <summary>
    /// Level 2: Can be conditions or nested filters (1 more level allowed)
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterClauses Clauses
    {
        get
        {
            return ModelBase.GetNotNullClass<ClausesMeterFilterClausesMeterFilterClauses>(
                this.RawData,
                "clauses"
            );
        }
        init { ModelBase.Set(this._rawData, "clauses", value); }
    }

    public required ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction> Conjunction
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction>
            >(this.RawData, "conjunction");
        }
        init { ModelBase.Set(this._rawData, "conjunction", value); }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public ClausesMeterFilterClausesMeterFilter() { }

    public ClausesMeterFilterClausesMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterFromRaw : IFromRaw<ClausesMeterFilterClausesMeterFilter>
{
    public ClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterClausesConverter))]
public record class ClausesMeterFilterClausesMeterFilterClauses
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClausesMeterFilterClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterClauses(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickLevel2FilterConditions(
        [NotNullWhen(true)]
            out IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>;
        return value != null;
    }

    public bool TryPickLevel2NestedFilters(
        [NotNullWhen(true)]
            out IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>;
        return value != null;
    }

    public void Switch(
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
        > level2FilterConditions,
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
        > level2NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value:
                level2FilterConditions(value);
                break;
            case List<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value:
                level2NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
                );
        }
    }

    public T Match<T>(
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>,
            T
        > level2FilterConditions,
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>,
            T
        > level2NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value =>
                level2FilterConditions(value),
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value =>
                level2NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>)value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
            );
        }
    }

    public virtual bool Equals(ClausesMeterFilterClausesMeterFilterClauses? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ClausesMeterFilterClausesMeterFilterClausesConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterClauses>
{
    public override ClausesMeterFilterClausesMeterFilterClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
            >(json, options);
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
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
            >(json, options);
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
        ClausesMeterFilterClausesMeterFilterClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
    : ModelBase
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    public required ApiEnum<
        string,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
    > Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
                >
            >(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue Value
    {
        get
        {
            return ModelBase.GetNotNullClass<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                this.RawData,
                "value"
            );
        }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition() { }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionFromRaw
    : IFromRaw<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
{
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperatorConverter)
)]
public enum ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
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

sealed class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperatorConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator>
{
    public override ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            "not_equals" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals,
            "greater_than" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan,
            "greater_than_or_equals" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals,
            "less_than" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThan,
            "less_than_or_equals" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals,
            "contains" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Contains,
            "does_not_contain" =>
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain,
            _ => (ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals =>
                    "equals",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals =>
                    "not_equals",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan =>
                    "greater_than",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals =>
                    "greater_than_or_equals",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThan =>
                    "less_than",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals =>
                    "less_than_or_equals",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Contains =>
                    "contains",
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain =>
                    "does_not_contain",
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
[JsonConverter(
    typeof(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueConverter)
)]
public record class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        string value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        double value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        bool value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(JsonElement json)
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
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
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
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        string value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        double value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        bool value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
            );
        }
    }

    public virtual bool Equals(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>
{
    public override ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue? Read(
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
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ClausesMeterFilterClausesMeterFilterClausesMeterFilter,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterClausesMeterFilter : ModelBase
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required IReadOnlyList<Clause> Clauses
    {
        get { return ModelBase.GetNotNullClass<List<Clause>>(this.RawData, "clauses"); }
        init { ModelBase.Set(this._rawData, "clauses", value); }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Conjunction>>(
                this.RawData,
                "conjunction"
            );
        }
        init { ModelBase.Set(this._rawData, "conjunction", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter() { }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterClausesMeterFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ClausesMeterFilterClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterClausesMeterFilterFromRaw
    : IFromRaw<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
{
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<Clause, ClauseFromRaw>))]
public sealed record class Clause : ModelBase
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    public required ApiEnum<string, ClauseOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ClauseOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClauseValue Value
    {
        get { return ModelBase.GetNotNullClass<ClauseValue>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public Clause() { }

    public Clause(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClauseFromRaw : IFromRaw<Clause>
{
    public Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Clause.FromRawUnchecked(rawData);
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

    public virtual bool Equals(ClauseValue? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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

[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterConjunctionConverter))]
public enum ClausesMeterFilterClausesMeterFilterConjunction
{
    And,
    Or,
}

sealed class ClausesMeterFilterClausesMeterFilterConjunctionConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterConjunction>
{
    public override ClausesMeterFilterClausesMeterFilterConjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => ClausesMeterFilterClausesMeterFilterConjunction.And,
            "or" => ClausesMeterFilterClausesMeterFilterConjunction.Or,
            _ => (ClausesMeterFilterClausesMeterFilterConjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterConjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClausesMeterFilterClausesMeterFilterConjunction.And => "and",
                ClausesMeterFilterClausesMeterFilterConjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ClausesMeterFilterConjunctionConverter))]
public enum ClausesMeterFilterConjunction
{
    And,
    Or,
}

sealed class ClausesMeterFilterConjunctionConverter : JsonConverter<ClausesMeterFilterConjunction>
{
    public override ClausesMeterFilterConjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => ClausesMeterFilterConjunction.And,
            "or" => ClausesMeterFilterConjunction.Or,
            _ => (ClausesMeterFilterConjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterConjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClausesMeterFilterConjunction.And => "and",
                ClausesMeterFilterConjunction.Or => "or",
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
