using System;
using System.Net.Http;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Brands;

/// <summary>
/// Thin handler just calls `get_brand` and wraps in `Json(...)`
/// </summary>
public sealed record class BrandRetrieveParams : Client::ParamsBase
{
    public required string ID;

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/brands/{0}", this.ID)
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
