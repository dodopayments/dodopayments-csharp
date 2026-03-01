using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditEntitlementListPageResponse,
        CreditEntitlementListPageResponseFromRaw
    >)
)]
public sealed record class CreditEntitlementListPageResponse : JsonModel
{
    public required IReadOnlyList<CreditEntitlement> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditEntitlement>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditEntitlement>>(
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

    public CreditEntitlementListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementListPageResponse(
        CreditEntitlementListPageResponse creditEntitlementListPageResponse
    )
        : base(creditEntitlementListPageResponse) { }
#pragma warning restore CS8618

    public CreditEntitlementListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementListPageResponseFromRaw.FromRawUnchecked"/>
    public static CreditEntitlementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditEntitlementListPageResponse(IReadOnlyList<CreditEntitlement> items)
        : this()
    {
        this.Items = items;
    }
}

class CreditEntitlementListPageResponseFromRaw : IFromRawJson<CreditEntitlementListPageResponse>
{
    /// <inheritdoc/>
    public CreditEntitlementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditEntitlementListPageResponse.FromRawUnchecked(rawData);
}
