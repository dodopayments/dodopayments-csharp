using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Models.Blocklist.Customers;

[JsonConverter(typeof(JsonModelConverter<BlockedCustomer, BlockedCustomerFromRaw>))]
public sealed record class BlockedCustomer : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CustomerEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_email");
        }
        init { this._rawData.Set("customer_email", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required string CustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_name");
        }
        init { this._rawData.Set("customer_name", value); }
    }

    /// <summary>
    /// Customer id or email that the merchant supplied.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <summary>
    /// Where a block came from. `Api` marks an API-key caller, which carries no dashboard
    /// actor. The other values name the screen the merchant used.
    /// </summary>
    public required ApiEnum<string, BlockedCustomerSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BlockedCustomerSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Dashboard user who blocked the customer. `null` for an API-key caller.
    /// </summary>
    public string? BlockedByEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("blocked_by_email");
        }
        init { this._rawData.Set("blocked_by_email", value); }
    }

    /// <summary>
    /// Subscriptions this block cancelled. Present on the create response only.
    /// </summary>
    public IReadOnlyList<string>? CancelledSubscriptionIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "cancelled_subscription_ids"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "cancelled_subscription_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Activity log. Present on the detail response only.
    /// </summary>
    public IReadOnlyList<BlockedCustomerNote>? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BlockedCustomerNote>>("notes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BlockedCustomerNote>?>(
                "notes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Subscriptions this block left live, because the cancel failed or the inline
    /// batch filled up. Repeat the create call to continue; the block itself is already
    /// in force.
    /// </summary>
    public IReadOnlyList<string>? RemainingSubscriptionIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "remaining_subscription_ids"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "remaining_subscription_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// False when the block left live subscriptions behind, including the case where
    /// the sweep could not list them and `remaining_subscription_ids` is therefore
    /// unknown. Repeat the create call until it reads true.
    /// </summary>
    public bool? SubscriptionsSwept
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("subscriptions_swept");
        }
        init { this._rawData.Set("subscriptions_swept", value); }
    }

    public DateTimeOffset? UnblockedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("unblocked_at");
        }
        init { this._rawData.Set("unblocked_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomerEmail;
        _ = this.CustomerID;
        _ = this.CustomerName;
        _ = this.Identifier;
        this.Source.Validate();
        _ = this.BlockedByEmail;
        _ = this.CancelledSubscriptionIds;
        foreach (var item in this.Notes ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
        _ = this.RemainingSubscriptionIds;
        _ = this.SubscriptionsSwept;
        _ = this.UnblockedAt;
    }

    public BlockedCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockedCustomer(BlockedCustomer blockedCustomer)
        : base(blockedCustomer) { }
#pragma warning restore CS8618

    public BlockedCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockedCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockedCustomerFromRaw.FromRawUnchecked"/>
    public static BlockedCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockedCustomerFromRaw : IFromRawJson<BlockedCustomer>
{
    /// <inheritdoc/>
    public BlockedCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BlockedCustomer.FromRawUnchecked(rawData);
}
