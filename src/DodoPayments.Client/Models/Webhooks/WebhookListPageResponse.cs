using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<WebhookListPageResponse, WebhookListPageResponseFromRaw>))]
public sealed record class WebhookListPageResponse : ModelBase
{
    /// <summary>
    /// List of webhoooks
    /// </summary>
    public required IReadOnlyList<WebhookDetails> Data
    {
        get { return ModelBase.GetNotNullClass<List<WebhookDetails>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// true if no more values are to be fetched.
    /// </summary>
    public required bool Done
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "done"); }
        init { ModelBase.Set(this._rawData, "done", value); }
    }

    /// <summary>
    /// Cursor pointing to the next paginated object
    /// </summary>
    public string? Iterator
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "iterator"); }
        init { ModelBase.Set(this._rawData, "iterator", value); }
    }

    /// <summary>
    /// Cursor pointing to the previous paginated object
    /// </summary>
    public string? PrevIterator
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "prev_iterator"); }
        init { ModelBase.Set(this._rawData, "prev_iterator", value); }
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

    public WebhookListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class WebhookListPageResponseFromRaw : IFromRaw<WebhookListPageResponse>
{
    /// <inheritdoc/>
    public WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListPageResponse.FromRawUnchecked(rawData);
}
