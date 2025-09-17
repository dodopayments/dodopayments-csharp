using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Models.Misc;
using Client = DodoPayments.Client;
using SubscriptionChargeParamsProperties = DodoPayments.Client.Models.Subscriptions.SubscriptionChargeParamsProperties;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionChargeParams : Client::ParamsBase
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
                throw new ArgumentOutOfRangeException("product_price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["product_price"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["adaptive_currency_fees_inclusive"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Specify how customer balance is used for the payment
    /// </summary>
    public SubscriptionChargeParamsProperties::CustomerBalanceConfig? CustomerBalanceConfig
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("customer_balance_config", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<SubscriptionChargeParamsProperties::CustomerBalanceConfig?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["customer_balance_config"] = JsonSerializer.SerializeToElement(
                value
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
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional currency of the product price. If not specified, defaults to the
    /// currency of the product.
    /// </summary>
    public Currency? ProductCurrency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("product_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Currency?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["product_currency"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["product_description"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/charge", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
