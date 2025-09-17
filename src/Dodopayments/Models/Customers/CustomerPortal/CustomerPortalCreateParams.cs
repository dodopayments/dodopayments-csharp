using System;
using System.Net.Http;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Customers.CustomerPortal;

public sealed record class CustomerPortalCreateParams : Dodopayments::ParamsBase
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

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["send_email"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/customer-portal/session", this.CustomerID)
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
