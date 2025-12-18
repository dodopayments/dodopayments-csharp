using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

[Obsolete("deprecated")]
public sealed record class SubscriptionCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Billing address information for the subscription
    /// </summary>
    public required BillingAddress Billing
    {
        get { return JsonModel.GetNotNullClass<BillingAddress>(this.RawBodyData, "billing"); }
        init { JsonModel.Set(this._rawBodyData, "billing", value); }
    }

    /// <summary>
    /// Customer details for the subscription
    /// </summary>
    public required CustomerRequest Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerRequest>(this.RawBodyData, "customer"); }
        init { JsonModel.Set(this._rawBodyData, "customer", value); }
    }

    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "product_id"); }
        init { JsonModel.Set(this._rawBodyData, "product_id", value); }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawBodyData, "quantity"); }
        init { JsonModel.Set(this._rawBodyData, "quantity", value); }
    }

    /// <summary>
    /// Attach addons to this subscription
    /// </summary>
    public IReadOnlyList<AttachAddon>? Addons
    {
        get { return JsonModel.GetNullableClass<List<AttachAddon>>(this.RawBodyData, "addons"); }
        init { JsonModel.Set(this._rawBodyData, "addons", value); }
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
            return JsonModel.GetNullableClass<List<ApiEnum<string, PaymentMethodTypes>>>(
                this.RawBodyData,
                "allowed_payment_method_types"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "allowed_payment_method_types", value); }
    }

    /// <summary>
    /// Fix the currency in which the end customer is billed. If Dodo Payments cannot
    /// support that currency for this transaction, it will not proceed
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
    /// Discount Code to apply to the subscription
    /// </summary>
    public string? DiscountCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "discount_code"); }
        init { JsonModel.Set(this._rawBodyData, "discount_code", value); }
    }

    /// <summary>
    /// Override merchant default 3DS behaviour for this subscription
    /// </summary>
    public bool? Force3DS
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "force_3ds"); }
        init { JsonModel.Set(this._rawBodyData, "force_3ds", value); }
    }

    /// <summary>
    /// Additional metadata for the subscription Defaults to empty if not specified
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
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "metadata", value);
        }
    }

    public OnDemandSubscription? OnDemand
    {
        get
        {
            return JsonModel.GetNullableClass<OnDemandSubscription>(this.RawBodyData, "on_demand");
        }
        init { JsonModel.Set(this._rawBodyData, "on_demand", value); }
    }

    /// <summary>
    /// List of one time products that will be bundled with the first payment for
    /// this subscription
    /// </summary>
    public IReadOnlyList<OneTimeProductCartItem>? OneTimeProductCart
    {
        get
        {
            return JsonModel.GetNullableClass<List<OneTimeProductCartItem>>(
                this.RawBodyData,
                "one_time_product_cart"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "one_time_product_cart", value); }
    }

    /// <summary>
    /// If true, generates a payment link. Defaults to false if not specified.
    /// </summary>
    public bool? PaymentLink
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "payment_link"); }
        init { JsonModel.Set(this._rawBodyData, "payment_link", value); }
    }

    /// <summary>
    /// Optional URL to redirect after successful subscription creation
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

    /// <summary>
    /// Tax ID in case the payment is B2B. If tax id validation fails the payment
    /// creation will fail
    /// </summary>
    public string? TaxID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "tax_id"); }
        init { JsonModel.Set(this._rawBodyData, "tax_id", value); }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawBodyData, "trial_period_days"); }
        init { JsonModel.Set(this._rawBodyData, "trial_period_days", value); }
    }

    public SubscriptionCreateParams() { }

    public SubscriptionCreateParams(SubscriptionCreateParams subscriptionCreateParams)
        : base(subscriptionCreateParams)
    {
        this._rawBodyData = [.. subscriptionCreateParams._rawBodyData];
    }

    public SubscriptionCreateParams(
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
    SubscriptionCreateParams(
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
    public static SubscriptionCreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
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
