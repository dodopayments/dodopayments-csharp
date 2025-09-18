using System;
using System.Net.Http;

namespace DodoPayments.Client.Models.Invoices.Payments;

public sealed record class PaymentRetrieveRefundParams : ParamsBase
{
    public required string RefundID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/refunds/{0}", this.RefundID)
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
