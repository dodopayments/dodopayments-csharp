using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentCreateResponse, PaymentCreateResponseFromRaw>))]
public sealed record class PaymentCreateResponse : JsonModel
{
    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <summary>
    /// Limited details about the customer making the payment
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
    /// Additional metadata associated with the payment
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
    /// Unique identifier for the payment
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
    /// Total amount of the payment in the currency's smallest unit (cents for USD,
    /// yen for JPY, fils for KWD)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <summary>
    /// DEPRECATED: Use discount_ids instead. Returns the first discount's ID if present.
    /// </summary>
    [Obsolete("Use `discounts` instead.")]
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
    /// All stacked discount IDs applied, in order of application
    /// </summary>
    public IReadOnlyList<string>? DiscountIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("discount_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "discount_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Optional URL to a hosted payment page
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

    /// <summary>
    /// Optional list of products included in the payment
    /// </summary>
    public IReadOnlyList<OneTimeProductCartItem>? ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OneTimeProductCartItem>>(
                "product_cart"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<OneTimeProductCartItem>?>(
                "product_cart",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientSecret;
        this.Customer.Validate();
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.TotalAmount;
        _ = this.DiscountID;
        _ = this.DiscountIds;
        _ = this.ExpiresOn;
        _ = this.PaymentLink;
        foreach (var item in this.ProductCart ?? [])
        {
            item.Validate();
        }
    }

    public PaymentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentCreateResponse(PaymentCreateResponse paymentCreateResponse)
        : base(paymentCreateResponse) { }
#pragma warning restore CS8618

    public PaymentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentCreateResponseFromRaw.FromRawUnchecked"/>
    public static PaymentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentCreateResponseFromRaw : IFromRawJson<PaymentCreateResponse>
{
    /// <inheritdoc/>
    public PaymentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentCreateResponse.FromRawUnchecked(rawData);
}
