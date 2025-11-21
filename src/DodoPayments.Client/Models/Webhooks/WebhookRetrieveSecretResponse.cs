using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

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
            if (!this._rawData.TryGetValue("secret", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'secret' cannot be null",
                    new ArgumentOutOfRangeException("secret", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'secret' cannot be null",
                    new ArgumentNullException("secret")
                );
        }
        init
        {
            this._rawData["secret"] = JsonSerializer.SerializeToElement(
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

    public WebhookRetrieveSecretResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRetrieveSecretResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static WebhookRetrieveSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookRetrieveSecretResponse(string secret)
        : this()
    {
        this.Secret = secret;
    }
}
