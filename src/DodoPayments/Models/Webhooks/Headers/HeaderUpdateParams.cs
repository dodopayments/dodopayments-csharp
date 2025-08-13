using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Webhooks.Headers;

/// <summary>
/// Patch a webhook by id
/// </summary>
public sealed record class HeaderUpdateParams : DodoPayments::ParamsBase
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
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("headers");
        }
        set { this.BodyProperties["headers"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
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
