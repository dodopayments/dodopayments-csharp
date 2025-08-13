using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Payouts;

public sealed record class PayoutListParams : DodoPayments::ParamsBase
{
    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["page_number"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["page_size"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/payouts")
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
