using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.UsageEvents.EventInputProperties.MetadataProperties;

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
                throw new ArgumentOutOfRangeException("customer_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("customer_id");
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
                throw new ArgumentOutOfRangeException("event_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("event_id");
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
                throw new ArgumentOutOfRangeException("event_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("event_name");
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
    public Dictionary<string, Metadata>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Metadata>?>(
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
