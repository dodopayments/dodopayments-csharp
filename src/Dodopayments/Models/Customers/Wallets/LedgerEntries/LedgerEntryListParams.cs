using System;
using System.Net.Http;
using System.Text.Json;
using Dodopayments = Dodopayments;
using Misc = Dodopayments.Models.Misc;

namespace Dodopayments.Models.Customers.Wallets.LedgerEntries;

public sealed record class LedgerEntryListParams : Dodopayments::ParamsBase
{
    public required string CustomerID;

    /// <summary>
    /// Optional currency filter
    /// </summary>
    public Misc::Currency? Currency
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Misc::Currency?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? PageNumber
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["page_number"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? PageSize
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["page_size"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/wallets/ledger-entries", this.CustomerID)
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
