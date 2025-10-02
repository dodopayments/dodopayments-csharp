using System;
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
            if (!this.Properties.TryGetValue("data", out JsonElement element))
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
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("done", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'done' cannot be null",
                    new ArgumentOutOfRangeException("done", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["done"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("iterator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["iterator"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("prev_iterator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prev_iterator"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebhookListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
