using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<CheckoutSessionRequest, CheckoutSessionRequestFromRaw>))]
public sealed record class CheckoutSessionRequest : JsonModel
{
    public required IReadOnlyList<CheckoutSessionRequestProductCart> ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CheckoutSessionRequestProductCart>
            >("product_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckoutSessionRequestProductCart>>(
                "product_cart",
                ImmutableArray.ToImmutableArray(value)
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
    public IReadOnlyList<ApiEnum<string, PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentMethodTypes>>
            >("allowed_payment_method_types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, PaymentMethodTypes>>?>(
                "allowed_payment_method_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestBillingAddress>(
                "billing_address"
            );
        }
        init { this._rawData.Set("billing_address", value); }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public ApiEnum<string, Currency>? BillingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("billing_currency");
        }
        init { this._rawData.Set("billing_currency", value); }
    }

    /// <summary>
    /// If confirm is true, all the details will be finalized. If required data is
    /// missing, an API error is thrown.
    /// </summary>
    public bool? Confirm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirm");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirm", value);
        }
    }

    /// <summary>
    /// Customer details for the session
    /// </summary>
    public CustomerRequest? Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerRequest>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public CheckoutSessionRequestCustomization? Customization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestCustomization>(
                "customization"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customization", value);
        }
    }

    public string? DiscountCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_code");
        }
        init { this._rawData.Set("discount_code", value); }
    }

    public CheckoutSessionRequestFeatureFlags? FeatureFlags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestFeatureFlags>(
                "feature_flags"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("feature_flags", value);
        }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this session
    /// </summary>
    public bool? Force3ds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("force_3ds");
        }
        init { this._rawData.Set("force_3ds", value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// If true, only zipcode is required when confirm is true; other address fields
    /// remain optional
    /// </summary>
    public bool? MinimalAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("minimal_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minimal_address", value);
        }
    }

    /// <summary>
    /// Optional payment method ID to use for this checkout session. Only allowed
    /// when `confirm` is true. If provided, existing customer id must also be provided.
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method_id");
        }
        init { this._rawData.Set("payment_method_id", value); }
    }

    /// <summary>
    /// The url to redirect after payment failure or success.
    /// </summary>
    public string? ReturnUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_url");
        }
        init { this._rawData.Set("return_url", value); }
    }

    /// <summary>
    /// If true, returns a shortened checkout URL. Defaults to false if not specified.
    /// </summary>
    public bool? ShortLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("short_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("short_link", value);
        }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("show_saved_payment_methods");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show_saved_payment_methods", value);
        }
    }

    public CheckoutSessionRequestSubscriptionData? SubscriptionData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestSubscriptionData>(
                "subscription_data"
            );
        }
        init { this._rawData.Set("subscription_data", value); }
    }

    /// <inheritdoc/>
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
        _ = this.Force3ds;
        _ = this.Metadata;
        _ = this.MinimalAddress;
        _ = this.PaymentMethodID;
        _ = this.ReturnUrl;
        _ = this.ShortLink;
        _ = this.ShowSavedPaymentMethods;
        this.SubscriptionData?.Validate();
    }

    public CheckoutSessionRequest() { }

    public CheckoutSessionRequest(CheckoutSessionRequest checkoutSessionRequest)
        : base(checkoutSessionRequest) { }

    public CheckoutSessionRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckoutSessionRequest(List<CheckoutSessionRequestProductCart> productCart)
        : this()
    {
        this.ProductCart = productCart;
    }
}

