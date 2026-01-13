using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRetrieveUsageHistoryPageResponse,
        SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponse : JsonModel
{
    /// <summary>
    /// List of usage history items
    /// </summary>
    public required IReadOnlyList<SubscriptionRetrieveUsageHistoryResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SubscriptionRetrieveUsageHistoryResponse>
            >("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionRetrieveUsageHistoryResponse>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public SubscriptionRetrieveUsageHistoryPageResponse() { }

    public SubscriptionRetrieveUsageHistoryPageResponse(
        SubscriptionRetrieveUsageHistoryPageResponse subscriptionRetrieveUsageHistoryPageResponse
    )
        : base(subscriptionRetrieveUsageHistoryPageResponse) { }

    public SubscriptionRetrieveUsageHistoryPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveUsageHistoryPageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(
        List<SubscriptionRetrieveUsageHistoryResponse> items
    )
        : this()
    {
        this.Items = items;
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    : IFromRawJson<SubscriptionRetrieveUsageHistoryPageResponse>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponse.FromRawUnchecked(rawData);
}
