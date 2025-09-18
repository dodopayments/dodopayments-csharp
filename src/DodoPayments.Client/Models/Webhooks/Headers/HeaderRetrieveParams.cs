using System;
using System.Net.Http;

namespace DodoPayments.Client.Models.Webhooks.Headers;

/// <summary>
/// Get a webhook by id
/// </summary>
public sealed record class HeaderRetrieveParams : ParamsBase
{
    public required string WebhookID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/webhooks/{0}/headers", this.WebhookID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IDodoPaymentsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
