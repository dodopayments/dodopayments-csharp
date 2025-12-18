using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

public sealed record class CheckoutSessionCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyList<ProductCart> ProductCart
    {
        get
        {
            return JsonModel.GetNotNullClass<List<ProductCart>>(this.RawBodyData, "product_cart");
        }
        init { JsonModel.Set(this._rawBodyData, "product_cart", value); }
    }

    /// <summary>
    /// Customers will never see payment methods that are not in this list. However,
    /// adding a method here does not guarantee customers will see it. Availability
    /// still depends on other factors (e.g., customer location, merchant settings).
    ///
    /// <para>Disclaimar: Always provide 'credit' and 'debit' as a fallback. If all
    /// payment methods are unavailable, checkout session will fail.</para>
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Payments::PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, Payments::PaymentMethodTypes>>>(
                this.RawBodyData,
                "allowed_payment_method_types"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "allowed_payment_method_types", value); }
    }

    /// <summary>
    /// Billing address information for the session
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            return JsonModel.GetNullableClass<BillingAddress>(this.RawBodyData, "billing_address");
        }
        init { JsonModel.Set(this._rawBodyData, "billing_address", value); }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public ApiEnum<string, Currency>? BillingCurrency
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Currency>>(
                this.RawBodyData,
                "billing_currency"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "billing_currency", value); }
    }

    /// <summary>
    /// If confirm is true, all the details will be finalized. If required data is
    /// missing, an API error is thrown.
    /// </summary>
    public bool? Confirm
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "confirm"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "confirm", value);
        }
    }

    /// <summary>
    /// Customer details for the session
    /// </summary>
    public Payments::CustomerRequest? Customer
    {
        get
        {
            return JsonModel.GetNullableClass<Payments::CustomerRequest>(
                this.RawBodyData,
                "customer"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "customer", value); }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public Customization? Customization
    {
        get { return JsonModel.GetNullableClass<Customization>(this.RawBodyData, "customization"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "customization", value);
        }
    }

    public string? DiscountCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "discount_code"); }
        init { JsonModel.Set(this._rawBodyData, "discount_code", value); }
    }

    public FeatureFlags? FeatureFlags
    {
        get { return JsonModel.GetNullableClass<FeatureFlags>(this.RawBodyData, "feature_flags"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "feature_flags", value);
        }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this session
    /// </summary>
    public bool? Force3DS
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "force_3ds"); }
        init { JsonModel.Set(this._rawBodyData, "force_3ds", value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "metadata", value); }
    }

    /// <summary>
    /// If true, only zipcode is required when confirm is true; other address fields
    /// remain optional
    /// </summary>
    public bool? MinimalAddress
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "minimal_address"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "minimal_address", value);
        }
    }

    /// <summary>
    /// The url to redirect after payment failure or success.
    /// </summary>
    public string? ReturnURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "return_url"); }
        init { JsonModel.Set(this._rawBodyData, "return_url", value); }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(
                this.RawBodyData,
                "show_saved_payment_methods"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "show_saved_payment_methods", value);
        }
    }

    public SubscriptionData? SubscriptionData
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionData>(
                this.RawBodyData,
                "subscription_data"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "subscription_data", value); }
    }

    public CheckoutSessionCreateParams() { }

    public CheckoutSessionCreateParams(CheckoutSessionCreateParams checkoutSessionCreateParams)
        : base(checkoutSessionCreateParams)
    {
        this._rawBodyData = [.. checkoutSessionCreateParams._rawBodyData];
    }

    public CheckoutSessionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CheckoutSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/checkouts")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(JsonModelConverter<ProductCart, ProductCartFromRaw>))]
public sealed record class ProductCart : JsonModel
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public IReadOnlyList<Subscriptions::AttachAddon>? Addons
    {
        get
        {
            return JsonModel.GetNullableClass<List<Subscriptions::AttachAddon>>(
                this.RawData,
                "addons"
            );
        }
        init { JsonModel.Set(this._rawData, "addons", value); }
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
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
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

    public ProductCart() { }

    public ProductCart(ProductCart productCart)
        : base(productCart) { }

    public ProductCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCartFromRaw.FromRawUnchecked"/>
    public static ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCartFromRaw : IFromRawJson<ProductCart>
{
    /// <inheritdoc/>
    public ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, CountryCode>>(this.RawData, "country");
        }
        init { JsonModel.Set(this._rawData, "country", value); }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "city"); }
        init { JsonModel.Set(this._rawData, "city", value); }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public string? State
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "state"); }
        init { JsonModel.Set(this._rawData, "state", value); }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public string? Street
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "street"); }
        init { JsonModel.Set(this._rawData, "street", value); }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public string? Zipcode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "zipcode"); }
        init { JsonModel.Set(this._rawData, "zipcode", value); }
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

    public BillingAddress() { }

    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

