using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(
    typeof(JsonModelConverter<InvoiceListEventsResponse, InvoiceListEventsResponseFromRaw>)
)]
public sealed record class InvoiceListEventsResponse : JsonModel
{
    public required IReadOnlyList<InvoiceEvent> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InvoiceEvent>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceEvent>>(
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

    public InvoiceListEventsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListEventsResponse(InvoiceListEventsResponse invoiceListEventsResponse)
        : base(invoiceListEventsResponse) { }
#pragma warning restore CS8618

    public InvoiceListEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListEventsResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceListEventsResponse(IReadOnlyList<InvoiceEvent> items)
        : this()
    {
        this.Items = items;
    }
}

class InvoiceListEventsResponseFromRaw : IFromRawJson<InvoiceListEventsResponse>
{
    /// <inheritdoc/>
    public InvoiceListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListEventsResponse.FromRawUnchecked(rawData);
}
