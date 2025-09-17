using System;
using System.Net.Http;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Webhooks;

/// <summary>
/// List all webhooks
/// </summary>
public sealed record class WebhookListParams : Dodopayments::ParamsBase
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
                Dodopayments::ModelBase.SerializerOptions
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/webhooks")
        {
            Query = this.QueryString(client),
        }.Uri;
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
