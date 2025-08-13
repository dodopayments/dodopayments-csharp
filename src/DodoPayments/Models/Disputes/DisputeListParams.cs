using System;
using System.Net.Http;
using System.Text.Json;
using DisputeListParamsProperties = DodoPayments.Models.Disputes.DisputeListParamsProperties;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Disputes;

public sealed record class DisputeListParams : DodoPayments::ParamsBase
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
    /// Filter by dispute stage
    /// </summary>
    public DisputeListParamsProperties::DisputeStage1? DisputeStage
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("dispute_stage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DisputeListParamsProperties::DisputeStage1?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["dispute_stage"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filter by dispute status
    /// </summary>
    public DisputeListParamsProperties::DisputeStatus1? DisputeStatus
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("dispute_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DisputeListParamsProperties::DisputeStatus1?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["dispute_status"] = JsonSerializer.SerializeToElement(value); }
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

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/disputes")
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
