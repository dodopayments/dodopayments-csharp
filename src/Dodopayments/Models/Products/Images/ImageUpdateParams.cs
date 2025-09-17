using System;
using System.Net.Http;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Products.Images;

public sealed record class ImageUpdateParams : Dodopayments::ParamsBase
{
    public required string ID;

    public bool? ForceUpdate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("force_update", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["force_update"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/products/{0}/images", this.ID)
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
