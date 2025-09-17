using System.Net.Http;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters;

public sealed record class MeterRetrieveParams : Client::ParamsBase
{
    public required string ID;

    public override System::Uri Url(Client::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/meters/{0}", this.ID)
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
