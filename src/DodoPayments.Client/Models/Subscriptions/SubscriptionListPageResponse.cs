using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListPageResponse, SubscriptionListPageResponseFromRaw>)
)]
public sealed record class SubscriptionListPageResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubscriptionListResponse>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionListResponse>>(
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

    public SubscriptionListPageResponse() { }

    public SubscriptionListPageResponse(SubscriptionListPageResponse subscriptionListPageResponse)
        : base(subscriptionListPageResponse) { }

    public SubscriptionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListPageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionListPageResponse(List<SubscriptionListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class SubscriptionListPageResponseFromRaw : IFromRawJson<SubscriptionListPageResponse>
{
    /// <inheritdoc/>
    public SubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListPageResponse.FromRawUnchecked(rawData);
}
