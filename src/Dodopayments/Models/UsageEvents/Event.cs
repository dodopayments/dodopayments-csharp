using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using MetadataProperties = Dodopayments.Models.UsageEvents.EventProperties.MetadataProperties;
using System = System;

namespace Dodopayments.Models.UsageEvents;

[JsonConverter(typeof(Dodopayments::ModelConverter<Event>))]
public sealed record class Event : Dodopayments::ModelBase, Dodopayments::IFromRaw<Event>
{
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "business_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public required System::DateTime Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timestamp",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["timestamp"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Values can be string, integer, number, or boolean.
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
