using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments.Models.WebhookEvents;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Webhooks;

/// <summary>
/// Patch a webhook by id
/// </summary>
public sealed record class WebhookUpdateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string WebhookID;

    /// <summary>
    /// Description of the webhook
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// To Disable the endpoint, set it to true.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("disabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["disabled"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filter events to the endpoint.
    ///
    /// Webhook event will only be sent for events in the list.
    /// </summary>
    public List<WebhookEventType>? FilterTypes
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("filter_types", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<WebhookEventType>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["filter_types"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Metadata
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Rate limit
    /// </summary>
    public int? RateLimit
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("rate_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["rate_limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Url endpoint
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/webhooks/{0}", this.WebhookID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        Dodopayments::IDodoPaymentsClient client
    )
    {
        Dodopayments::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Dodopayments::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
