using System.Net.Http;
using System.Text.Json;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Products;

public sealed record class ProductListParams : Client::ParamsBase
{
    /// <summary>
    /// List archived products
    /// </summary>
    public bool? Archived
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("archived", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["archived"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// filter by Brand id
    /// </summary>
    public string? BrandID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["brand_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
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

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["page_size"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filter products by pricing type: - `true`: Show only recurring pricing products
    /// (e.g. subscriptions) - `false`: Show only one-time price products - `null`
    /// or absent: Show both types of products
    /// </summary>
    public bool? Recurring
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("recurring", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["recurring"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Client::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/products")
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
