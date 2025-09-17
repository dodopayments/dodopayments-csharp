using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments.Models.Misc;
using CheckoutSessionCreateParamsProperties = Dodopayments.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties;
using Dodopayments = Dodopayments;
using Payments = Dodopayments.Models.Payments;

namespace Dodopayments.Models.CheckoutSessions;

public sealed record class CheckoutSessionCreateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<CheckoutSessionCreateParamsProperties::ProductCart> ProductCart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_cart", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_cart", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<CheckoutSessionCreateParamsProperties::ProductCart>
                >(element, Dodopayments::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("product_cart");
        }
        set { this.BodyProperties["product_cart"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customers will never see payment methods that are not in this list. However,
    /// adding a method here does not guarantee customers will see it. Availability
    /// still depends on other factors (e.g., customer location, merchant settings).
    ///
    /// Disclaimar: Always provide 'credit' and 'debit' as a fallback. If all payment
    /// methods are unavailable, checkout session will fail.
    /// </summary>
    public List<Payments::PaymentMethodTypes>? AllowedPaymentMethodTypes
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

            return JsonSerializer.Deserialize<List<Payments::PaymentMethodTypes>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
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
    /// Billing address information for the session
    /// </summary>
    public CheckoutSessionCreateParamsProperties::BillingAddress? BillingAddress
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionCreateParamsProperties::BillingAddress?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing_address"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public Currency? BillingCurrency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Currency?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing_currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If confirm is true, all the details will be finalized. If required data is
    /// missing, an API error is thrown.
    /// </summary>
    public bool? Confirm
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("confirm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["confirm"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customer details for the session
    /// </summary>
    public Payments::CustomerRequest? Customer
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Payments::CustomerRequest?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public CheckoutSessionCreateParamsProperties::Customization? Customization
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionCreateParamsProperties::Customization?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["customization"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? DiscountCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["discount_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public CheckoutSessionCreateParamsProperties::FeatureFlags? FeatureFlags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("feature_flags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionCreateParamsProperties::FeatureFlags?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["feature_flags"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The url to redirect after payment failure or success.
    /// </summary>
    public string? ReturnURL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public CheckoutSessionCreateParamsProperties::SubscriptionData? SubscriptionData
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("subscription_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionCreateParamsProperties::SubscriptionData?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["subscription_data"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/checkouts")
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
