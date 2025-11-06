using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Payments = DodoPayments.Client.Models.Payments;
using System = System;

namespace DodoPayments.Client.Models.CheckoutSessions;

public sealed record class CheckoutSessionCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<ProductCart> ProductCart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_cart", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_cart",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<ProductCart>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new System::ArgumentNullException("product_cart")
                );
        }
        set
        {
            this.BodyProperties["product_cart"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customers will never see payment methods that are not in this list. However,
    /// adding a method here does not guarantee customers will see it. Availability
    /// still depends on other factors (e.g., customer location, merchant settings).
    ///
    /// Disclaimar: Always provide 'credit' and 'debit' as a fallback. If all payment
    /// methods are unavailable, checkout session will fail.
    /// </summary>
    public List<ApiEnum<string, Payments::PaymentMethodTypes>>? AllowedPaymentMethodTypes
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

            return JsonSerializer.Deserialize<List<ApiEnum<string, Payments::PaymentMethodTypes>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["allowed_payment_method_types"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Billing address information for the session
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BillingAddress?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["billing_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public ApiEnum<string, Currency>? BillingCurrency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["billing_currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["confirm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public Customization? Customization
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Customization?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["customization"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? DiscountCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["discount_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public FeatureFlags? FeatureFlags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("feature_flags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FeatureFlags?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["feature_flags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this session
    /// </summary>
    public bool? Force3DS
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("force_3ds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["force_3ds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["return_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionData? SubscriptionData
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("subscription_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionData?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["subscription_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IDodoPaymentsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/checkouts")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<ProductCart>))]
public sealed record class ProductCart : ModelBase, IFromRaw<ProductCart>
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentNullException("product_id")
                );
        }
        set
        {
            this.Properties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public List<AttachAddon>? Addons
    {
        get
        {
            if (!this.Properties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`. Only applicable
    /// for one time payments
    ///
    /// If amount is not set for pay_what_you_want product, customer is allowed to
    /// select the amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.Amount;
    }

    public ProductCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProductCart FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(typeof(ModelConverter<BillingAddress>))]
public sealed record class BillingAddress : ModelBase, IFromRaw<BillingAddress>
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'country' cannot be null",
                    new System::ArgumentOutOfRangeException("country", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["city"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public string? Street
    {
        get
        {
            if (!this.Properties.TryGetValue("street", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["street"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public string? Zipcode
    {
        get
        {
            if (!this.Properties.TryGetValue("zipcode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["zipcode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Country.Validate();
        _ = this.City;
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillingAddress FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(ModelConverter<Customization>))]
public sealed record class Customization : ModelBase, IFromRaw<Customization>
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            if (!this.Properties.TryGetValue("force_language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["force_language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Show on demand tag
    ///
    /// Default is true
    /// </summary>
    public bool? ShowOnDemandTag
    {
        get
        {
            if (!this.Properties.TryGetValue("show_on_demand_tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["show_on_demand_tag"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Show order details by default
    ///
    /// Default is true
    /// </summary>
    public bool? ShowOrderDetails
    {
        get
        {
            if (!this.Properties.TryGetValue("show_order_details", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["show_order_details"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Theme of the page
    ///
    /// Default is `System`.
    /// </summary>
    public ApiEnum<string, Theme>? Theme
    {
        get
        {
            if (!this.Properties.TryGetValue("theme", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Theme>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["theme"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ForceLanguage;
        _ = this.ShowOnDemandTag;
        _ = this.ShowOrderDetails;
        this.Theme?.Validate();
    }

    public Customization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customization(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Customization FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Theme of the page
///
/// Default is `System`.
/// </summary>
[JsonConverter(typeof(ThemeConverter))]
public enum Theme
{
    Dark,
    Light,
    System,
}

sealed class ThemeConverter : JsonConverter<Theme>
{
    public override Theme Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dark" => Theme.Dark,
            "light" => Theme.Light,
            "system" => Theme.System,
            _ => (Theme)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Theme value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Theme.Dark => "dark",
                Theme.Light => "light",
                Theme.System => "system",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<FeatureFlags>))]
public sealed record class FeatureFlags : ModelBase, IFromRaw<FeatureFlags>
{
    /// <summary>
    /// if customer is allowed to change currency, set it to true
    ///
    /// Default is true
    /// </summary>
    public bool? AllowCurrencySelection
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_currency_selection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_currency_selection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the customer is allowed to apply discount code, set it to true.
    ///
    /// Default is true
    /// </summary>
    public bool? AllowDiscountCode
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_discount_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If phone number is collected from customer, set it to rue
    ///
    /// Default is true
    /// </summary>
    public bool? AllowPhoneNumberCollection
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "allow_phone_number_collection",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_phone_number_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the customer is allowed to add tax id, set it to true
    ///
    /// Default is true
    /// </summary>
    public bool? AllowTaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Set to true if a new customer object should be created. By default email is
    /// used to find an existing customer to attach the session to
    ///
    /// Default is false
    /// </summary>
    public bool? AlwaysCreateNewCustomer
    {
        get
        {
            if (!this.Properties.TryGetValue("always_create_new_customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["always_create_new_customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AllowCurrencySelection;
        _ = this.AllowDiscountCode;
        _ = this.AllowPhoneNumberCollection;
        _ = this.AllowTaxID;
        _ = this.AlwaysCreateNewCustomer;
    }

    public FeatureFlags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureFlags(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FeatureFlags FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<SubscriptionData>))]
public sealed record class SubscriptionData : ModelBase, IFromRaw<SubscriptionData>
{
    public OnDemandSubscription? OnDemand
    {
        get
        {
            if (!this.Properties.TryGetValue("on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OnDemandSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["on_demand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_period_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.OnDemand?.Validate();
        _ = this.TrialPeriodDays;
    }

    public SubscriptionData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionData(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionData FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
