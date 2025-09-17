using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using IntersectionMember1Properties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties.IntersectionMember1Properties;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties;

[JsonConverter(typeof(Client::ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1
    : Client::ModelBase,
        Client::IFromRaw<IntersectionMember1>
{
    public required IntersectionMember1Properties::PayloadType PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("payload_type", "Missing required argument");

            return JsonSerializer.Deserialize<IntersectionMember1Properties::PayloadType>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payload_type");
        }
        set { this.Properties["payload_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.PayloadType.Validate();
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1Properties::PayloadType payloadType)
        : this()
    {
        this.PayloadType = payloadType;
    }
}
