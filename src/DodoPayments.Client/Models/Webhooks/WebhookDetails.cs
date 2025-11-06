using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<WebhookDetails>))]
public sealed record class WebhookDetails : ModelBase, IFromRaw<WebhookDetails>
{
    /// <summary>
    /// The webhook's ID.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentNullException("created_at")
                );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An example webhook name.
    /// </summary>
    public required string Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'description' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "description",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'description' cannot be null",
                    new System::ArgumentNullException("description")
                );
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Metadata of the webhook
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "updated_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new System::ArgumentNullException("updated_at")
                );
        }
        set
        {
            this.Properties["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Url endpoint of the webhook
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the webhook.
    ///
    /// If true, events are not sent
    /// </summary>
    public bool? Disabled
    {
        get
        {
            if (!this.Properties.TryGetValue("disabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["disabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter events to the webhook.
    ///
    /// Webhook event will only be sent for events in the list.
    /// </summary>
    public List<string>? FilterTypes
    {
        get
        {
            if (!this.Properties.TryGetValue("filter_types", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filter_types"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("rate_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["rate_limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDetails(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebhookDetails FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
