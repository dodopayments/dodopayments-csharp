using System;
using System.Net.Http;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Misc;

public sealed record class MiscListSupportedCountriesParams : Client::ParamsBase
{
    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/checkout/supported_countries"
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
