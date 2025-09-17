using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments.Models.Misc;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Payments;

public sealed record class PaymentCreateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Billing address details for the payment
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing", out JsonElement element))
                throw new ArgumentOutOfRangeException("billing", "Missing required argument");

            return JsonSerializer.Deserialize<BillingAddress>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("billing");
        }
        set { this.BodyProperties["billing"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customer information for the payment
    /// </summary>
    public required CustomerRequest Customer
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerRequest>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.BodyProperties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// List of products in the cart. Must contain at least 1 and at most 100 items.
    /// </summary>
    public required List<OneTimeProductCartItem> ProductCart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_cart", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_cart", "Missing required argument");

            return JsonSerializer.Deserialize<List<OneTimeProductCartItem>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product_cart");
        }
        set { this.BodyProperties["product_cart"] = JsonSerializer.SerializeToElement(value); }
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["billing_currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Discount Code to apply to the transaction
    /// </summary>
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
    /// Whether to generate a payment link. Defaults to false if not specified.
    /// </summary>
    public bool? PaymentLink
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["payment_link"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional URL to redirect the customer after payment. Must be a valid URL
    /// if provided.
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["tax_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/payments")
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
