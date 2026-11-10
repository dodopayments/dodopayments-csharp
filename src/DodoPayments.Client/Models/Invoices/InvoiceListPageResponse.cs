using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(typeof(JsonModelConverter<InvoiceListPageResponse, InvoiceListPageResponseFromRaw>))]
public sealed record class InvoiceListPageResponse : JsonModel
{
    public required IReadOnlyList<Invoice> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Invoice>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invoice>>(
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

    public InvoiceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListPageResponse(InvoiceListPageResponse invoiceListPageResponse)
        : base(invoiceListPageResponse) { }
#pragma warning restore CS8618

    public InvoiceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListPageResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceListPageResponse(IReadOnlyList<Invoice> items)
        : this()
    {
        this.Items = items;
    }
}

class InvoiceListPageResponseFromRaw : IFromRawJson<InvoiceListPageResponse>
{
    /// <inheritdoc/>
    public InvoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListPageResponse.FromRawUnchecked(rawData);
}
