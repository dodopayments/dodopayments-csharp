using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Models.Payments;
using Client = DodoPayments.Client;
using SubscriptionUpdateParamsProperties = DodoPayments.Client.Models.Subscriptions.SubscriptionUpdateParamsProperties;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionUpdateParams : Client::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    public BillingAddress? Billing
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BillingAddress?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When set, the subscription will remain active until the end of billing period
    /// </summary>
    public bool? CancelAtNextBillingDate
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "cancel_at_next_billing_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["cancel_at_next_billing_date"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public SubscriptionUpdateParamsProperties::DisableOnDemand? DisableOnDemand
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("disable_on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionUpdateParamsProperties::DisableOnDemand?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["disable_on_demand"] = JsonSerializer.SerializeToElement(value); }
    }

    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? NextBillingDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("next_billing_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["next_billing_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public SubscriptionStatus? Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionStatus?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? TaxID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["tax_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}", this.SubscriptionID)
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
