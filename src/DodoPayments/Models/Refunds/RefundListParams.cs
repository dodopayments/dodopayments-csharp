using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments = DodoPayments;
using RefundListParamsProperties = DodoPayments.Models.Refunds.RefundListParamsProperties;

namespace DodoPayments.Models.Refunds;

public sealed record class RefundListParams : DodoPayments::ParamsBase
{
    /// <summary>
    /// Get events after this created time
    /// </summary>
    public DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at_gte", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["created_at_gte"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["created_at_lte"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filter by customer_id
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["customer_id"] = JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// Filter by status
    /// </summary>
    public RefundListParamsProperties::Status? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RefundListParamsProperties::Status?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/refunds")
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
