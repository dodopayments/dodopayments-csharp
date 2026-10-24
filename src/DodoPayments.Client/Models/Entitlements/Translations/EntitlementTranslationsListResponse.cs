using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements.Translations;

/// <summary>
/// The translations of an entitlement.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementTranslationsListResponse,
        EntitlementTranslationsListResponseFromRaw
    >)
)]
public sealed record class EntitlementTranslationsListResponse : JsonModel
{
    public required IReadOnlyList<EntitlementTranslation> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitlementTranslation>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitlementTranslation>>(
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

    public EntitlementTranslationsListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementTranslationsListResponse(
        EntitlementTranslationsListResponse entitlementTranslationsListResponse
    )
        : base(entitlementTranslationsListResponse) { }
#pragma warning restore CS8618

    public EntitlementTranslationsListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementTranslationsListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementTranslationsListResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementTranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementTranslationsListResponse(IReadOnlyList<EntitlementTranslation> items)
        : this()
    {
        this.Items = items;
    }
}

class EntitlementTranslationsListResponseFromRaw : IFromRawJson<EntitlementTranslationsListResponse>
{
    /// <inheritdoc/>
    public EntitlementTranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementTranslationsListResponse.FromRawUnchecked(rawData);
}
