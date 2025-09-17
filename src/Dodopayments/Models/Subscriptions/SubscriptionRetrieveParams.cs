using System;
using System.Net.Http;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Subscriptions;

public sealed record class SubscriptionRetrieveParams : Dodopayments::ParamsBase
{
    public required string SubscriptionID;

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}", this.SubscriptionID)
        )
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
