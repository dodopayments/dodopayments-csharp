using System;
using System.Net.Http;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// GET /discounts/{discount_id}
/// </summary>
public sealed record class DiscountRetrieveParams : ParamsBase
{
    public required string DiscountID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/{0}", this.DiscountID)
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
