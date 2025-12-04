using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.WebhookEvents;

namespace DodoPayments.Client.Models.Webhooks;

/// <summary>
/// Create a new webhook
/// </summary>
public sealed record class WebhookCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Url of the webhook
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "url"); }
        init { ModelBase.Set(this._rawBodyData, "url", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Create the webhook in a disabled state.
    ///
    /// <para>Default is false</para>
    /// </summary>
    public bool? Disabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "disabled"); }
        init { ModelBase.Set(this._rawBodyData, "disabled", value); }
    }

    /// <summary>
    /// Filter events to the webhook.
    ///
    /// <para>Webhook event will only be sent for events in the list.</para>
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookEventType>>? FilterTypes
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, WebhookEventType>>>(
                this.RawBodyData,
                "filter_types"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "filter_types", value);
        }
    }

    /// <summary>
    /// Custom headers to be passed
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "headers"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "headers", value); }
    }

    /// <summary>
    /// The request's idempotency key
    /// </summary>
    public string? IdempotencyKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "idempotency_key"); }
        init { ModelBase.Set(this._rawBodyData, "idempotency_key", value); }
    }

    /// <summary>
    /// Metadata to be passed to the webhook Defaut is {}
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
    }

    public int? RateLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawBodyData, "rate_limit"); }
        init { ModelBase.Set(this._rawBodyData, "rate_limit", value); }
    }

    public WebhookCreateParams() { }

    public WebhookCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static WebhookCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/webhooks")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
