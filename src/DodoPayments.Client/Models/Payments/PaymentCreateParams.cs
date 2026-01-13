using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[Obsolete("deprecated")]
public sealed record class PaymentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Billing address details for the payment
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BillingAddress>("billing");
        }
        init { this._rawBodyData.Set("billing", value); }
    }

    /// <summary>
    /// Customer information for the payment
    /// </summary>
    public required CustomerRequest Customer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<CustomerRequest>("customer");
        }
        init { this._rawBodyData.Set("customer", value); }
    }

    /// <summary>
    /// List of products in the cart. Must contain at least 1 and at most 100 items.
    /// </summary>
    public required IReadOnlyList<OneTimeProductCartItem> ProductCart
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<OneTimeProductCartItem>>(
                "product_cart"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<OneTimeProductCartItem>>(
                "product_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of payment methods allowed during checkout.
    ///
    /// <para>Customers will **never** see payment methods that are **not** in this
    /// list. However, adding a method here **does not guarantee** customers will
    /// see it. Availability still depends on other factors (e.g., customer location,
    /// merchant settings).</para>
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaymentMethodTypes>>? AllowedPaymentMethodTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentMethodTypes>>
            >("allowed_payment_method_types");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, PaymentMethodTypes>>?>(
                "allowed_payment_method_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Fix the currency in which the end customer is billed. If Dodo Payments cannot
    /// support that currency for this transaction, it will not proceed
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
    /// Discount Code to apply to the transaction
    /// </summary>
    public string? DiscountCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("discount_code");
        }
        init { this._rawBodyData.Set("discount_code", value); }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this payment
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
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to generate a payment link. Defaults to false if not specified.
    /// </summary>
    public bool? PaymentLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("payment_link");
        }
        init { this._rawBodyData.Set("payment_link", value); }
    }

    /// <summary>
    /// Optional payment method ID to use for this payment. If provided, customer_id
    /// must also be provided. The payment method will be validated for eligibility
    /// with the payment's currency.
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
    /// If true, redirects the customer immediately after payment completion False
    /// by default
    /// </summary>
    public bool? RedirectImmediately
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("redirect_immediately");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("redirect_immediately", value);
        }
    }

    /// <summary>
    /// Optional URL to redirect the customer after payment. Must be a valid URL if provided.
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
    /// If true, returns a shortened payment link. Defaults to false if not specified.
    /// </summary>
    public bool? ShortLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("short_link");
        }
        init { this._rawBodyData.Set("short_link", value); }
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

    /// <summary>
    /// Tax ID in case the payment is B2B. If tax id validation fails the payment
    /// creation will fail
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tax_id");
        }
        init { this._rawBodyData.Set("tax_id", value); }
    }

    public PaymentCreateParams() { }

    public PaymentCreateParams(PaymentCreateParams paymentCreateParams)
        : base(paymentCreateParams)
    {
        this._rawBodyData = new(paymentCreateParams._rawBodyData);
    }

    public PaymentCreateParams(
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
    PaymentCreateParams(
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
    public static PaymentCreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/payments")
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
