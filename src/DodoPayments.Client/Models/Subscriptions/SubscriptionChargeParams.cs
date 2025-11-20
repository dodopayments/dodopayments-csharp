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

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionChargeParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
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
            if (!this._bodyProperties.TryGetValue("product_price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_price' cannot be null",
                    new ArgumentOutOfRangeException("product_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["product_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (
                !this._bodyProperties.TryGetValue(
                    "adaptive_currency_fees_inclusive",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["adaptive_currency_fees_inclusive"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Specify how customer balance is used for the payment
    /// </summary>
    public CustomerBalanceConfig? CustomerBalanceConfig
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "customer_balance_config",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<CustomerBalanceConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["customer_balance_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Metadata for the payment. If not passed, the metadata of the subscription
    /// will be taken
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._bodyProperties.TryGetValue("product_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["product_currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional product description override for billing and line items. If not specified,
    /// the stored description of the product will be used.
    /// </summary>
    public string? ProductDescription
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("product_description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["product_description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionChargeParams() { }

    public SubscriptionChargeParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChargeParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionChargeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
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

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Specify how customer balance is used for the payment
/// </summary>
[JsonConverter(typeof(ModelConverter<CustomerBalanceConfig>))]
public sealed record class CustomerBalanceConfig : ModelBase, IFromRaw<CustomerBalanceConfig>
{
    /// <summary>
    /// Allows Customer Credit to be purchased to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsPurchase
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "allow_customer_credits_purchase",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["allow_customer_credits_purchase"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Allows Customer Credit Balance to be used to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsUsage
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "allow_customer_credits_usage",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["allow_customer_credits_usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AllowCustomerCreditsPurchase;
        _ = this.AllowCustomerCreditsUsage;
    }

    public CustomerBalanceConfig() { }

    public CustomerBalanceConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerBalanceConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CustomerBalanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
