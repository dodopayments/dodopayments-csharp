using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments = Dodopayments;
using SubscriptionChangePlanParamsProperties = Dodopayments.Models.Subscriptions.SubscriptionChangePlanParamsProperties;

namespace Dodopayments.Models.Subscriptions;

public sealed record class SubscriptionChangePlanParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product_id");
        }
        set { this.BodyProperties["product_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Proration Billing Mode
    /// </summary>
    public required SubscriptionChangePlanParamsProperties::ProrationBillingMode ProrationBillingMode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("proration_billing_mode", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "proration_billing_mode",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<SubscriptionChangePlanParamsProperties::ProrationBillingMode>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("proration_billing_mode");
        }
        set
        {
            this.BodyProperties["proration_billing_mode"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Addons for the new plan. Note : Leaving this empty would remove any existing addons
    /// </summary>
    public List<AttachAddon>? Addons
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["addons"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/change-plan", this.SubscriptionID)
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
