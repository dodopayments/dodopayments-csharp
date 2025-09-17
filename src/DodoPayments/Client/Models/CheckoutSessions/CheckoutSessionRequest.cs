using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Misc;
using CheckoutSessionRequestProperties = DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionRequestProperties;
using Client = DodoPayments.Client;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(Client::ModelConverter<CheckoutSessionRequest>))]
public sealed record class CheckoutSessionRequest
    : Client::ModelBase,
        Client::IFromRaw<CheckoutSessionRequest>
{
    public required List<CheckoutSessionRequestProperties::ProductCart> ProductCart
    {
        get
        {
            if (!this.Properties.TryGetValue("product_cart", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_cart", "Missing required argument");

            return JsonSerializer.Deserialize<List<CheckoutSessionRequestProperties::ProductCart>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product_cart");
        }
        set { this.Properties["product_cart"] = JsonSerializer.SerializeToElement(value); }
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
                !this.Properties.TryGetValue(
                    "allowed_payment_method_types",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<Payments::PaymentMethodTypes>?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["allowed_payment_method_types"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Billing address information for the session
    /// </summary>
    public CheckoutSessionRequestProperties::BillingAddress? BillingAddress
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestProperties::BillingAddress?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["billing_address"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public Currency? BillingCurrency
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Currency?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["billing_currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If confirm is true, all the details will be finalized. If required data is
    /// missing, an API error is thrown.
    /// </summary>
    public bool? Confirm
    {
        get
        {
            if (!this.Properties.TryGetValue("confirm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["confirm"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customer details for the session
    /// </summary>
    public Payments::CustomerRequest? Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Payments::CustomerRequest?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public CheckoutSessionRequestProperties::Customization? Customization
    {
        get
        {
            if (!this.Properties.TryGetValue("customization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestProperties::Customization?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["customization"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? DiscountCode
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discount_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public CheckoutSessionRequestProperties::FeatureFlags? FeatureFlags
    {
        get
        {
            if (!this.Properties.TryGetValue("feature_flags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestProperties::FeatureFlags?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["feature_flags"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The url to redirect after payment failure or success.
    /// </summary>
    public string? ReturnURL
    {
        get
        {
            if (!this.Properties.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["return_url"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            if (!this.Properties.TryGetValue("show_saved_payment_methods", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public CheckoutSessionRequestProperties::SubscriptionData? SubscriptionData
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestProperties::SubscriptionData?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["subscription_data"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.ProductCart)
        {
            item.Validate();
        }
        foreach (var item in this.AllowedPaymentMethodTypes ?? [])
        {
            item.Validate();
        }
        this.BillingAddress?.Validate();
        this.BillingCurrency?.Validate();
        _ = this.Confirm;
        this.Customer?.Validate();
        this.Customization?.Validate();
        _ = this.DiscountCode;
        this.FeatureFlags?.Validate();
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                _ = item;
            }
        }
        _ = this.ReturnURL;
        _ = this.ShowSavedPaymentMethods;
        this.SubscriptionData?.Validate();
    }

    public CheckoutSessionRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequest(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequest FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CheckoutSessionRequest(List<CheckoutSessionRequestProperties::ProductCart> productCart)
        : this()
    {
        this.ProductCart = productCart;
    }
}
