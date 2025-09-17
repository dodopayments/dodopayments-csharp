using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

[JsonConverter(typeof(Client::ModelConverter<LedgerEntryListPageResponse>))]
public sealed record class LedgerEntryListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<LedgerEntryListPageResponse>
{
    public required List<CustomerWalletTransaction> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<CustomerWalletTransaction>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public LedgerEntryListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerEntryListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LedgerEntryListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public LedgerEntryListPageResponse(List<CustomerWalletTransaction> items)
        : this()
    {
        this.Items = items;
    }
}
