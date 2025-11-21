using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<WebhookListPageResponse>))]
public sealed record class WebhookListPageResponse : ModelBase, IFromRaw<WebhookListPageResponse>
{
    /// <summary>
    /// List of webhoooks
    /// </summary>
    public required List<WebhookDetails> Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<WebhookDetails>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("done", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'done' cannot be null",
                    new ArgumentOutOfRangeException("done", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["done"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cursor pointing to the next paginated object
    /// </summary>
    public string? Iterator
    {
        get
        {
            if (!this._rawData.TryGetValue("iterator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["iterator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cursor pointing to the previous paginated object
    /// </summary>
    public string? PrevIterator
    {
        get
        {
            if (!this._rawData.TryGetValue("prev_iterator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["prev_iterator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