class BillingAddressFromRaw : IFromRawJson<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Customization, CustomizationFromRaw>))]
public sealed record class Customization : JsonModel
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "force_language"); }
        init { JsonModel.Set(this._rawData, "force_language", value); }
    }

    /// <summary>
    /// Show on demand tag
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOnDemandTag
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "show_on_demand_tag"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "show_on_demand_tag", value);
        }
    }

    /// <summary>
    /// Show order details by default
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOrderDetails
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "show_order_details"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "show_order_details", value);
        }
    }

    /// <summary>
    /// Theme of the page
    ///
    /// <para>Default is `System`.</para>
    /// </summary>
    public ApiEnum<string, Theme>? Theme
    {
        get { return JsonModel.GetNullableClass<ApiEnum<string, Theme>>(this.RawData, "theme"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "theme", value);
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

    public Customization() { }

    public Customization(Customization customization)
        : base(customization) { }

    public Customization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomizationFromRaw.FromRawUnchecked"/>
    public static Customization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomizationFromRaw : IFromRawJson<Customization>
{
    /// <inheritdoc/>
    public Customization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customization.FromRawUnchecked(rawData);
}

/// <summary>
/// Theme of the page
///
/// <para>Default is `System`.</para>
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
        Type typeToConvert,
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

[JsonConverter(typeof(JsonModelConverter<FeatureFlags, FeatureFlagsFromRaw>))]
public sealed record class FeatureFlags : JsonModel
{
    /// <summary>
    /// if customer is allowed to change currency, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowCurrencySelection
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_currency_selection"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_currency_selection", value);
        }
    }

    public bool? AllowCustomerEditingCity
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_customer_editing_city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_city", value);
        }
    }

    public bool? AllowCustomerEditingCountry
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(
                this.RawData,
                "allow_customer_editing_country"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_country", value);
        }
    }

    public bool? AllowCustomerEditingEmail
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_customer_editing_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_email", value);
        }
    }

    public bool? AllowCustomerEditingName
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_customer_editing_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_name", value);
        }
    }

    public bool? AllowCustomerEditingState
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_customer_editing_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_state", value);
        }
    }

    public bool? AllowCustomerEditingStreet
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_customer_editing_street");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_street", value);
        }
    }

    public bool? AllowCustomerEditingZipcode
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(
                this.RawData,
                "allow_customer_editing_zipcode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_customer_editing_zipcode", value);
        }
    }

    /// <summary>
    /// If the customer is allowed to apply discount code, set it to true.
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowDiscountCode
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_discount_code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_discount_code", value);
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
            return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_phone_number_collection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_phone_number_collection", value);
        }
    }

    /// <summary>
    /// If the customer is allowed to add tax id, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowTaxID
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "allow_tax_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allow_tax_id", value);
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
            return JsonModel.GetNullableStruct<bool>(this.RawData, "always_create_new_customer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "always_create_new_customer", value);
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
    }

    public FeatureFlags() { }

    public FeatureFlags(FeatureFlags featureFlags)
        : base(featureFlags) { }

    public FeatureFlags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureFlags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFlagsFromRaw.FromRawUnchecked"/>
    public static FeatureFlags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFlagsFromRaw : IFromRawJson<FeatureFlags>
{
    /// <inheritdoc/>
    public FeatureFlags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeatureFlags.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SubscriptionData, SubscriptionDataFromRaw>))]
public sealed record class SubscriptionData : JsonModel
{
    public Subscriptions::OnDemandSubscription? OnDemand
    {
        get
        {
            return JsonModel.GetNullableClass<Subscriptions::OnDemandSubscription>(
                this.RawData,
                "on_demand"
            );
        }
        init { JsonModel.Set(this._rawData, "on_demand", value); }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "trial_period_days"); }
        init { JsonModel.Set(this._rawData, "trial_period_days", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OnDemand?.Validate();
        _ = this.TrialPeriodDays;
    }

    public SubscriptionData() { }

    public SubscriptionData(SubscriptionData subscriptionData)
        : base(subscriptionData) { }

    public SubscriptionData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionDataFromRaw : IFromRawJson<SubscriptionData>
{
    /// <inheritdoc/>
    public SubscriptionData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionData.FromRawUnchecked(rawData);
}
