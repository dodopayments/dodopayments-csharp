using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<PaymentCreateResponse, PaymentCreateResponseFromRaw>))]
public sealed record class PaymentCreateResponse : ModelBase
{
    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public required string ClientSecret
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "client_secret"); }
        init { ModelBase.Set(this._rawData, "client_secret", value); }
    }

    /// <summary>
    /// Limited details about the customer making the payment
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Unique identifier for the payment
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// Total amount of the payment in smallest currency unit (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { ModelBase.Set(this._rawData, "total_amount", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { ModelBase.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// Expiry timestamp of the payment link
    /// </summary>
    public DateTimeOffset? ExpiresOn
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "expires_on"); }
        init { ModelBase.Set(this._rawData, "expires_on", value); }
    }

    /// <summary>
    /// Optional URL to a hosted payment page
    /// </summary>
    public string? PaymentLink
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_link"); }
        init { ModelBase.Set(this._rawData, "payment_link", value); }
    }

    /// <summary>
    /// Optional list of products included in the payment
    /// </summary>
    public IReadOnlyList<OneTimeProductCartItem>? ProductCart
    {
        get
        {
            return ModelBase.GetNullableClass<List<OneTimeProductCartItem>>(
                this.RawData,
                "product_cart"
            );
        }
        init { ModelBase.Set(this._rawData, "product_cart", value); }
    }

    public override void Validate()
    {
        _ = this.ClientSecret;
        this.Customer.Validate();
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.TotalAmount;
        _ = this.DiscountID;
        _ = this.ExpiresOn;
        _ = this.PaymentLink;
        foreach (var item in this.ProductCart ?? [])
        {
            item.Validate();
        }
    }

    public PaymentCreateResponse() { }

    public PaymentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PaymentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentCreateResponseFromRaw : IFromRaw<PaymentCreateResponse>
{
    public PaymentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentCreateResponse.FromRawUnchecked(rawData);
}
