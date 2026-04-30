using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements;

[JsonConverter(
    typeof(JsonModelConverter<EntitlementListPageResponse, EntitlementListPageResponseFromRaw>)
)]
public sealed record class EntitlementListPageResponse : JsonModel
{
    public required IReadOnlyList<EntitlementListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitlementListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitlementListResponse>>(
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

    public EntitlementListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListPageResponse(EntitlementListPageResponse entitlementListPageResponse)
        : base(entitlementListPageResponse) { }
#pragma warning restore CS8618

    public EntitlementListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListPageResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListPageResponse(IReadOnlyList<EntitlementListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class EntitlementListPageResponseFromRaw : IFromRawJson<EntitlementListPageResponse>
{
    /// <inheritdoc/>
    public EntitlementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListPageResponse.FromRawUnchecked(rawData);
}
