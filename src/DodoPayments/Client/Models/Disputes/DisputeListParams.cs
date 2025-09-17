using System;
using System.Net.Http;
using System.Text.Json;
using Client = DodoPayments.Client;
using DisputeListParamsProperties = DodoPayments.Client.Models.Disputes.DisputeListParamsProperties;

namespace DodoPayments.Client.Models.Disputes;

public sealed record class DisputeListParams : Client::ParamsBase
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/disputes")
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
