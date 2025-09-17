using System;
using System.Net.Http;
using System.Text.Json;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Customers.CustomerPortal;

public sealed record class CustomerPortalCreateParams : Client::ParamsBase
{
    public required string CustomerID;

    /// <summary>
    /// If true, will send link to user.
    /// </summary>
    public bool? SendEmail
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("send_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["send_email"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/customer-portal/session", this.CustomerID)
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
