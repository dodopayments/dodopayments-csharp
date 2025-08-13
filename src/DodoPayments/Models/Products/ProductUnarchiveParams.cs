using System.Net.Http;
using DodoPayments = DodoPayments;
using System = System;

namespace DodoPayments.Models.Products;

public sealed record class ProductUnarchiveParams : DodoPayments::ParamsBase
{
    public required string ID;

    public override System::Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/products/{0}/unarchive", this.ID)
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
