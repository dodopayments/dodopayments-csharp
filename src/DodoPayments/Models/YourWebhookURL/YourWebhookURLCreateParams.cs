using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Models.WebhookEvents;
using DodoPayments = DodoPayments;
using YourWebhookURLCreateParamsProperties = DodoPayments.Models.YourWebhookURL.YourWebhookURLCreateParamsProperties;

namespace DodoPayments.Models.YourWebhookURL;

public sealed record class YourWebhookURLCreateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string BusinessID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("business_id");
        }
        set { this.BodyProperties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The latest data at the time of delivery attempt
    /// </summary>
    public required YourWebhookURLCreateParamsProperties::Data Data
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<YourWebhookURLCreateParamsProperties::Data>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.BodyProperties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred (not necessarily the same of when
    /// it was delivered)
    /// </summary>
    public required DateTime Timestamp
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timestamp", out JsonElement element))
                throw new ArgumentOutOfRangeException("timestamp", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["timestamp"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Event types for Dodo events
    /// </summary>
    public required WebhookEventType Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<WebhookEventType>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string WebhookID
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("webhook-id", out JsonElement element))
                throw new ArgumentOutOfRangeException("webhook-id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("webhook-id");
        }
        set { this.HeaderProperties["webhook-id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string WebhookSignature
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("webhook-signature", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "webhook-signature",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("webhook-signature");
        }
        set
        {
            this.HeaderProperties["webhook-signature"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public required string WebhookTimestamp
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("webhook-timestamp", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "webhook-timestamp",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("webhook-timestamp");
        }
        set
        {
            this.HeaderProperties["webhook-timestamp"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/your-webhook-url")
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
        DodoPayments::IDodoPaymentsClient client
    )
    {
        DodoPayments::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            DodoPayments::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
