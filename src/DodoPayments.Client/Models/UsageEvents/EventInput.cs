using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(ModelConverter<EventInput, EventInputFromRaw>))]
public sealed record class EventInput : ModelBase
{
    /// <summary>
    /// customer_id of the customer whose usage needs to be tracked
    /// </summary>
    public required string CustomerID
    {
        get
        {
            if (!this._rawData.TryGetValue("customer_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentOutOfRangeException("customer_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentNullException("customer_id")
                );
        }
        init
        {
            this._rawData["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event Id acts as an idempotency key. Any subsequent requests with the same
    /// event_id will be ignored
    /// </summary>
    public required string EventID
    {
        get
        {
            if (!this._rawData.TryGetValue("event_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'event_id' cannot be null",
                    new ArgumentOutOfRangeException("event_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'event_id' cannot be null",
                    new ArgumentNullException("event_id")
                );
        }
        init
        {
            this._rawData["event_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the event
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this._rawData.TryGetValue("event_name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentOutOfRangeException("event_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentNullException("event_name")
                );
        }
        init
        {
            this._rawData["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom metadata. Only key value pairs are accepted, objects or arrays submitted
    /// will be rejected.
    /// </summary>
    public IReadOnlyDictionary<string, MetadataModel>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, MetadataModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom Timestamp. Defaults to current timestamp in UTC. Timestamps that are
    /// older that 1 hour or after 5 mins, from current timestamp, will be rejected.
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CustomerID;
        _ = this.EventID;
        _ = this.EventName;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item.Validate();
            }
        }
        _ = this.Timestamp;
    }

    public EventInput() { }

    public EventInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static EventInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventInputFromRaw : IFromRaw<EventInput>
{
    public EventInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventInput.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata value can be a string, integer, number, or boolean
/// </summary>
[JsonConverter(typeof(MetadataModelConverter))]
public record class MetadataModel
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MetadataModel(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MetadataModel(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MetadataModel(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MetadataModel(JsonElement json)
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
                    "Data did not match any variant of MetadataModel"
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
                "Data did not match any variant of MetadataModel"
            ),
        };
    }

    public static implicit operator MetadataModel(string value) => new(value);

    public static implicit operator MetadataModel(double value) => new(value);

    public static implicit operator MetadataModel(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MetadataModel"
            );
        }
    }
}

sealed class MetadataModelConverter : JsonConverter<MetadataModel>
{
    public override MetadataModel? Read(
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

    public override void Write(
        Utf8JsonWriter writer,
        MetadataModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
