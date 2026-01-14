using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

[JsonConverter(
    typeof(JsonModelConverter<LedgerEntryListPageResponse, LedgerEntryListPageResponseFromRaw>)
)]
public sealed record class LedgerEntryListPageResponse : JsonModel
{
    public required IReadOnlyList<CustomerWalletTransaction> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerWalletTransaction>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerWalletTransaction>>(
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

    public LedgerEntryListPageResponse() { }

    public LedgerEntryListPageResponse(LedgerEntryListPageResponse ledgerEntryListPageResponse)
        : base(ledgerEntryListPageResponse) { }

    public LedgerEntryListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerEntryListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LedgerEntryListPageResponseFromRaw.FromRawUnchecked"/>
    public static LedgerEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerEntryListPageResponse(IReadOnlyList<CustomerWalletTransaction> items)
        : this()
    {
        this.Items = items;
    }
}

class LedgerEntryListPageResponseFromRaw : IFromRawJson<LedgerEntryListPageResponse>
{
    /// <inheritdoc/>
    public LedgerEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerEntryListPageResponse.FromRawUnchecked(rawData);
}
