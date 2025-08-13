using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Models.Payments;
using DodoPayments = DodoPayments;
using SubscriptionUpdateParamsProperties = DodoPayments.Models.Subscriptions.SubscriptionUpdateParamsProperties;

namespace DodoPayments.Models.Subscriptions;

public sealed record class SubscriptionUpdateParams : DodoPayments::ParamsBase
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
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing"] = JsonSerializer.SerializeToElement(value); }
    }

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

            return JsonSerializer.Deserialize<bool?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
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
                DodoPayments::ModelBase.SerializerOptions
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
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public SubscriptionStatus? Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionStatus?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
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
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["tax_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
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
