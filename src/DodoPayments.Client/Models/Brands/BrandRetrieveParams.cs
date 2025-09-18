using System;
using System.Net.Http;

namespace DodoPayments.Client.Models.Brands;

/// <summary>
/// Thin handler just calls `get_brand` and wraps in `Json(...)`
/// </summary>
public sealed record class BrandRetrieveParams : ParamsBase
{
    public required string ID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/brands/{0}", this.ID)
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
