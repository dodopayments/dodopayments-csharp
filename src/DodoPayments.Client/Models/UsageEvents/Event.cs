using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(ModelConverter<Event, EventFromRaw>))]
public sealed record class Event : ModelBase
{
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    public required string CustomerID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { ModelBase.Set(this._rawData, "customer_id", value); }
    }

    public required string EventID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "event_id"); }
        init { ModelBase.Set(this._rawData, "event_id", value); }
    }

    public required string EventName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "event_name"); }
        init { ModelBase.Set(this._rawData, "event_name", value); }
    }

    public required DateTimeOffset Timestamp
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Values can be string, integer, number, or boolean.
    /// </summary>
    public IReadOnlyDictionary<string, Metadata>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Metadata>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CustomerID;
        _ = this.EventID;
        _ = this.EventName;
        _ = this.Timestamp;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item.Validate();
            }
        }
    }

    public Event() { }

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRaw<Event>
{
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata value can be a string, integer, number, or boolean
/// </summary>
[JsonConverter(typeof(MetadataConverter))]
public record class Metadata
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Metadata(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Metadata(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Metadata(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Metadata(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNumber([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBoolean([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<double> @number, Action<bool> @boolean)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @number(value);
                break;
            case bool value:
                @boolean(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Metadata"
                );
        }
    }

    public T Match<T>(Func<string, T> @string, Func<double, T> @number, Func<bool, T> @boolean)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @number(value),
            bool value => @boolean(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Metadata"
            ),
        };
    }

    public static implicit operator Metadata(string value) => new(value);

    public static implicit operator Metadata(double value) => new(value);

    public static implicit operator Metadata(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Metadata"
            );
        }
    }

    public virtual bool Equals(Metadata? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
