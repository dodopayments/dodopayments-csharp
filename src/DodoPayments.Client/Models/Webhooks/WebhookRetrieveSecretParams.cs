using System;
using System.Net.Http;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks;

/// <summary>
/// Get webhook secret by id
/// </summary>
public sealed record class WebhookRetrieveSecretParams : ParamsBase
{
    public required string WebhookID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/webhooks/{0}/secret", this.WebhookID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
