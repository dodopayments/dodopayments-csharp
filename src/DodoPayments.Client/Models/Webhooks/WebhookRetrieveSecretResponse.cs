using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(ModelConverter<WebhookRetrieveSecretResponse, WebhookRetrieveSecretResponseFromRaw>)
)]
public sealed record class WebhookRetrieveSecretResponse : ModelBase
{
    public required string Secret
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "secret"); }
        init { ModelBase.Set(this._rawData, "secret", value); }
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

class WebhookRetrieveSecretResponseFromRaw : IFromRaw<WebhookRetrieveSecretResponse>
{
    public WebhookRetrieveSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRetrieveSecretResponse.FromRawUnchecked(rawData);
}
