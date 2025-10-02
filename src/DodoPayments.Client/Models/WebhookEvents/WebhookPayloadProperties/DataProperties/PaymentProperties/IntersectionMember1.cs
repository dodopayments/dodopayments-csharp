using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.PaymentProperties.IntersectionMember1Properties;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.PaymentProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public required ApiEnum<string, PayloadType> PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payload_type' cannot be null",
                    new ArgumentOutOfRangeException("payload_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    public IntersectionMember1(ApiEnum<string, PayloadType> payloadType)
        : this()
    {
        this.PayloadType = payloadType;
    }
}
