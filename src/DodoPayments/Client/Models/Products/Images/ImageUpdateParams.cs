using System;
using System.Net.Http;
using System.Text.Json;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Products.Images;

public sealed record class ImageUpdateParams : Client::ParamsBase
{
    public required string ID;

    public bool? ForceUpdate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("force_update", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["force_update"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/products/{0}/images", this.ID)
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
