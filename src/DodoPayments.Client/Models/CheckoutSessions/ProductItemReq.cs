using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<ProductItemReq, ProductItemReqFromRaw>))]
public sealed record class ProductItemReq : JsonModel
{
    /// <summary>
    /// unique id of the product
    /// </summary>
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

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public IReadOnlyList<AttachAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttachAddon>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttachAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`. Only applicable
    /// for one time payments
    ///
    /// <para>If amount is not set for pay_what_you_want product, customer is allowed
    /// to select the amount.</para>
    /// </summary>
    public int? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Per-checkout-session overrides for credit entitlements already attached to
    /// this product. Each entry overrides the `credits_amount` granted by the referenced
    /// credit entitlement when this checkout session is fulfilled. The credit_entitlement_id
    /// must already be attached to the product.
    /// </summary>
    public IReadOnlyList<CreditEntitlement>? CreditEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CreditEntitlement>>(
                "credit_entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditEntitlement>?>(
                "credit_entitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.Amount;
        foreach (var item in this.CreditEntitlements ?? [])
        {
            item.Validate();
        }
    }

    public ProductItemReq() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductItemReq(ProductItemReq productItemReq)
        : base(productItemReq) { }
#pragma warning restore CS8618

    public ProductItemReq(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductItemReq(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductItemReqFromRaw.FromRawUnchecked"/>
    public static ProductItemReq FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductItemReqFromRaw : IFromRawJson<ProductItemReq>
{
    /// <inheritdoc/>
    public ProductItemReq FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductItemReq.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-checkout-session override for a single credit entitlement attached to a product.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditEntitlement, CreditEntitlementFromRaw>))]
public sealed record class CreditEntitlement : JsonModel
{
    /// <summary>
    /// ID of the credit entitlement to override. Must already be attached to the product.
    /// </summary>
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    /// <summary>
    /// Number of credits to grant for this checkout session, overriding the product-level
    /// `credits_amount` set on the credit entitlement mapping. Must be greater than zero.
    /// </summary>
    public required string CreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits_amount");
        }
        init { this._rawData.Set("credits_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.CreditsAmount;
    }

    public CreditEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlement(CreditEntitlement creditEntitlement)
        : base(creditEntitlement) { }
#pragma warning restore CS8618

    public CreditEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementFromRaw.FromRawUnchecked"/>
    public static CreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditEntitlementFromRaw : IFromRawJson<CreditEntitlement>
{
    /// <inheritdoc/>
    public CreditEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditEntitlement.FromRawUnchecked(rawData);
}
