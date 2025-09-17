using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using WebhookPayloadProperties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties;

namespace DodoPayments.Client.Models.WebhookEvents;

[JsonConverter(typeof(Client::ModelConverter<WebhookPayload>))]
public sealed record class WebhookPayload : Client::ModelBase, Client::IFromRaw<WebhookPayload>
{
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The latest data at the time of delivery attempt
    /// </summary>
    public required WebhookPayloadProperties::Data Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<WebhookPayloadProperties::Data>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred (not necessarily the same of when
    /// it was delivered)
    /// </summary>
    public required DateTime Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                throw new ArgumentOutOfRangeException("timestamp", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["timestamp"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Event types for Dodo events
    /// </summary>
    public required WebhookEventType Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<WebhookEventType>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public WebhookPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPayload(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebhookPayload FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