class CheckoutSessionRequestFromRaw : IFromRawJson<CheckoutSessionRequest>
{
    /// <inheritdoc/>
    public CheckoutSessionRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestProductCart,
        CheckoutSessionRequestProductCartFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestProductCart : JsonModel
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public IReadOnlyList<Subscriptions::AttachAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Subscriptions::AttachAddon>>(
                "addons"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::AttachAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <inheritdoc/>
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

    public CheckoutSessionRequestProductCart() { }

    public CheckoutSessionRequestProductCart(
        CheckoutSessionRequestProductCart checkoutSessionRequestProductCart
    )
        : base(checkoutSessionRequestProductCart) { }

    public CheckoutSessionRequestProductCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestProductCartFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestProductCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestProductCartFromRaw : IFromRawJson<CheckoutSessionRequestProductCart>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestProductCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestProductCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestBillingAddress,
        CheckoutSessionRequestBillingAddressFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestBillingAddress : JsonModel
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CountryCode>>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public string? Zipcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("zipcode");
        }
        init { this._rawData.Set("zipcode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Country.Validate();
        _ = this.City;
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public CheckoutSessionRequestBillingAddress() { }

    public CheckoutSessionRequestBillingAddress(
        CheckoutSessionRequestBillingAddress checkoutSessionRequestBillingAddress
    )
        : base(checkoutSessionRequestBillingAddress) { }

    public CheckoutSessionRequestBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestBillingAddressFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckoutSessionRequestBillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

class CheckoutSessionRequestBillingAddressFromRaw
    : IFromRawJson<CheckoutSessionRequestBillingAddress>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestCustomization,
        CheckoutSessionRequestCustomizationFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestCustomization : JsonModel
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("force_language");
        }
        init { this._rawData.Set("force_language", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("show_on_demand_tag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show_on_demand_tag", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("show_order_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show_order_details", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CheckoutSessionRequestCustomizationTheme>
            >("theme");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("theme", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ForceLanguage;
        _ = this.ShowOnDemandTag;
        _ = this.ShowOrderDetails;
        this.Theme?.Validate();
    }

    public CheckoutSessionRequestCustomization() { }

    public CheckoutSessionRequestCustomization(
        CheckoutSessionRequestCustomization checkoutSessionRequestCustomization
    )
        : base(checkoutSessionRequestCustomization) { }

    public CheckoutSessionRequestCustomization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestCustomizationFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestCustomization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestCustomizationFromRaw : IFromRawJson<CheckoutSessionRequestCustomization>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestCustomization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestCustomization.FromRawUnchecked(rawData);
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
        Type typeToConvert,
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

[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestFeatureFlags,
        CheckoutSessionRequestFeatureFlagsFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestFeatureFlags : JsonModel
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_currency_selection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_currency_selection", value);
        }
    }

    public bool? AllowCustomerEditingCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_city", value);
        }
    }

    public bool? AllowCustomerEditingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_country", value);
        }
    }

    public bool? AllowCustomerEditingEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_email", value);
        }
    }

    public bool? AllowCustomerEditingName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_name", value);
        }
    }

    public bool? AllowCustomerEditingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_state", value);
        }
    }

    public bool? AllowCustomerEditingStreet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_street");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_street", value);
        }
    }

    public bool? AllowCustomerEditingZipcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_zipcode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_zipcode", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_discount_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_discount_code", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_phone_number_collection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_phone_number_collection", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_tax_id", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("always_create_new_customer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("always_create_new_customer", value);
        }
    }

    /// <summary>
    /// If true, redirects the customer immediately after payment completion
    ///
    /// <para>Default is false</para>
    /// </summary>
    public bool? RedirectImmediately
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("redirect_immediately");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("redirect_immediately", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowCurrencySelection;
        _ = this.AllowCustomerEditingCity;
        _ = this.AllowCustomerEditingCountry;
        _ = this.AllowCustomerEditingEmail;
        _ = this.AllowCustomerEditingName;
        _ = this.AllowCustomerEditingState;
        _ = this.AllowCustomerEditingStreet;
        _ = this.AllowCustomerEditingZipcode;
        _ = this.AllowDiscountCode;
        _ = this.AllowPhoneNumberCollection;
        _ = this.AllowTaxID;
        _ = this.AlwaysCreateNewCustomer;
        _ = this.RedirectImmediately;
    }

    public CheckoutSessionRequestFeatureFlags() { }

    public CheckoutSessionRequestFeatureFlags(
        CheckoutSessionRequestFeatureFlags checkoutSessionRequestFeatureFlags
    )
        : base(checkoutSessionRequestFeatureFlags) { }

    public CheckoutSessionRequestFeatureFlags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestFeatureFlags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestFeatureFlagsFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestFeatureFlags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestFeatureFlagsFromRaw : IFromRawJson<CheckoutSessionRequestFeatureFlags>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestFeatureFlags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestFeatureFlags.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestSubscriptionData,
        CheckoutSessionRequestSubscriptionDataFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestSubscriptionData : JsonModel
{
    public Subscriptions::OnDemandSubscription? OnDemand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Subscriptions::OnDemandSubscription>("on_demand");
        }
        init { this._rawData.Set("on_demand", value); }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("trial_period_days");
        }
        init { this._rawData.Set("trial_period_days", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OnDemand?.Validate();
        _ = this.TrialPeriodDays;
    }

    public CheckoutSessionRequestSubscriptionData() { }

    public CheckoutSessionRequestSubscriptionData(
        CheckoutSessionRequestSubscriptionData checkoutSessionRequestSubscriptionData
    )
        : base(checkoutSessionRequestSubscriptionData) { }

    public CheckoutSessionRequestSubscriptionData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestSubscriptionData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestSubscriptionDataFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestSubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestSubscriptionDataFromRaw
    : IFromRawJson<CheckoutSessionRequestSubscriptionData>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestSubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestSubscriptionData.FromRawUnchecked(rawData);
}
