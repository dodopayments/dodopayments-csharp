using System.Net.Http;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters;

public sealed record class MeterRetrieveParams : Dodopayments::ParamsBase
{
    public required string ID;

    public override System::Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/meters/{0}", this.ID)
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
