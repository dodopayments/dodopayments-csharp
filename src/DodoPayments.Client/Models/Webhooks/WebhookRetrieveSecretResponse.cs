using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<WebhookRetrieveSecretResponse, WebhookRetrieveSecretResponseFromRaw>)
)]
public sealed record class WebhookRetrieveSecretResponse : JsonModel
{
    public required string Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Secret;
    }

    public WebhookRetrieveSecretResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRetrieveSecretResponse(
        WebhookRetrieveSecretResponse webhookRetrieveSecretResponse
    )
        : base(webhookRetrieveSecretResponse) { }
#pragma warning restore CS8618

    public WebhookRetrieveSecretResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRetrieveSecretResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRetrieveSecretResponseFromRaw.FromRawUnchecked"/>
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

class WebhookRetrieveSecretResponseFromRaw : IFromRawJson<WebhookRetrieveSecretResponse>
{
    /// <inheritdoc/>
    public WebhookRetrieveSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRetrieveSecretResponse.FromRawUnchecked(rawData);
}
