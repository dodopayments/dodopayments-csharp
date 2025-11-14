using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(ModelConverter<CheckoutSessionRequest>))]
public sealed record class CheckoutSessionRequest : ModelBase, IFromRaw<CheckoutSessionRequest>
{
    public required List<ProductCartModel> ProductCart
    {
        get
        {
            if (!this._properties.TryGetValue("product_cart", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_cart",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<ProductCartModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new System::ArgumentNullException("product_cart")
                );
        }
        init
        {
            this._properties["product_cart"] = JsonSerializer.SerializeToElement(
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
    /// <para>Disclaimar: Always provide 'credit' and 'debit' as a fallback. If all
    /// payment methods are unavailable, checkout session will fail.</para>
    /// </summary>
    public List<ApiEnum<string, PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "allowed_payment_method_types",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PaymentMethodTypes>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["allowed_payment_method_types"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Billing address information for the session
    /// </summary>
    public CheckoutSessionRequestBillingAddress? BillingAddress
    {
        get
        {
            if (!this._properties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestBillingAddress?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_address"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("confirm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["confirm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customer details for the session
    /// </summary>
    public CustomerRequest? Customer
    {
        get
        {
            if (!this._properties.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerRequest?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public CheckoutSessionRequestCustomization? Customization
    {
        get
        {
            if (!this._properties.TryGetValue("customization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestCustomization?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["customization"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? DiscountCode
    {
        get
        {
            if (!this._properties.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["discount_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CheckoutSessionRequestFeatureFlags? FeatureFlags
    {
        get
        {
            if (!this._properties.TryGetValue("feature_flags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestFeatureFlags?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["feature_flags"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("force_3ds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["force_3ds"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["return_url"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue("show_saved_payment_methods", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CheckoutSessionRequestSubscriptionData? SubscriptionData
    {
        get
        {
            if (!this._properties.TryGetValue("subscription_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CheckoutSessionRequestSubscriptionData?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["subscription_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        _ = this.Force3DS;
        _ = this.Metadata;
        _ = this.ReturnURL;
        _ = this.ShowSavedPaymentMethods;
        this.SubscriptionData?.Validate();
    }

    public CheckoutSessionRequest() { }

    public CheckoutSessionRequest(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequest(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public CheckoutSessionRequest(List<ProductCartModel> productCart)
        : this()
    {
        this.ProductCart = productCart;
    }
}

[JsonConverter(typeof(ModelConverter<ProductCartModel>))]
public sealed record class ProductCartModel : ModelBase, IFromRaw<ProductCartModel>
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this._properties.TryGetValue("product_id", out JsonElement element))
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
        init
        {
            this._properties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["addons"] = JsonSerializer.SerializeToElement(
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
    /// <para>If amount is not set for pay_what_you_want product, customer is allowed
    /// to select the amount.</para>
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
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

    public ProductCartModel() { }

    public ProductCartModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCartModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ProductCartModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(typeof(ModelConverter<CheckoutSessionRequestBillingAddress>))]
public sealed record class CheckoutSessionRequestBillingAddress
    : ModelBase,
        IFromRaw<CheckoutSessionRequestBillingAddress>
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            if (!this._properties.TryGetValue("country", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'country' cannot be null",
                    new System::ArgumentOutOfRangeException("country", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["country"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["city"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["state"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("street", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["street"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("zipcode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["zipcode"] = JsonSerializer.SerializeToElement(
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

    public CheckoutSessionRequestBillingAddress() { }

    public CheckoutSessionRequestBillingAddress(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestBillingAddress(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequestBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public CheckoutSessionRequestBillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(ModelConverter<CheckoutSessionRequestCustomization>))]
public sealed record class CheckoutSessionRequestCustomization
    : ModelBase,
        IFromRaw<CheckoutSessionRequestCustomization>
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            if (!this._properties.TryGetValue("force_language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["force_language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Show on demand tag
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOnDemandTag
    {
        get
        {
            if (!this._properties.TryGetValue("show_on_demand_tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["show_on_demand_tag"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Show order details by default
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOrderDetails
    {
        get
        {
            if (!this._properties.TryGetValue("show_order_details", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["show_order_details"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Theme of the page
    ///
    /// <para>Default is `System`.</para>
    /// </summary>
    public ApiEnum<string, CheckoutSessionRequestCustomizationTheme>? Theme
    {
        get
        {
            if (!this._properties.TryGetValue("theme", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                CheckoutSessionRequestCustomizationTheme
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["theme"] = JsonSerializer.SerializeToElement(
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

    public CheckoutSessionRequestCustomization() { }

    public CheckoutSessionRequestCustomization(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomization(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequestCustomization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Theme of the page
///
/// <para>Default is `System`.</para>
/// </summary>
[JsonConverter(typeof(CheckoutSessionRequestCustomizationThemeConverter))]
public enum CheckoutSessionRequestCustomizationTheme
{
    Dark,
    Light,
    System,
}

sealed class CheckoutSessionRequestCustomizationThemeConverter
    : JsonConverter<CheckoutSessionRequestCustomizationTheme>
{
    public override CheckoutSessionRequestCustomizationTheme Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dark" => CheckoutSessionRequestCustomizationTheme.Dark,
            "light" => CheckoutSessionRequestCustomizationTheme.Light,
            "system" => CheckoutSessionRequestCustomizationTheme.System,
            _ => (CheckoutSessionRequestCustomizationTheme)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckoutSessionRequestCustomizationTheme value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckoutSessionRequestCustomizationTheme.Dark => "dark",
                CheckoutSessionRequestCustomizationTheme.Light => "light",
                CheckoutSessionRequestCustomizationTheme.System => "system",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<CheckoutSessionRequestFeatureFlags>))]
public sealed record class CheckoutSessionRequestFeatureFlags
    : ModelBase,
        IFromRaw<CheckoutSessionRequestFeatureFlags>
{
    /// <summary>
    /// if customer is allowed to change currency, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowCurrencySelection
    {
        get
        {
            if (!this._properties.TryGetValue("allow_currency_selection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["allow_currency_selection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the customer is allowed to apply discount code, set it to true.
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowDiscountCode
    {
        get
        {
            if (!this._properties.TryGetValue("allow_discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["allow_discount_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If phone number is collected from customer, set it to rue
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowPhoneNumberCollection
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "allow_phone_number_collection",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["allow_phone_number_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the customer is allowed to add tax id, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowTaxID
    {
        get
        {
            if (!this._properties.TryGetValue("allow_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["allow_tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Set to true if a new customer object should be created. By default email
    /// is used to find an existing customer to attach the session to
    ///
    /// <para>Default is false</para>
    /// </summary>
    public bool? AlwaysCreateNewCustomer
    {
        get
        {
            if (
                !this._properties.TryGetValue("always_create_new_customer", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["always_create_new_customer"] = JsonSerializer.SerializeToElement(
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

    public CheckoutSessionRequestFeatureFlags() { }

    public CheckoutSessionRequestFeatureFlags(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestFeatureFlags(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequestFeatureFlags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<CheckoutSessionRequestSubscriptionData>))]
public sealed record class CheckoutSessionRequestSubscriptionData
    : ModelBase,
        IFromRaw<CheckoutSessionRequestSubscriptionData>
{
    public OnDemandSubscription? OnDemand
    {
        get
        {
            if (!this._properties.TryGetValue("on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OnDemandSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["on_demand"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["trial_period_days"] = JsonSerializer.SerializeToElement(
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

    public CheckoutSessionRequestSubscriptionData() { }

    public CheckoutSessionRequestSubscriptionData(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestSubscriptionData(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CheckoutSessionRequestSubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
