using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required string CreatedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// An example webhook name.
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Metadata of the webhook
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Updated at timestamp
    /// </summary>
    public required string UpdatedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// Url endpoint of the webhook
    /// </summary>
    public required string URL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// Status of the webhook.
    ///
    /// <para>If true, events are not sent</para>
    /// </summary>
    public bool? Disabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "disabled"); }
        init { JsonModel.Set(this._rawData, "disabled", value); }
    }

    /// <summary>
    /// Filter events to the webhook.
    ///
    /// <para>Webhook event will only be sent for events in the list.</para>
    /// </summary>
    public IReadOnlyList<string>? FilterTypes
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "filter_types"); }
        init { JsonModel.Set(this._rawData, "filter_types", value); }
    }

    /// <summary>
    /// Configured rate limit
    /// </summary>
    public int? RateLimit
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "rate_limit"); }
        init { JsonModel.Set(this._rawData, "rate_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.UpdatedAt;
        _ = this.URL;
        _ = this.Disabled;
        _ = this.FilterTypes;
        _ = this.RateLimit;
    }

    public WebhookDetails() { }

    public WebhookDetails(WebhookDetails webhookDetails)
        : base(webhookDetails) { }

    public WebhookDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
