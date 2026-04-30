using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements.Grants;

[JsonConverter(typeof(JsonModelConverter<GrantListPageResponse, GrantListPageResponseFromRaw>))]
public sealed record class GrantListPageResponse : JsonModel
{
    public required IReadOnlyList<GrantListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GrantListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GrantListResponse>>(
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

    public GrantListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListPageResponse(GrantListPageResponse grantListPageResponse)
        : base(grantListPageResponse) { }
#pragma warning restore CS8618

    public GrantListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListPageResponseFromRaw.FromRawUnchecked"/>
    public static GrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GrantListPageResponse(IReadOnlyList<GrantListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class GrantListPageResponseFromRaw : IFromRawJson<GrantListPageResponse>
{
    /// <inheritdoc/>
    public GrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantListPageResponse.FromRawUnchecked(rawData);
}
