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
            if (!this._rawBodyData.TryGetValue("product_cart", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new ArgumentOutOfRangeException("product_cart", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<ProductCart>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_cart' cannot be null",
                    new ArgumentNullException("product_cart")
                );
        }
        init
        {
            this._rawBodyData["product_cart"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyList<ApiEnum<string, Payments::PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            if (
                !this._rawBodyData.TryGetValue(
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
        init
        {
            this._rawBodyData["allowed_payment_method_types"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BillingAddress?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["billing_address"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("billing_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["billing_currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("confirm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["confirm"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Payments::CustomerRequest?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("customization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Customization?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["customization"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? DiscountCode
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["discount_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public FeatureFlags? FeatureFlags
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("feature_flags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FeatureFlags?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["feature_flags"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("force_3ds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["force_3ds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["return_url"] = JsonSerializer.SerializeToElement(
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
                !this._rawBodyData.TryGetValue(
                    "show_saved_payment_methods",
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

            this._rawBodyData["show_saved_payment_methods"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionData? SubscriptionData
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("subscription_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionData?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["subscription_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CheckoutSessionCreateParams() { }

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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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

[JsonConverter(typeof(ModelConverter<ProductCart, ProductCartFromRaw>))]
public sealed record class ProductCart : ModelBase
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this._rawData.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentOutOfRangeException("product_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentNullException("product_id")
                );
        }
        init
        {
            this._rawData["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Quantity
    {
        get
        {
            if (!this._rawData.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public IReadOnlyList<Subscriptions::AttachAddon>? Addons
    {
        get
        {
            if (!this._rawData.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Subscriptions::AttachAddon>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["addons"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
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

    public static ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCartFromRaw : IFromRaw<ProductCart>
{
    public ProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(typeof(ModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : ModelBase
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            if (!this._rawData.TryGetValue("country", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'country' cannot be null",
                    new ArgumentOutOfRangeException("country", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'country' cannot be null",
                    new ArgumentNullException("country")
                );
        }
        init
        {
            this._rawData["country"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["city"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["state"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("street", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["street"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("zipcode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["zipcode"] = JsonSerializer.SerializeToElement(
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

class BillingAddressFromRaw : IFromRaw<BillingAddress>
{
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(ModelConverter<Customization, CustomizationFromRaw>))]
public sealed record class Customization : ModelBase
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            if (!this._rawData.TryGetValue("force_language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["force_language"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("show_on_demand_tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["show_on_demand_tag"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("show_order_details", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["show_order_details"] = JsonSerializer.SerializeToElement(
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
    public ApiEnum<string, Theme>? Theme
    {
        get
        {
            if (!this._rawData.TryGetValue("theme", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Theme>?>(
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

            this._rawData["theme"] = JsonSerializer.SerializeToElement(
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

    public static Customization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomizationFromRaw : IFromRaw<Customization>
{
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

[JsonConverter(typeof(ModelConverter<FeatureFlags, FeatureFlagsFromRaw>))]
public sealed record class FeatureFlags : ModelBase
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
            if (!this._rawData.TryGetValue("allow_currency_selection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_currency_selection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingCity
    {
        get
        {
            if (!this._rawData.TryGetValue("allow_customer_editing_city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_customer_editing_city"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingCountry
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "allow_customer_editing_country",
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

            this._rawData["allow_customer_editing_country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingEmail
    {
        get
        {
            if (!this._rawData.TryGetValue("allow_customer_editing_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_customer_editing_email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingName
    {
        get
        {
            if (!this._rawData.TryGetValue("allow_customer_editing_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_customer_editing_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingState
    {
        get
        {
            if (!this._rawData.TryGetValue("allow_customer_editing_state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_customer_editing_state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingStreet
    {
        get
        {
            if (
                !this._rawData.TryGetValue("allow_customer_editing_street", out JsonElement element)
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

            this._rawData["allow_customer_editing_street"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? AllowCustomerEditingZipcode
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "allow_customer_editing_zipcode",
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

            this._rawData["allow_customer_editing_zipcode"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("allow_discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_discount_code"] = JsonSerializer.SerializeToElement(
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
                !this._rawData.TryGetValue("allow_phone_number_collection", out JsonElement element)
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

            this._rawData["allow_phone_number_collection"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("allow_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allow_tax_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("always_create_new_customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["always_create_new_customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static FeatureFlags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFlagsFromRaw : IFromRaw<FeatureFlags>
{
    public FeatureFlags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeatureFlags.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<SubscriptionData, SubscriptionDataFromRaw>))]
public sealed record class SubscriptionData : ModelBase
{
    public Subscriptions::OnDemandSubscription? OnDemand
    {
        get
        {
            if (!this._rawData.TryGetValue("on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Subscriptions::OnDemandSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["on_demand"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["trial_period_days"] = JsonSerializer.SerializeToElement(
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

    public static SubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionDataFromRaw : IFromRaw<SubscriptionData>
{
    public SubscriptionData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionData.FromRawUnchecked(rawData);
}
