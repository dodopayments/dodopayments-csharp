using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

public sealed record class PaymentCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Billing address details for the payment
    /// </summary>
    public required BillingAddress Billing
    {
        get { return ModelBase.GetNotNullClass<BillingAddress>(this.RawBodyData, "billing"); }
        init { ModelBase.Set(this._rawBodyData, "billing", value); }
    }

    /// <summary>
    /// Customer information for the payment
    /// </summary>
    public required CustomerRequest Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerRequest>(this.RawBodyData, "customer"); }
        init { ModelBase.Set(this._rawBodyData, "customer", value); }
    }

    /// <summary>
    /// List of products in the cart. Must contain at least 1 and at most 100 items.
    /// </summary>
    public required IReadOnlyList<OneTimeProductCartItem> ProductCart
    {
        get
        {
            return ModelBase.GetNotNullClass<List<OneTimeProductCartItem>>(
                this.RawBodyData,
                "product_cart"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "product_cart", value); }
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
            return ModelBase.GetNullableClass<List<ApiEnum<string, PaymentMethodTypes>>>(
                this.RawBodyData,
                "allowed_payment_method_types"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "allowed_payment_method_types", value); }
    }

    /// <summary>
    /// Fix the currency in which the end customer is billed. If Dodo Payments cannot
    /// support that currency for this transaction, it will not proceed
    /// </summary>
    public ApiEnum<string, Currency>? BillingCurrency
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Currency>>(
                this.RawBodyData,
                "billing_currency"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "billing_currency", value); }
    }

    /// <summary>
    /// Discount Code to apply to the transaction
    /// </summary>
    public string? DiscountCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "discount_code"); }
        init { ModelBase.Set(this._rawBodyData, "discount_code", value); }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this payment
    /// </summary>
    public bool? Force3DS
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "force_3ds"); }
        init { ModelBase.Set(this._rawBodyData, "force_3ds", value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment. Defaults to empty if not provided.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "metadata", value);
        }
    }

    /// <summary>
    /// Whether to generate a payment link. Defaults to false if not specified.
    /// </summary>
    public bool? PaymentLink
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "payment_link"); }
        init { ModelBase.Set(this._rawBodyData, "payment_link", value); }
    }

    /// <summary>
    /// Optional URL to redirect the customer after payment. Must be a valid URL if provided.
    /// </summary>
    public string? ReturnURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "return_url"); }
        init { ModelBase.Set(this._rawBodyData, "return_url", value); }
    }

    /// <summary>
    /// Display saved payment methods of a returning customer False by default
    /// </summary>
    public bool? ShowSavedPaymentMethods
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(
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

            ModelBase.Set(this._rawBodyData, "show_saved_payment_methods", value);
        }
    }

    /// <summary>
    /// Tax ID in case the payment is B2B. If tax id validation fails the payment
    /// creation will fail
    /// </summary>
    public string? TaxID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "tax_id"); }
        init { ModelBase.Set(this._rawBodyData, "tax_id", value); }
    }

    public PaymentCreateParams() { }

    public PaymentCreateParams(PaymentCreateParams paymentCreateParams)
        : base(paymentCreateParams)
    {
        this._rawBodyData = [.. paymentCreateParams._rawBodyData];
    }

    public PaymentCreateParams(
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
    PaymentCreateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
