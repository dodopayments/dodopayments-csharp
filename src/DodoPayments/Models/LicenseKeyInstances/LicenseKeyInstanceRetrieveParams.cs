using System;
using System.Net.Http;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.LicenseKeyInstances;

public sealed record class LicenseKeyInstanceRetrieveParams : DodoPayments::ParamsBase
{
    public required string ID;

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/license_key_instances/{0}", this.ID)
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
