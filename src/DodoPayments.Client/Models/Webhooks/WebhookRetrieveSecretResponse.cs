using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<WebhookRetrieveSecretResponse>))]
public sealed record class WebhookRetrieveSecretResponse
    : ModelBase,
        IFromRaw<WebhookRetrieveSecretResponse>
{
    public required string Secret
    {
        get
        {
            if (!this.Properties.TryGetValue("secret", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'secret' cannot be null",
                    new System::ArgumentOutOfRangeException("secret", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'secret' cannot be null",
                    new System::ArgumentNullException("secret")
                );
        }
        set
        {
            this.Properties["secret"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Secret;
    }

    public WebhookRetrieveSecretResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRetrieveSecretResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebhookRetrieveSecretResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public WebhookRetrieveSecretResponse(string secret)
        : this()
    {
        this.Secret = secret;
    }
}
