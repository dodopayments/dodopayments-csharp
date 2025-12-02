using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<WebhookDetails, WebhookDetailsFromRaw>))]
public sealed record class WebhookDetails : ModelBase
{
    /// <summary>
    /// The webhook's ID.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required string CreatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// An example webhook name.
    /// </summary>
    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Metadata of the webhook
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Updated at timestamp
    /// </summary>
    public required string UpdatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "updated_at"); }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// Url endpoint of the webhook
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// Status of the webhook.
    ///
    /// <para>If true, events are not sent</para>
    /// </summary>
    public bool? Disabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "disabled"); }
        init { ModelBase.Set(this._rawData, "disabled", value); }
    }

    /// <summary>
    /// Filter events to the webhook.
    ///
    /// <para>Webhook event will only be sent for events in the list.</para>
    /// </summary>
    public IReadOnlyList<string>? FilterTypes
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "filter_types"); }
        init { ModelBase.Set(this._rawData, "filter_types", value); }
    }

    /// <summary>
    /// Configured rate limit
    /// </summary>
    public int? RateLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "rate_limit"); }
        init { ModelBase.Set(this._rawData, "rate_limit", value); }
    }

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

    public static WebhookDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookDetailsFromRaw : IFromRaw<WebhookDetails>
{
    public WebhookDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookDetails.FromRawUnchecked(rawData);
}
