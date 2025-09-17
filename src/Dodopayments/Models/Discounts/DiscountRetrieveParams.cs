using System;
using System.Net.Http;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

/// <summary>
/// GET /discounts/{discount_id}
/// </summary>
public sealed record class DiscountRetrieveParams : Dodopayments::ParamsBase
{
    public required string DiscountID;

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
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
