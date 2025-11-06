using System.Net.Http;
using DodoPayments.Client.Core;
using System = System;

namespace DodoPayments.Client.Models.Meters;

public sealed record class MeterRetrieveParams : ParamsBase
{
    public required string ID;

    public override System::Uri Url(IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/meters/{0}", this.ID)
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
