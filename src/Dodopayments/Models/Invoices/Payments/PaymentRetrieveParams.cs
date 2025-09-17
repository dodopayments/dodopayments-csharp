using System;
using System.Net.Http;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Invoices.Payments;

public sealed record class PaymentRetrieveParams : Dodopayments::ParamsBase
{
    public required string PaymentID;

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/payments/{0}", this.PaymentID)
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
