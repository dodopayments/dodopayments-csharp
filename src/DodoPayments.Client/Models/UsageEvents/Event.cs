using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.UsageEvents.EventProperties.MetadataProperties;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(ModelConverter<Event>))]
public sealed record class Event : ModelBase, IFromRaw<Event>
{
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("business_id");
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required DateTime Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                throw new ArgumentOutOfRangeException("timestamp", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Values can be string, integer, number, or boolean.
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Event FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
