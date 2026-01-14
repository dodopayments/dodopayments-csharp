using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionChargeParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// The product price. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int ProductPrice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<int>("product_price");
        }
        init { this._rawBodyData.Set("product_price", value); }
    }

    /// <summary>
    /// Whether adaptive currency fees should be included in the product_price (true)
    /// or added on top (false). This field is ignored if adaptive pricing is not
    /// enabled for the business.
    /// </summary>
    public bool? AdaptiveCurrencyFeesInclusive
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("adaptive_currency_fees_inclusive");
        }
        init { this._rawBodyData.Set("adaptive_currency_fees_inclusive", value); }
    }

    /// <summary>
    /// Specify how customer balance is used for the payment
    /// </summary>
    public CustomerBalanceConfig? CustomerBalanceConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerBalanceConfig>(
                "customer_balance_config"
            );
        }
        init { this._rawBodyData.Set("customer_balance_config", value); }
    }

    /// <summary>
    /// Metadata for the payment. If not passed, the metadata of the subscription
    /// will be taken
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
    /// Optional currency of the product price. If not specified, defaults to the
    /// currency of the product.
    /// </summary>
    public ApiEnum<string, Currency>? ProductCurrency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Currency>>(
                "product_currency"
            );
        }
        init { this._rawBodyData.Set("product_currency", value); }
    }

    /// <summary>
    /// Optional product description override for billing and line items. If not specified,
    /// the stored description of the product will be used.
    /// </summary>
    public string? ProductDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("product_description");
        }
        init { this._rawBodyData.Set("product_description", value); }
    }

    public SubscriptionChargeParams() { }

    public SubscriptionChargeParams(SubscriptionChargeParams subscriptionChargeParams)
        : base(subscriptionChargeParams)
    {
        this.SubscriptionID = subscriptionChargeParams.SubscriptionID;

        this._rawBodyData = new(subscriptionChargeParams._rawBodyData);
    }

    public SubscriptionChargeParams(
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
    SubscriptionChargeParams(
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
    public static SubscriptionChargeParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/charge", this.SubscriptionID)
        )
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
}

/// <summary>
/// Specify how customer balance is used for the payment
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerBalanceConfig, CustomerBalanceConfigFromRaw>))]
public sealed record class CustomerBalanceConfig : JsonModel
{
    /// <summary>
    /// Allows Customer Credit to be purchased to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsPurchase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_credits_purchase");
        }
        init { this._rawData.Set("allow_customer_credits_purchase", value); }
    }

    /// <summary>
    /// Allows Customer Credit Balance to be used to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_credits_usage");
        }
        init { this._rawData.Set("allow_customer_credits_usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowCustomerCreditsPurchase;
        _ = this.AllowCustomerCreditsUsage;
    }

    public CustomerBalanceConfig() { }

    public CustomerBalanceConfig(CustomerBalanceConfig customerBalanceConfig)
        : base(customerBalanceConfig) { }

    public CustomerBalanceConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerBalanceConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerBalanceConfigFromRaw.FromRawUnchecked"/>
    public static CustomerBalanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerBalanceConfigFromRaw : IFromRawJson<CustomerBalanceConfig>
{
    /// <inheritdoc/>
    public CustomerBalanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerBalanceConfig.FromRawUnchecked(rawData);
}
