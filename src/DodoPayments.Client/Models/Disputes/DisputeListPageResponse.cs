using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(JsonModelConverter<DisputeListPageResponse, DisputeListPageResponseFromRaw>))]
public sealed record class DisputeListPageResponse : JsonModel
{
    public required IReadOnlyList<DisputeListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DisputeListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DisputeListResponse>>(
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

    public DisputeListPageResponse() { }

    public DisputeListPageResponse(DisputeListPageResponse disputeListPageResponse)
        : base(disputeListPageResponse) { }

    public DisputeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeListPageResponseFromRaw.FromRawUnchecked"/>
    public static DisputeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DisputeListPageResponse(IReadOnlyList<DisputeListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class DisputeListPageResponseFromRaw : IFromRawJson<DisputeListPageResponse>
{
    /// <inheritdoc/>
    public DisputeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeListPageResponse.FromRawUnchecked(rawData);
}
