using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Webhooks;

/// <summary>
/// List all webhooks
/// </summary>
public sealed record class WebhookListParams : DodoPayments::ParamsBase
{
    /// <summary>
    /// The iterator returned from a prior invocation
    /// </summary>
    public string? Iterator
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("iterator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["iterator"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Limit the number of returned items
    /// </summary>
    public int? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/webhooks")
        {
            Query = this.QueryString(client),
        }.Uri;
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
