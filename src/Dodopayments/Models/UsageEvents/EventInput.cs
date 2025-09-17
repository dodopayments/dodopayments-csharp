using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using MetadataProperties = Dodopayments.Models.UsageEvents.EventInputProperties.MetadataProperties;
using System = System;

namespace Dodopayments.Models.UsageEvents;

[JsonConverter(typeof(Dodopayments::ModelConverter<EventInput>))]
public sealed record class EventInput : Dodopayments::ModelBase, Dodopayments::IFromRaw<EventInput>
{
    /// <summary>
    /// customer_id of the customer whose usage needs to be tracked
    /// </summary>
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("customer_id");
        }
        set { this.Properties["customer_id"] = JsonSerializer.SerializeToElement(value); }
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
                throw new System::ArgumentOutOfRangeException(
                    "event_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("event_id");
        }
        set { this.Properties["event_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Name of the event
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this.Properties.TryGetValue("event_name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "event_name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("event_name");
        }
        set { this.Properties["event_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Custom metadata. Only key value pairs are accepted, objects or arrays submitted
    /// will be rejected.
    /// </summary>
    public Dictionary<string, MetadataProperties::Metadata>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, MetadataProperties::Metadata>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Custom Timestamp. Defaults to current timestamp in UTC. Timestamps that are
    /// older that 1 hour or after 5 mins, from current timestamp, will be rejected.
    /// </summary>
    public System::DateTime? Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["timestamp"] = JsonSerializer.SerializeToElement(value); }
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
