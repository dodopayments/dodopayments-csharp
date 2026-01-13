using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookDetails, WebhookDetailsFromRaw>))]
public sealed record class WebhookDetails : JsonModel
{
    /// <summary>
    /// The webhook's ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// An example webhook name.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Metadata of the webhook
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Updated at timestamp
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Url endpoint of the webhook
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Status of the webhook.
    ///
    /// <para>If true, events are not sent</para>
    /// </summary>
    public bool? Disabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disabled");
        }
        init { this._rawData.Set("disabled", value); }
    }

    /// <summary>
    /// Filter events to the webhook.
    ///
    /// <para>Webhook event will only be sent for events in the list.</para>
    /// </summary>
    public IReadOnlyList<string>? FilterTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("filter_types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "filter_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Configured rate limit
    /// </summary>
    public int? RateLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rate_limit");
        }
        init { this._rawData.Set("rate_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.UpdatedAt;
        _ = this.Url;
        _ = this.Disabled;
        _ = this.FilterTypes;
        _ = this.RateLimit;
    }

    public WebhookDetails() { }

    public WebhookDetails(WebhookDetails webhookDetails)
        : base(webhookDetails) { }

    public WebhookDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDetailsFromRaw.FromRawUnchecked"/>
    public static WebhookDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookDetailsFromRaw : IFromRawJson<WebhookDetails>
{
    /// <inheritdoc/>
    public WebhookDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookDetails.FromRawUnchecked(rawData);
}
