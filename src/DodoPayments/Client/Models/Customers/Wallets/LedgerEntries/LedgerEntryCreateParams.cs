using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Client = DodoPayments.Client;
using LedgerEntryCreateParamsProperties = DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.LedgerEntryCreateParamsProperties;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

public sealed record class LedgerEntryCreateParams : Client::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string CustomerID;

    public required long Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Currency of the wallet to adjust
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Type of ledger entry - credit or debit
    /// </summary>
    public required LedgerEntryCreateParamsProperties::EntryType EntryType
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("entry_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("entry_type", "Missing required argument");

            return JsonSerializer.Deserialize<LedgerEntryCreateParamsProperties::EntryType>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("entry_type");
        }
        set { this.BodyProperties["entry_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional idempotency key to prevent duplicate entries
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("idempotency_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["idempotency_key"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Reason
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/wallets/ledger-entries", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
