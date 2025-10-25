using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.DisputeExpiredWebhookEventProperties.DataProperties.IntersectionMember1Properties;

namespace DodoPayments.Client.Models.Webhooks.DisputeExpiredWebhookEventProperties.DataProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1Model>))]
public sealed record class IntersectionMember1Model : ModelBase, IFromRaw<IntersectionMember1Model>
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PayloadTypeModel>? PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadTypeModel>?>(
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
        this.PayloadType?.Validate();
    }

    public IntersectionMember1Model() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1Model(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1Model FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
