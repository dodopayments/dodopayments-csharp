using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AddonCartResponseItem>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonCartResponseItem>>(
                "addons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Customer details associated with this subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Additional metadata associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// First payment id for the subscription
    /// </summary>
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Tax will be added to the amount and charged to the customer on each billing cycle
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("recurring_pre_tax_amount");
        }
        init { this._rawData.Set("recurring_pre_tax_amount", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// Expiry timestamp of the payment link
    /// </summary>
    public DateTimeOffset? ExpiresOn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_on");
        }
        init { this._rawData.Set("expires_on", value); }
    }

    /// <summary>
    /// One time products associated with the purchase of subscription
    /// </summary>
    public IReadOnlyList<OneTimeProductCart>? OneTimeProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OneTimeProductCart>>(
                "one_time_product_cart"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<OneTimeProductCart>?>(
                "one_time_product_cart",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL to checkout page
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_link");
        }
        init { this._rawData.Set("payment_link", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimeProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
