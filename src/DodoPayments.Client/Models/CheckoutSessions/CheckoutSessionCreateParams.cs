using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class CheckoutSessionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyList<ProductCart> ProductCart
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ProductCart>>("product_cart");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ProductCart>>(
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
    public IReadOnlyList<ApiEnum<string, Payments::PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, Payments::PaymentMethodTypes>>
            >("allowed_payment_method_types");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, Payments::PaymentMethodTypes>>?>(
                "allowed_payment_method_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingAddress>("billing_address");
        }
        init { this._rawBodyData.Set("billing_address", value); }
    }

    /// <summary>
    /// This field is ingored if adaptive pricing is disabled
    /// </summary>
    public ApiEnum<string, Currency>? BillingCurrency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Currency>>(
                "billing_currency"
            );
        }
        init { this._rawBodyData.Set("billing_currency", value); }
    }

    /// <summary>
    /// If confirm is true, all the details will be finalized. If required data is
    /// missing, an API error is thrown.
    /// </summary>
    public bool? Confirm
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("confirm");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("confirm", value);
        }
    }

    /// <summary>
    /// Custom fields to collect from customer during checkout (max 5 fields)
    /// </summary>
    public IReadOnlyList<CustomField>? CustomFields
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<CustomField>>(
                "custom_fields"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<CustomField>?>(
                "custom_fields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Payments::CustomerRequest>("customer");
        }
        init { this._rawBodyData.Set("customer", value); }
    }

    /// <summary>
    /// Customization for the checkout session page
    /// </summary>
    public Customization? Customization
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Customization>("customization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("customization", value);
        }
    }

    public string? DiscountCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("discount_code");
        }
        init { this._rawBodyData.Set("discount_code", value); }
    }

    public FeatureFlags? FeatureFlags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FeatureFlags>("feature_flags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("feature_flags", value);
        }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this session
    /// </summary>
    public bool? Force3ds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("force_3ds");
        }
        init { this._rawBodyData.Set("force_3ds", value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("minimal_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minimal_address", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_method_id");
        }
        init { this._rawBodyData.Set("payment_method_id", value); }
    }

    /// <summary>
    /// Product collection ID for collection-based checkout flow
    /// </summary>
    public string? ProductCollectionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("product_collection_id");
        }
        init { this._rawBodyData.Set("product_collection_id", value); }
    }

    /// <summary>
    /// The url to redirect after payment failure or success.
    /// </summary>
    public string? ReturnUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("return_url");
        }
        init { this._rawBodyData.Set("return_url", value); }
    }

    /// <summary>
    /// If true, returns a shortened checkout URL. Defaults to false if not specified.
    /// </summary>
    public bool? ShortLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("short_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("short_link", value);
        }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("show_saved_payment_methods");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("show_saved_payment_methods", value);
        }
    }

    public SubscriptionData? SubscriptionData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionData>("subscription_data");
        }
        init { this._rawBodyData.Set("subscription_data", value); }
    }

    public CheckoutSessionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionCreateParams(CheckoutSessionCreateParams checkoutSessionCreateParams)
        : base(checkoutSessionCreateParams)
    {
        this._rawBodyData = new(checkoutSessionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CheckoutSessionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CheckoutSessionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
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

    public ProductCart() { }

    public ProductCart(ProductCart productCart)
        : base(productCart) { }

    public ProductCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

    public BillingAddress() { }

    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
/// Definition of a custom field for checkout
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomField, CustomFieldFromRaw>))]
public sealed record class CustomField : JsonModel
{
    /// <summary>
    /// Type of field determining validation rules
    /// </summary>
    public required ApiEnum<string, FieldType> FieldType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FieldType>>("field_type");
        }
        init { this._rawData.Set("field_type", value); }
    }

    /// <summary>
    /// Unique identifier for this field (used as key in responses)
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Display label shown to customer
    /// </summary>
    public required string Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Options for dropdown type (required for dropdown, ignored for others)
    /// </summary>
    public IReadOnlyList<string>? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Placeholder text for the input
    /// </summary>
    public string? Placeholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("placeholder");
        }
        init { this._rawData.Set("placeholder", value); }
    }

    /// <summary>
    /// Whether this field is required
    /// </summary>
    public bool? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("required", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType.Validate();
        _ = this.Key;
        _ = this.Label;
        _ = this.Options;
        _ = this.Placeholder;
        _ = this.Required;
    }

    public CustomField() { }

    public CustomField(CustomField customField)
        : base(customField) { }

    public CustomField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomFieldFromRaw.FromRawUnchecked"/>
    public static CustomField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomFieldFromRaw : IFromRawJson<CustomField>
{
    /// <inheritdoc/>
    public CustomField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomField.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of field determining validation rules
/// </summary>
[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Text,
    Number,
    Email,
    Url,
    Phone,
    Date,
    Datetime,
    Dropdown,
    Boolean,
}

sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FieldType.Text,
            "number" => FieldType.Number,
            "email" => FieldType.Email,
            "url" => FieldType.Url,
            "phone" => FieldType.Phone,
            "date" => FieldType.Date,
            "datetime" => FieldType.Datetime,
            "dropdown" => FieldType.Dropdown,
            "boolean" => FieldType.Boolean,
            _ => (FieldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FieldType.Text => "text",
                FieldType.Number => "number",
                FieldType.Email => "email",
                FieldType.Url => "url",
                FieldType.Phone => "phone",
                FieldType.Date => "date",
                FieldType.Datetime => "datetime",
                FieldType.Dropdown => "dropdown",
                FieldType.Boolean => "boolean",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
    public ApiEnum<string, Theme>? Theme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Theme>>("theme");
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

    public Customization() { }

    public Customization(Customization customization)
        : base(customization) { }

    public Customization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

    public FeatureFlags() { }

    public FeatureFlags(FeatureFlags featureFlags)
        : base(featureFlags) { }

    public FeatureFlags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureFlags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

    public SubscriptionData() { }

    public SubscriptionData(SubscriptionData subscriptionData)
        : base(subscriptionData) { }

    public SubscriptionData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
