using System;
using System.Net.Http;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// DELETE /discounts/{discount_id}
/// </summary>
public sealed record class DiscountDeleteParams : Client::ParamsBase
{
    public required string DiscountID;

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/{0}", this.DiscountID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
