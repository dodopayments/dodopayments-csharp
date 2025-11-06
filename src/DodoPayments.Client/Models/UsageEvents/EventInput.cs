using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(ModelConverter<EventInput>))]
public sealed record class EventInput : ModelBase, IFromRaw<EventInput>
{
    /// <summary>
    /// customer_id of the customer whose usage needs to be tracked
    /// </summary>
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
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
        set
        {
            this.Properties["customer_id"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("event_id", out JsonElement element))
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
        set
        {
            this.Properties["event_id"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("event_name", out JsonElement element))
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
        set
        {
            this.Properties["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom metadata. Only key value pairs are accepted, objects or arrays submitted
    /// will be rejected.
    /// </summary>
    public Dictionary<string, MetadataModel>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, MetadataModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom Timestamp. Defaults to current timestamp in UTC. Timestamps that are
    /// older that 1 hour or after 5 mins, from current timestamp, will be rejected.
    /// </summary>
    public DateTime? Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timestamp"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventInput(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventInput FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Metadata value can be a string, integer, number, or boolean
/// </summary>
[JsonConverter(typeof(MetadataModelConverter))]
public record class MetadataModel
{
    public object Value { get; private init; }

    public MetadataModel(string value)
    {
        Value = value;
    }

    public MetadataModel(double value)
    {
        Value = value;
    }

    public MetadataModel(bool value)
    {
        Value = value;
    }

    MetadataModel(UnknownVariant value)
    {
        Value = value;
    }

    public static MetadataModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MetadataModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class MetadataModelConverter : JsonConverter<MetadataModel>
{
    public override MetadataModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MetadataModel(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'string'",
                    e
                )
            );
        }

        try
        {
            return new MetadataModel(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'double'",
                    e
                )
            );
        }

        try
        {
            return new MetadataModel(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MetadataModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
