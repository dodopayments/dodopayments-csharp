using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<OnDemandSubscription, OnDemandSubscriptionFromRaw>))]
public sealed record class OnDemandSubscription : ModelBase
{
    /// <summary>
    /// If set as True, does not perform any charge and only authorizes payment method
    /// details for future use.
    /// </summary>
    public required bool MandateOnly
    {
        get
        {
            if (!this._rawData.TryGetValue("mandate_only", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'mandate_only' cannot be null",
                    new ArgumentOutOfRangeException("mandate_only", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["mandate_only"] = JsonSerializer.SerializeToElement(
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
                !this._rawData.TryGetValue(
                    "adaptive_currency_fees_inclusive",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["adaptive_currency_fees_inclusive"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("product_currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["product_currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("product_description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["product_description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Product price for the initial charge to customer If not specified the stored
    /// price of the product will be used Represented in the lowest denomination of
    /// the currency (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public int? ProductPrice
    {
        get
        {
            if (!this._rawData.TryGetValue("product_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["product_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MandateOnly;
        _ = this.AdaptiveCurrencyFeesInclusive;
        this.ProductCurrency?.Validate();
        _ = this.ProductDescription;
        _ = this.ProductPrice;
    }

    public OnDemandSubscription() { }

    public OnDemandSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnDemandSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static OnDemandSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OnDemandSubscription(bool mandateOnly)
        : this()
    {
        this.MandateOnly = mandateOnly;
    }
}

class OnDemandSubscriptionFromRaw : IFromRaw<OnDemandSubscription>
{
    public OnDemandSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OnDemandSubscription.FromRawUnchecked(rawData);
}
