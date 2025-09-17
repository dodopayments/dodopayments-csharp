using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Webhooks.Headers;

/// <summary>
/// Patch a webhook by id
/// </summary>
public sealed record class HeaderUpdateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string WebhookID;

    /// <summary>
    /// Object of header-value pair to update or add
    /// </summary>
    public required Dictionary<string, string> Headers
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("headers", out JsonElement element))
                throw new ArgumentOutOfRangeException("headers", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("headers");
        }
        set { this.BodyProperties["headers"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/webhooks/{0}/headers", this.WebhookID)
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
