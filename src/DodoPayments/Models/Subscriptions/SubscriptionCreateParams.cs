using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Models.Misc;
using DodoPayments.Models.Payments;
using DodoPayments = DodoPayments;
using SubscriptionCreateParamsProperties = DodoPayments.Models.Subscriptions.SubscriptionCreateParamsProperties;

namespace DodoPayments.Models.Subscriptions;

public sealed record class SubscriptionCreateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Billing address information for the subscription
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing", out JsonElement element))
                throw new ArgumentOutOfRangeException("billing", "Missing required argument");

            return JsonSerializer.Deserialize<BillingAddress>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("billing");
        }
        set { this.BodyProperties["billing"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customer details for the subscription
    /// </summary>
    public required CustomerRequest Customer
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerRequest>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.BodyProperties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

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
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product_id");
        }
        set { this.BodyProperties["product_id"] = JsonSerializer.SerializeToElement(value); }
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
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Attach addons to this subscription
    /// </summary>
    public List<AttachAddon>? Addons
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["addons"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// List of payment methods allowed during checkout.
    ///
    /// Customers will **never** see payment methods that are **not** in this list.
    /// However, adding a method here **does not guarantee** customers will see it.
    /// Availability still depends on other factors (e.g., customer location, merchant settings).
    /// </summary>
    public List<PaymentMethodTypes>? AllowedPaymentMethodTypes
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "allowed_payment_method_types",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<PaymentMethodTypes>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["allowed_payment_method_types"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Fix the currency in which the end customer is billed. If Dodo Payments cannot
    /// support that currency for this transaction, it will not proceed
    /// </summary>
    public Currency? BillingCurrency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Currency?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing_currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Discount Code to apply to the subscription
    /// </summary>
    public string? DiscountCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["discount_code"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional metadata for the subscription Defaults to empty if not specified
    /// </summary>
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

    public SubscriptionCreateParamsProperties::OnDemand? OnDemand
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionCreateParamsProperties::OnDemand?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["on_demand"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If true, generates a payment link. Defaults to false if not specified.
    /// </summary>
    public bool? PaymentLink
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["payment_link"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional URL to redirect after successful subscription creation
    /// </summary>
    public string? ReturnURL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["return_url"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "show_saved_payment_methods",
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
            this.BodyProperties["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Tax ID in case the payment is B2B. If tax id validation fails the payment
    /// creation will fail
    /// </summary>
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

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["trial_period_days"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
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
