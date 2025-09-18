using System;
using System.Net.Http;

namespace DodoPayments.Client.Models.Meters;

public sealed record class MeterArchiveParams : ParamsBase
{
    public required string ID;

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/meters/{0}", this.ID)
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
