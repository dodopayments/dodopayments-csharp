using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payouts;

[JsonConverter(typeof(JsonModelConverter<PayoutListPageResponse, PayoutListPageResponseFromRaw>))]
public sealed record class PayoutListPageResponse : JsonModel
{
    public required IReadOnlyList<PayoutListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PayoutListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PayoutListResponse>>(
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

    public PayoutListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutListPageResponse(PayoutListPageResponse payoutListPageResponse)
        : base(payoutListPageResponse) { }
#pragma warning restore CS8618

    public PayoutListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutListPageResponseFromRaw.FromRawUnchecked"/>
    public static PayoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PayoutListPageResponse(IReadOnlyList<PayoutListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class PayoutListPageResponseFromRaw : IFromRawJson<PayoutListPageResponse>
{
    /// <inheritdoc/>
    public PayoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutListPageResponse.FromRawUnchecked(rawData);
}
