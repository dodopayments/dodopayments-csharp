using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Balances;

[JsonConverter(
    typeof(JsonModelConverter<
        BalanceRetrieveLedgerPageResponse,
        BalanceRetrieveLedgerPageResponseFromRaw
    >)
)]
public sealed record class BalanceRetrieveLedgerPageResponse : JsonModel
{
    public required IReadOnlyList<BalanceLedgerEntry> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BalanceLedgerEntry>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BalanceLedgerEntry>>(
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

    public BalanceRetrieveLedgerPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceRetrieveLedgerPageResponse(
        BalanceRetrieveLedgerPageResponse balanceRetrieveLedgerPageResponse
    )
        : base(balanceRetrieveLedgerPageResponse) { }
#pragma warning restore CS8618

    public BalanceRetrieveLedgerPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceRetrieveLedgerPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceRetrieveLedgerPageResponseFromRaw.FromRawUnchecked"/>
    public static BalanceRetrieveLedgerPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BalanceRetrieveLedgerPageResponse(IReadOnlyList<BalanceLedgerEntry> items)
        : this()
    {
        this.Items = items;
    }
}

class BalanceRetrieveLedgerPageResponseFromRaw : IFromRawJson<BalanceRetrieveLedgerPageResponse>
{
    /// <inheritdoc/>
    public BalanceRetrieveLedgerPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceRetrieveLedgerPageResponse.FromRawUnchecked(rawData);
}
