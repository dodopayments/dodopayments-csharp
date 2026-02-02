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
    /// Custom fields to collect from customer during checkout (max 5 fields)
    /// </summary>
    public IReadOnlyList<CheckoutSessionRequestCustomField>? CustomFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CheckoutSessionRequestCustomField>
            >("custom_fields");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckoutSessionRequestCustomField>?>(
                "custom_fields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
    /// Product collection ID for collection-based checkout flow
    /// </summary>
    public string? ProductCollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_collection_id");
        }
        init { this._rawData.Set("product_collection_id", value); }
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
        foreach (var item in this.CustomFields ?? [])
        {
            item.Validate();
        }
        this.Customer?.Validate();
        this.Customization?.Validate();
        _ = this.DiscountCode;
        this.FeatureFlags?.Validate();
        _ = this.Force3ds;
        _ = this.Metadata;
        _ = this.MinimalAddress;
        _ = this.PaymentMethodID;
        _ = this.ProductCollectionID;
        _ = this.ReturnUrl;
        _ = this.ShortLink;
        _ = this.ShowSavedPaymentMethods;
        this.SubscriptionData?.Validate();
    }

    public CheckoutSessionRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequest(CheckoutSessionRequest checkoutSessionRequest)
        : base(checkoutSessionRequest) { }
#pragma warning restore CS8618

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
    public CheckoutSessionRequest(IReadOnlyList<CheckoutSessionRequestProductCart> productCart)
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestProductCart(
        CheckoutSessionRequestProductCart checkoutSessionRequestProductCart
    )
        : base(checkoutSessionRequestProductCart) { }
#pragma warning restore CS8618

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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestBillingAddress(
        CheckoutSessionRequestBillingAddress checkoutSessionRequestBillingAddress
    )
        : base(checkoutSessionRequestBillingAddress) { }
