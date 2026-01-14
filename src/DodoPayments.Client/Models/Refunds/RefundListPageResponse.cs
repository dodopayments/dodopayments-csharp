using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(JsonModelConverter<RefundListPageResponse, RefundListPageResponseFromRaw>))]
public sealed record class RefundListPageResponse : JsonModel
{
    public required IReadOnlyList<RefundListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RefundListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RefundListResponse>>(
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

    public RefundListPageResponse() { }

    public RefundListPageResponse(RefundListPageResponse refundListPageResponse)
        : base(refundListPageResponse) { }

    public RefundListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundListPageResponseFromRaw.FromRawUnchecked"/>
    public static RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RefundListPageResponse(IReadOnlyList<RefundListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class RefundListPageResponseFromRaw : IFromRawJson<RefundListPageResponse>
{
    /// <inheritdoc/>
    public RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundListPageResponse.FromRawUnchecked(rawData);
}
