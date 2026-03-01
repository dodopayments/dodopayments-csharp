using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

[JsonConverter(
    typeof(JsonModelConverter<BalanceListLedgerPageResponse, BalanceListLedgerPageResponseFromRaw>)
)]
public sealed record class BalanceListLedgerPageResponse : JsonModel
{
    public required IReadOnlyList<CreditLedgerEntry> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditLedgerEntry>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditLedgerEntry>>(
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

    public BalanceListLedgerPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceListLedgerPageResponse(
        BalanceListLedgerPageResponse balanceListLedgerPageResponse
    )
        : base(balanceListLedgerPageResponse) { }
#pragma warning restore CS8618

    public BalanceListLedgerPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceListLedgerPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceListLedgerPageResponseFromRaw.FromRawUnchecked"/>
    public static BalanceListLedgerPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BalanceListLedgerPageResponse(IReadOnlyList<CreditLedgerEntry> items)
        : this()
    {
        this.Items = items;
    }
}

class BalanceListLedgerPageResponseFromRaw : IFromRawJson<BalanceListLedgerPageResponse>
{
    /// <inheritdoc/>
    public BalanceListLedgerPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceListLedgerPageResponse.FromRawUnchecked(rawData);
}
