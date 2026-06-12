using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payouts.Breakup.Details;

/// <summary>
/// Individual balance ledger entry for a payout, with amounts pro-rated into the
/// payout's currency.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DetailListResponse, DetailListResponseFromRaw>))]
public sealed record class DetailListResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the balance ledger entry.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp when this entry was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

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
    /// Original amount in the original currency, in that currency's smallest unit
    /// (cents for USD, yen for JPY, fils for KWD).
    /// </summary>
    public required long OriginalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("original_amount");
        }
        init { this._rawData.Set("original_amount", value); }
    }

    /// <summary>
    /// Original currency as ISO 4217 code (e.g., "USD", "EUR").
    /// </summary>
    public required string OriginalCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("original_currency");
        }
        init { this._rawData.Set("original_currency", value); }
    }

    /// <summary>
    /// Amount in the payout's currency, in that currency's smallest unit (cents for
    /// USD, yen for JPY, fils for KWD). Uses cumulative rounding to ensure sum matches
    /// payout total exactly.
    /// </summary>
    public required long PayoutCurrencyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("payout_currency_amount");
        }
        init { this._rawData.Set("payout_currency_amount", value); }
    }

    /// <summary>
    /// USD equivalent of the original amount (in cents).
    /// </summary>
    public required long UsdEquivalentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("usd_equivalent_amount");
        }
        init { this._rawData.Set("usd_equivalent_amount", value); }
    }

    /// <summary>
    /// Human-readable description of the transaction.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// ID of the related object (e.g., payment ID, refund ID) if applicable.
    /// </summary>
    public string? ReferenceObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_object_id");
        }
        init { this._rawData.Set("reference_object_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.EventType;
        _ = this.OriginalAmount;
        _ = this.OriginalCurrency;
        _ = this.PayoutCurrencyAmount;
        _ = this.UsdEquivalentAmount;
        _ = this.Description;
        _ = this.ReferenceObjectID;
    }

    public DetailListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailListResponse(DetailListResponse detailListResponse)
        : base(detailListResponse) { }
#pragma warning restore CS8618

    public DetailListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DetailListResponseFromRaw.FromRawUnchecked"/>
    public static DetailListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DetailListResponseFromRaw : IFromRawJson<DetailListResponse>
{
    /// <inheritdoc/>
    public DetailListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DetailListResponse.FromRawUnchecked(rawData);
}
