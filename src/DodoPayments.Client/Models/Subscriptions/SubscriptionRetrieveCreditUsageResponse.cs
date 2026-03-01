using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Credit usage status for all entitlements linked to a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRetrieveCreditUsageResponse,
        SubscriptionRetrieveCreditUsageResponseFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveCreditUsageResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.SubscriptionID;
    }

    public SubscriptionRetrieveCreditUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveCreditUsageResponse(
        SubscriptionRetrieveCreditUsageResponse subscriptionRetrieveCreditUsageResponse
    )
        : base(subscriptionRetrieveCreditUsageResponse) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveCreditUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveCreditUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveCreditUsageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveCreditUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveCreditUsageResponseFromRaw
    : IFromRawJson<SubscriptionRetrieveCreditUsageResponse>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveCreditUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveCreditUsageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-entitlement credit usage status for a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    /// <summary>
    /// Customer's current credit balance for this entitlement (customer-wide)
    /// </summary>
    public required string Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CreditEntitlementName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_name");
        }
        init { this._rawData.Set("credit_entitlement_name", value); }
    }

    /// <summary>
    /// True if overage has reached or exceeded the limit. When true, further deductions
    /// that would increase overage will fail.
    /// </summary>
    public required bool LimitReached
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("limit_reached");
        }
        init { this._rawData.Set("limit_reached", value); }
    }

    /// <summary>
    /// Current overage amount accrued (customer-wide)
    /// </summary>
    public required string Overage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage");
        }
        init { this._rawData.Set("overage", value); }
    }

    /// <summary>
    /// Whether overage is enabled for this entitlement on this subscription
    /// </summary>
    public required bool OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Unit label for the credit entitlement (e.g. "API Calls", "Tokens")
    /// </summary>
    public required string Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    /// <summary>
    /// Maximum allowed overage before deductions are blocked. None means unlimited
    /// overage (when overage_enabled is true).
    /// </summary>
    public string? OverageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("overage_limit");
        }
        init { this._rawData.Set("overage_limit", value); }
    }

    /// <summary>
    /// How much more overage can accumulate before being blocked. None if overage
    /// is not enabled or there is no limit (unlimited). A value of 0 means the next
    /// deduction that increases overage will be blocked.
    /// </summary>
    public string? RemainingHeadroom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("remaining_headroom");
        }
        init { this._rawData.Set("remaining_headroom", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.LimitReached;
        _ = this.Overage;
        _ = this.OverageEnabled;
        _ = this.Unit;
        _ = this.OverageLimit;
        _ = this.RemainingHeadroom;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
