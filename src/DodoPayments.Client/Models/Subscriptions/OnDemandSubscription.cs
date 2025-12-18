using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(JsonModelConverter<OnDemandSubscription, OnDemandSubscriptionFromRaw>))]
public sealed record class OnDemandSubscription : JsonModel
{
    /// <summary>
    /// If set as True, does not perform any charge and only authorizes payment method
    /// details for future use.
    /// </summary>
    public required bool MandateOnly
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "mandate_only"); }
        init { JsonModel.Set(this._rawData, "mandate_only", value); }
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
            return JsonModel.GetNullableStruct<bool>(
                this.RawData,
                "adaptive_currency_fees_inclusive"
            );
        }
        init { JsonModel.Set(this._rawData, "adaptive_currency_fees_inclusive", value); }
    }

    /// <summary>
    /// Optional currency of the product price. If not specified, defaults to the
    /// currency of the product.
    /// </summary>
    public ApiEnum<string, Currency>? ProductCurrency
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Currency>>(
                this.RawData,
                "product_currency"
            );
        }
        init { JsonModel.Set(this._rawData, "product_currency", value); }
    }

    /// <summary>
    /// Optional product description override for billing and line items. If not specified,
    /// the stored description of the product will be used.
    /// </summary>
    public string? ProductDescription
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "product_description"); }
        init { JsonModel.Set(this._rawData, "product_description", value); }
    }

    /// <summary>
    /// Product price for the initial charge to customer If not specified the stored
    /// price of the product will be used Represented in the lowest denomination of
    /// the currency (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public int? ProductPrice
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "product_price"); }
        init { JsonModel.Set(this._rawData, "product_price", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MandateOnly;
        _ = this.AdaptiveCurrencyFeesInclusive;
        this.ProductCurrency?.Validate();
        _ = this.ProductDescription;
        _ = this.ProductPrice;
    }

    public OnDemandSubscription() { }

    public OnDemandSubscription(OnDemandSubscription onDemandSubscription)
        : base(onDemandSubscription) { }

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

    /// <inheritdoc cref="OnDemandSubscriptionFromRaw.FromRawUnchecked"/>
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

class OnDemandSubscriptionFromRaw : IFromRawJson<OnDemandSubscription>
{
    /// <inheritdoc/>
    public OnDemandSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OnDemandSubscription.FromRawUnchecked(rawData);
}