#pragma warning restore CS8618

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
/// Definition of a custom field for checkout
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestCustomField,
        CheckoutSessionRequestCustomFieldFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestCustomField : JsonModel
{
    /// <summary>
    /// Type of field determining validation rules
    /// </summary>
    public required ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType> FieldType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType>
            >("field_type");
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

    public CheckoutSessionRequestCustomField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestCustomField(
        CheckoutSessionRequestCustomField checkoutSessionRequestCustomField
    )
        : base(checkoutSessionRequestCustomField) { }
#pragma warning restore CS8618

    public CheckoutSessionRequestCustomField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestCustomFieldFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestCustomField FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestCustomFieldFromRaw : IFromRawJson<CheckoutSessionRequestCustomField>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestCustomField FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestCustomField.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of field determining validation rules
/// </summary>
[JsonConverter(typeof(CheckoutSessionRequestCustomFieldFieldTypeConverter))]
public enum CheckoutSessionRequestCustomFieldFieldType
{
    Text,
    Number,
    Email,
    Url,
    Date,
    Dropdown,
    Boolean,
}

sealed class CheckoutSessionRequestCustomFieldFieldTypeConverter
    : JsonConverter<CheckoutSessionRequestCustomFieldFieldType>
{
    public override CheckoutSessionRequestCustomFieldFieldType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => CheckoutSessionRequestCustomFieldFieldType.Text,
            "number" => CheckoutSessionRequestCustomFieldFieldType.Number,
            "email" => CheckoutSessionRequestCustomFieldFieldType.Email,
            "url" => CheckoutSessionRequestCustomFieldFieldType.Url,
            "date" => CheckoutSessionRequestCustomFieldFieldType.Date,
            "dropdown" => CheckoutSessionRequestCustomFieldFieldType.Dropdown,
            "boolean" => CheckoutSessionRequestCustomFieldFieldType.Boolean,
            _ => (CheckoutSessionRequestCustomFieldFieldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckoutSessionRequestCustomFieldFieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckoutSessionRequestCustomFieldFieldType.Text => "text",
                CheckoutSessionRequestCustomFieldFieldType.Number => "number",
                CheckoutSessionRequestCustomFieldFieldType.Email => "email",
                CheckoutSessionRequestCustomFieldFieldType.Url => "url",
                CheckoutSessionRequestCustomFieldFieldType.Date => "date",
                CheckoutSessionRequestCustomFieldFieldType.Dropdown => "dropdown",
                CheckoutSessionRequestCustomFieldFieldType.Boolean => "boolean",
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
    /// Theme of the page (determines which mode - light/dark/system - to use)
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

    /// <summary>
    /// Optional custom theme configuration with colors for light and dark modes
    /// </summary>
    public CheckoutSessionRequestCustomizationThemeConfig? ThemeConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestCustomizationThemeConfig>(
                "theme_config"
            );
        }
        init { this._rawData.Set("theme_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ForceLanguage;
        _ = this.ShowOnDemandTag;
        _ = this.ShowOrderDetails;
        this.Theme?.Validate();
        this.ThemeConfig?.Validate();
    }

    public CheckoutSessionRequestCustomization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestCustomization(
        CheckoutSessionRequestCustomization checkoutSessionRequestCustomization
    )
        : base(checkoutSessionRequestCustomization) { }
#pragma warning restore CS8618

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
/// Theme of the page (determines which mode - light/dark/system - to use)
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

/// <summary>
/// Optional custom theme configuration with colors for light and dark modes
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestCustomizationThemeConfig,
        CheckoutSessionRequestCustomizationThemeConfigFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestCustomizationThemeConfig : JsonModel
{
    /// <summary>
    /// Dark mode color configuration
    /// </summary>
    public CheckoutSessionRequestCustomizationThemeConfigDark? Dark
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestCustomizationThemeConfigDark>(
                "dark"
            );
        }
        init { this._rawData.Set("dark", value); }
    }

    /// <summary>
    /// Font size for the checkout UI
    /// </summary>
    public ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>
            >("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// Font weight for the checkout UI
    /// </summary>
    public ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>? FontWeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>
            >("font_weight");
        }
        init { this._rawData.Set("font_weight", value); }
    }

    /// <summary>
    /// Light mode color configuration
    /// </summary>
    public CheckoutSessionRequestCustomizationThemeConfigLight? Light
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionRequestCustomizationThemeConfigLight>(
                "light"
            );
        }
        init { this._rawData.Set("light", value); }
    }

    /// <summary>
    /// Custom text for the pay button (e.g., "Complete Purchase", "Subscribe Now")
    /// </summary>
    public string? PayButtonText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pay_button_text");
        }
        init { this._rawData.Set("pay_button_text", value); }
    }

    /// <summary>
    /// Border radius for UI elements (e.g., "4px", "0.5rem", "8px")
    /// </summary>
    public string? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("radius");
        }
        init { this._rawData.Set("radius", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Dark?.Validate();
        this.FontSize?.Validate();
        this.FontWeight?.Validate();
        this.Light?.Validate();
        _ = this.PayButtonText;
        _ = this.Radius;
    }

    public CheckoutSessionRequestCustomizationThemeConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestCustomizationThemeConfig(
        CheckoutSessionRequestCustomizationThemeConfig checkoutSessionRequestCustomizationThemeConfig
    )
        : base(checkoutSessionRequestCustomizationThemeConfig) { }
#pragma warning restore CS8618

    public CheckoutSessionRequestCustomizationThemeConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomizationThemeConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestCustomizationThemeConfigFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestCustomizationThemeConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestCustomizationThemeConfigFromRaw
    : IFromRawJson<CheckoutSessionRequestCustomizationThemeConfig>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestCustomizationThemeConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestCustomizationThemeConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Dark mode color configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestCustomizationThemeConfigDark,
        CheckoutSessionRequestCustomizationThemeConfigDarkFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestCustomizationThemeConfigDark : JsonModel
{
    /// <summary>
    /// Background primary color
    ///
    /// <para>Examples: `"#ffffff"`, `"rgb(255, 255, 255)"`, `"white"`</para>
    /// </summary>
    public string? BgPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_primary");
        }
        init { this._rawData.Set("bg_primary", value); }
    }

    /// <summary>
    /// Background secondary color
    /// </summary>
    public string? BgSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_secondary");
        }
        init { this._rawData.Set("bg_secondary", value); }
    }

    /// <summary>
    /// Border primary color
    /// </summary>
    public string? BorderPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_primary");
        }
        init { this._rawData.Set("border_primary", value); }
    }

    /// <summary>
    /// Border secondary color
    /// </summary>
    public string? BorderSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_secondary");
        }
        init { this._rawData.Set("border_secondary", value); }
    }

    /// <summary>
    /// Primary button background color
    /// </summary>
    public string? ButtonPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary");
        }
        init { this._rawData.Set("button_primary", value); }
    }

    /// <summary>
    /// Primary button hover color
    /// </summary>
    public string? ButtonPrimaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary_hover");
        }
        init { this._rawData.Set("button_primary_hover", value); }
    }

    /// <summary>
    /// Secondary button background color
    /// </summary>
    public string? ButtonSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary");
        }
        init { this._rawData.Set("button_secondary", value); }
    }

    /// <summary>
    /// Secondary button hover color
    /// </summary>
    public string? ButtonSecondaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary_hover");
        }
        init { this._rawData.Set("button_secondary_hover", value); }
    }

    /// <summary>
    /// Primary button text color
    /// </summary>
    public string? ButtonTextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_primary");
        }
        init { this._rawData.Set("button_text_primary", value); }
    }

    /// <summary>
    /// Secondary button text color
    /// </summary>
    public string? ButtonTextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_secondary");
        }
        init { this._rawData.Set("button_text_secondary", value); }
    }

    /// <summary>
    /// Input focus border color
    /// </summary>
    public string? InputFocusBorder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_focus_border");
        }
        init { this._rawData.Set("input_focus_border", value); }
    }

    /// <summary>
    /// Text error color
    /// </summary>
    public string? TextError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_error");
        }
        init { this._rawData.Set("text_error", value); }
    }

    /// <summary>
    /// Text placeholder color
    /// </summary>
    public string? TextPlaceholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_placeholder");
        }
        init { this._rawData.Set("text_placeholder", value); }
    }

    /// <summary>
    /// Text primary color
    /// </summary>
    public string? TextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_primary");
        }
        init { this._rawData.Set("text_primary", value); }
    }

    /// <summary>
    /// Text secondary color
    /// </summary>
    public string? TextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_secondary");
        }
        init { this._rawData.Set("text_secondary", value); }
    }

    /// <summary>
    /// Text success color
    /// </summary>
    public string? TextSuccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_success");
        }
        init { this._rawData.Set("text_success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BgPrimary;
        _ = this.BgSecondary;
        _ = this.BorderPrimary;
        _ = this.BorderSecondary;
        _ = this.ButtonPrimary;
        _ = this.ButtonPrimaryHover;
        _ = this.ButtonSecondary;
        _ = this.ButtonSecondaryHover;
        _ = this.ButtonTextPrimary;
        _ = this.ButtonTextSecondary;
        _ = this.InputFocusBorder;
        _ = this.TextError;
        _ = this.TextPlaceholder;
        _ = this.TextPrimary;
        _ = this.TextSecondary;
        _ = this.TextSuccess;
    }

    public CheckoutSessionRequestCustomizationThemeConfigDark() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestCustomizationThemeConfigDark(
        CheckoutSessionRequestCustomizationThemeConfigDark checkoutSessionRequestCustomizationThemeConfigDark
    )
        : base(checkoutSessionRequestCustomizationThemeConfigDark) { }
#pragma warning restore CS8618

    public CheckoutSessionRequestCustomizationThemeConfigDark(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomizationThemeConfigDark(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestCustomizationThemeConfigDarkFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestCustomizationThemeConfigDark FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestCustomizationThemeConfigDarkFromRaw
    : IFromRawJson<CheckoutSessionRequestCustomizationThemeConfigDark>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestCustomizationThemeConfigDark FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestCustomizationThemeConfigDark.FromRawUnchecked(rawData);
}

/// <summary>
/// Font size for the checkout UI
/// </summary>
[JsonConverter(typeof(CheckoutSessionRequestCustomizationThemeConfigFontSizeConverter))]
public enum CheckoutSessionRequestCustomizationThemeConfigFontSize
{
    Xs,
    Sm,
    Md,
    Lg,
    Xl,
    V2xl,
}

sealed class CheckoutSessionRequestCustomizationThemeConfigFontSizeConverter
    : JsonConverter<CheckoutSessionRequestCustomizationThemeConfigFontSize>
{
    public override CheckoutSessionRequestCustomizationThemeConfigFontSize Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "xs" => CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            "sm" => CheckoutSessionRequestCustomizationThemeConfigFontSize.Sm,
            "md" => CheckoutSessionRequestCustomizationThemeConfigFontSize.Md,
            "lg" => CheckoutSessionRequestCustomizationThemeConfigFontSize.Lg,
            "xl" => CheckoutSessionRequestCustomizationThemeConfigFontSize.Xl,
            "2xl" => CheckoutSessionRequestCustomizationThemeConfigFontSize.V2xl,
            _ => (CheckoutSessionRequestCustomizationThemeConfigFontSize)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckoutSessionRequestCustomizationThemeConfigFontSize value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs => "xs",
                CheckoutSessionRequestCustomizationThemeConfigFontSize.Sm => "sm",
                CheckoutSessionRequestCustomizationThemeConfigFontSize.Md => "md",
                CheckoutSessionRequestCustomizationThemeConfigFontSize.Lg => "lg",
                CheckoutSessionRequestCustomizationThemeConfigFontSize.Xl => "xl",
                CheckoutSessionRequestCustomizationThemeConfigFontSize.V2xl => "2xl",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Font weight for the checkout UI
/// </summary>
[JsonConverter(typeof(CheckoutSessionRequestCustomizationThemeConfigFontWeightConverter))]
public enum CheckoutSessionRequestCustomizationThemeConfigFontWeight
{
    Normal,
    Medium,
    Bold,
    ExtraBold,
}

sealed class CheckoutSessionRequestCustomizationThemeConfigFontWeightConverter
    : JsonConverter<CheckoutSessionRequestCustomizationThemeConfigFontWeight>
{
    public override CheckoutSessionRequestCustomizationThemeConfigFontWeight Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
            "medium" => CheckoutSessionRequestCustomizationThemeConfigFontWeight.Medium,
            "bold" => CheckoutSessionRequestCustomizationThemeConfigFontWeight.Bold,
            "extraBold" => CheckoutSessionRequestCustomizationThemeConfigFontWeight.ExtraBold,
            _ => (CheckoutSessionRequestCustomizationThemeConfigFontWeight)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckoutSessionRequestCustomizationThemeConfigFontWeight value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal => "normal",
                CheckoutSessionRequestCustomizationThemeConfigFontWeight.Medium => "medium",
                CheckoutSessionRequestCustomizationThemeConfigFontWeight.Bold => "bold",
                CheckoutSessionRequestCustomizationThemeConfigFontWeight.ExtraBold => "extraBold",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Light mode color configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionRequestCustomizationThemeConfigLight,
        CheckoutSessionRequestCustomizationThemeConfigLightFromRaw
    >)
)]
public sealed record class CheckoutSessionRequestCustomizationThemeConfigLight : JsonModel
{
    /// <summary>
    /// Background primary color
    ///
    /// <para>Examples: `"#ffffff"`, `"rgb(255, 255, 255)"`, `"white"`</para>
    /// </summary>
    public string? BgPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_primary");
        }
        init { this._rawData.Set("bg_primary", value); }
    }

    /// <summary>
    /// Background secondary color
    /// </summary>
    public string? BgSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_secondary");
        }
        init { this._rawData.Set("bg_secondary", value); }
    }

    /// <summary>
    /// Border primary color
    /// </summary>
    public string? BorderPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_primary");
        }
        init { this._rawData.Set("border_primary", value); }
    }

    /// <summary>
    /// Border secondary color
    /// </summary>
    public string? BorderSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_secondary");
        }
        init { this._rawData.Set("border_secondary", value); }
    }

    /// <summary>
    /// Primary button background color
    /// </summary>
    public string? ButtonPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary");
        }
        init { this._rawData.Set("button_primary", value); }
    }

    /// <summary>
    /// Primary button hover color
    /// </summary>
    public string? ButtonPrimaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary_hover");
        }
        init { this._rawData.Set("button_primary_hover", value); }
    }

    /// <summary>
    /// Secondary button background color
    /// </summary>
    public string? ButtonSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary");
        }
        init { this._rawData.Set("button_secondary", value); }
    }

    /// <summary>
    /// Secondary button hover color
    /// </summary>
    public string? ButtonSecondaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary_hover");
        }
        init { this._rawData.Set("button_secondary_hover", value); }
    }

    /// <summary>
    /// Primary button text color
    /// </summary>
    public string? ButtonTextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_primary");
        }
        init { this._rawData.Set("button_text_primary", value); }
    }

    /// <summary>
    /// Secondary button text color
    /// </summary>
    public string? ButtonTextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_secondary");
        }
        init { this._rawData.Set("button_text_secondary", value); }
    }

    /// <summary>
    /// Input focus border color
    /// </summary>
    public string? InputFocusBorder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_focus_border");
        }
        init { this._rawData.Set("input_focus_border", value); }
    }

    /// <summary>
    /// Text error color
    /// </summary>
    public string? TextError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_error");
        }
        init { this._rawData.Set("text_error", value); }
    }

    /// <summary>
    /// Text placeholder color
    /// </summary>
    public string? TextPlaceholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_placeholder");
        }
        init { this._rawData.Set("text_placeholder", value); }
    }

    /// <summary>
    /// Text primary color
    /// </summary>
    public string? TextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_primary");
        }
        init { this._rawData.Set("text_primary", value); }
    }

    /// <summary>
    /// Text secondary color
    /// </summary>
    public string? TextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_secondary");
        }
        init { this._rawData.Set("text_secondary", value); }
    }

    /// <summary>
    /// Text success color
    /// </summary>
    public string? TextSuccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_success");
        }
        init { this._rawData.Set("text_success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BgPrimary;
        _ = this.BgSecondary;
        _ = this.BorderPrimary;
        _ = this.BorderSecondary;
        _ = this.ButtonPrimary;
        _ = this.ButtonPrimaryHover;
        _ = this.ButtonSecondary;
        _ = this.ButtonSecondaryHover;
        _ = this.ButtonTextPrimary;
        _ = this.ButtonTextSecondary;
        _ = this.InputFocusBorder;
        _ = this.TextError;
        _ = this.TextPlaceholder;
        _ = this.TextPrimary;
        _ = this.TextSecondary;
        _ = this.TextSuccess;
    }

    public CheckoutSessionRequestCustomizationThemeConfigLight() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestCustomizationThemeConfigLight(
        CheckoutSessionRequestCustomizationThemeConfigLight checkoutSessionRequestCustomizationThemeConfigLight
    )
        : base(checkoutSessionRequestCustomizationThemeConfigLight) { }
#pragma warning restore CS8618

    public CheckoutSessionRequestCustomizationThemeConfigLight(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionRequestCustomizationThemeConfigLight(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionRequestCustomizationThemeConfigLightFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionRequestCustomizationThemeConfigLight FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionRequestCustomizationThemeConfigLightFromRaw
    : IFromRawJson<CheckoutSessionRequestCustomizationThemeConfigLight>
{
    /// <inheritdoc/>
    public CheckoutSessionRequestCustomizationThemeConfigLight FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionRequestCustomizationThemeConfigLight.FromRawUnchecked(rawData);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestFeatureFlags(
        CheckoutSessionRequestFeatureFlags checkoutSessionRequestFeatureFlags
    )
        : base(checkoutSessionRequestFeatureFlags) { }
#pragma warning restore CS8618

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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionRequestSubscriptionData(
        CheckoutSessionRequestSubscriptionData checkoutSessionRequestSubscriptionData
    )
        : base(checkoutSessionRequestSubscriptionData) { }
#pragma warning restore CS8618

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
