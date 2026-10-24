using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Translations;

/// <summary>
/// The translations of a credit entitlement.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreditEntitlementTranslationsListResponse,
        CreditEntitlementTranslationsListResponseFromRaw
    >)
)]
public sealed record class CreditEntitlementTranslationsListResponse : JsonModel
{
    public required IReadOnlyList<CreditEntitlementTranslation> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditEntitlementTranslation>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditEntitlementTranslation>>(
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

    public CreditEntitlementTranslationsListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementTranslationsListResponse(
        CreditEntitlementTranslationsListResponse creditEntitlementTranslationsListResponse
    )
        : base(creditEntitlementTranslationsListResponse) { }
#pragma warning restore CS8618

    public CreditEntitlementTranslationsListResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementTranslationsListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementTranslationsListResponseFromRaw.FromRawUnchecked"/>
    public static CreditEntitlementTranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditEntitlementTranslationsListResponse(
        IReadOnlyList<CreditEntitlementTranslation> items
    )
        : this()
    {
        this.Items = items;
    }
}

class CreditEntitlementTranslationsListResponseFromRaw
    : IFromRawJson<CreditEntitlementTranslationsListResponse>
{
    /// <inheritdoc/>
    public CreditEntitlementTranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditEntitlementTranslationsListResponse.FromRawUnchecked(rawData);
}
