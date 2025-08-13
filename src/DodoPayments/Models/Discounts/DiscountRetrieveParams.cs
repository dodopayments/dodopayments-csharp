using System;
using System.Net.Http;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Discounts;

/// <summary>
/// GET /discounts/{discount_id}
/// </summary>
public sealed record class DiscountRetrieveParams : DodoPayments::ParamsBase
{
    public required string DiscountID;

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/{0}", this.DiscountID)
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
