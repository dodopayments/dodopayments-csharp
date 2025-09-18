using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Models.Subscriptions.SubscriptionListParamsProperties;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionListParams : ParamsBase
{
    /// <summary>
    /// filter by Brand id
    /// </summary>
    public string? BrandID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Get events after this created time
    /// </summary>
    public DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at_gte", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["created_at_gte"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Get events created before this time
    /// </summary>
    public DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at_lte", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["created_at_lte"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by customer id
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["page_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["page_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IDodoPaymentsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
