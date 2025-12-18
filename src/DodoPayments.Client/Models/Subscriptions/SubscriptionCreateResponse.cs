using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionCreateResponse, SubscriptionCreateResponseFromRaw>)
)]
public sealed record class SubscriptionCreateResponse : JsonModel
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required IReadOnlyList<AddonCartResponseItem> Addons
    {
        get
        {
            return JsonModel.GetNotNullClass<List<AddonCartResponseItem>>(this.RawData, "addons");
        }
        init { JsonModel.Set(this._rawData, "addons", value); }
    }

    /// <summary>
    /// Customer details associated with this subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Additional metadata associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// First payment id for the subscription
    /// </summary>
    public required string PaymentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// Tax will be added to the amount and charged to the customer on each billing cycle
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "recurring_pre_tax_amount"); }
        init { JsonModel.Set(this._rawData, "recurring_pre_tax_amount", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "subscription_id"); }
        init { JsonModel.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public string? ClientSecret
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "client_secret"); }
        init { JsonModel.Set(this._rawData, "client_secret", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { JsonModel.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// Expiry timestamp of the payment link
    /// </summary>
    public DateTimeOffset? ExpiresOn
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "expires_on"); }
        init { JsonModel.Set(this._rawData, "expires_on", value); }
    }

    /// <summary>
    /// One time products associated with the purchase of subscription
    /// </summary>
    public IReadOnlyList<OneTimeProductCart>? OneTimeProductCart
    {
        get
        {
            return JsonModel.GetNullableClass<List<OneTimeProductCart>>(
                this.RawData,
                "one_time_product_cart"
            );
        }
        init { JsonModel.Set(this._rawData, "one_time_product_cart", value); }
    }

    /// <summary>
    /// URL to checkout page
    /// </summary>
    public string? PaymentLink
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_link"); }
        init { JsonModel.Set(this._rawData, "payment_link", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Addons)
        {
            item.Validate();
        }
        this.Customer.Validate();
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.RecurringPreTaxAmount;
        _ = this.SubscriptionID;
        _ = this.ClientSecret;
        _ = this.DiscountID;
        _ = this.ExpiresOn;
        foreach (var item in this.OneTimeProductCart ?? [])
        {
            item.Validate();
        }
        _ = this.PaymentLink;
    }

    public SubscriptionCreateResponse() { }

    public SubscriptionCreateResponse(SubscriptionCreateResponse subscriptionCreateResponse)
        : base(subscriptionCreateResponse) { }

    public SubscriptionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionCreateResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionCreateResponseFromRaw : IFromRawJson<SubscriptionCreateResponse>
{
    /// <inheritdoc/>
    public SubscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OneTimeProductCart, OneTimeProductCartFromRaw>))]
public sealed record class OneTimeProductCart : JsonModel
{
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
    }

    public OneTimeProductCart() { }

    public OneTimeProductCart(OneTimeProductCart oneTimeProductCart)
        : base(oneTimeProductCart) { }

    public OneTimeProductCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimeProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OneTimeProductCartFromRaw.FromRawUnchecked"/>
    public static OneTimeProductCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OneTimeProductCartFromRaw : IFromRawJson<OneTimeProductCart>
{
    /// <inheritdoc/>
    public OneTimeProductCart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OneTimeProductCart.FromRawUnchecked(rawData);
}
