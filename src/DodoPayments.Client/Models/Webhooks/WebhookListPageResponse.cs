using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookListPageResponse, WebhookListPageResponseFromRaw>))]
public sealed record class WebhookListPageResponse : JsonModel
{
    /// <summary>
    /// List of webhoooks
    /// </summary>
    public required IReadOnlyList<WebhookDetails> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebhookDetails>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookDetails>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// true if no more values are to be fetched.
    /// </summary>
    public required bool Done
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("done");
        }
        init { this._rawData.Set("done", value); }
    }

    /// <summary>
    /// Cursor pointing to the next paginated object
    /// </summary>
    public string? Iterator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("iterator");
        }
        init { this._rawData.Set("iterator", value); }
    }

    /// <summary>
    /// Cursor pointing to the previous paginated object
    /// </summary>
    public string? PrevIterator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev_iterator");
        }
        init { this._rawData.Set("prev_iterator", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.Done;
        _ = this.Iterator;
        _ = this.PrevIterator;
    }

    public WebhookListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListPageResponse(WebhookListPageResponse webhookListPageResponse)
        : base(webhookListPageResponse) { }
#pragma warning restore CS8618

    public WebhookListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListPageResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListPageResponseFromRaw : IFromRawJson<WebhookListPageResponse>
{
    /// <inheritdoc/>
    public WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListPageResponse.FromRawUnchecked(rawData);
}
