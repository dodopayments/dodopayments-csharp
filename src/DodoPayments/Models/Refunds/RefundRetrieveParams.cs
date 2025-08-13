using System;
using System.Net.Http;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Refunds;

public sealed record class RefundRetrieveParams : DodoPayments::ParamsBase
{
    public required string RefundID;

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/refunds/{0}", this.RefundID)
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
