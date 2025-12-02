using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

[JsonConverter(
    typeof(ModelConverter<LedgerEntryListPageResponse, LedgerEntryListPageResponseFromRaw>)
)]
public sealed record class LedgerEntryListPageResponse : ModelBase
{
    public required IReadOnlyList<CustomerWalletTransaction> Items
    {
        get
        {
            return ModelBase.GetNotNullClass<List<CustomerWalletTransaction>>(
                this.RawData,
                "items"
            );
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public LedgerEntryListPageResponse() { }

    public LedgerEntryListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerEntryListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerEntryListPageResponse(List<CustomerWalletTransaction> items)
        : this()
    {
        this.Items = items;
    }
}

class LedgerEntryListPageResponseFromRaw : IFromRaw<LedgerEntryListPageResponse>
{
    public LedgerEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerEntryListPageResponse.FromRawUnchecked(rawData);
}
