using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Webhooks;

[JsonConverter(typeof(Dodopayments::ModelConverter<WebhookRetrieveSecretResponse>))]
public sealed record class WebhookRetrieveSecretResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<WebhookRetrieveSecretResponse>
{
    public required string Secret
    {
        get
        {
            if (!this.Properties.TryGetValue("secret", out JsonElement element))
                throw new ArgumentOutOfRangeException("secret", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("secret");
        }
        set { this.Properties["secret"] = JsonSerializer.SerializeToElement(value); }
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
