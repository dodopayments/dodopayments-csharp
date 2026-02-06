using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<CheckoutSessionRequest, CheckoutSessionRequestFromRaw>))]
public sealed record class CheckoutSessionRequest : JsonModel
{
    public required IReadOnlyList<ProductItemReq> ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductItemReq>>("product_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductItemReq>>(
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
    public CheckoutSessionBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionBillingAddress>("billing_address");
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
    public IReadOnlyList<CustomField>? CustomFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomField>>("custom_fields");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomField>?>(
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
    public CheckoutSessionCustomization? Customization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionCustomization>("customization");
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

    public CheckoutSessionFlags? FeatureFlags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutSessionFlags>("feature_flags");
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

    public SubscriptionData? SubscriptionData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionData>("subscription_data");
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
    public CheckoutSessionRequest(IReadOnlyList<ProductItemReq> productCart)
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
