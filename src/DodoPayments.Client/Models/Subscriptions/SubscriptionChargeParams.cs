using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions.SubscriptionChargeParamsProperties;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionChargeParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// The product price. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int ProductPrice
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_price' cannot be null",
                    new ArgumentOutOfRangeException("product_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["product_price"] = JsonSerializer.SerializeToElement(
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
                !this.BodyProperties.TryGetValue(
                    "adaptive_currency_fees_inclusive",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["adaptive_currency_fees_inclusive"] =
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
                !this.BodyProperties.TryGetValue("customer_balance_config", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<CustomerBalanceConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["customer_balance_config"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("product_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["product_currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional product description override for billing and line items. If not
    /// specified, the stored description of the product will be used.
    /// </summary>
    public string? ProductDescription
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["product_description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/charge", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
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

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
