using System;
using System.Net.Http;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Webhooks;

/// <summary>
/// Delete a webhook by id
/// </summary>
public sealed record class WebhookDeleteParams : DodoPayments::ParamsBase
{
    public required string WebhookID;

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/webhooks/{0}", this.WebhookID)
        )
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
