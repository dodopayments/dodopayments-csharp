using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payouts.Breakup;

/// <summary>
/// Payout breakup aggregated by event type, with amounts in the payout's currency.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BreakupRetrieveResponse, BreakupRetrieveResponseFromRaw>))]
public sealed record class BreakupRetrieveResponse : JsonModel
{
    /// <summary>
    /// The type of balance ledger event (e.g., "payment", "refund", "dispute", "payment_fees").
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <summary>
    /// Total amount for this event type in the payout's currency, in that currency's
    /// smallest unit (cents for USD, yen for JPY, fils for KWD).
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventType;
        _ = this.Total;
    }

    public BreakupRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BreakupRetrieveResponse(BreakupRetrieveResponse breakupRetrieveResponse)
        : base(breakupRetrieveResponse) { }
#pragma warning restore CS8618

    public BreakupRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BreakupRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BreakupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BreakupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BreakupRetrieveResponseFromRaw : IFromRawJson<BreakupRetrieveResponse>
{
    /// <inheritdoc/>
    public BreakupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BreakupRetrieveResponse.FromRawUnchecked(rawData);
}
