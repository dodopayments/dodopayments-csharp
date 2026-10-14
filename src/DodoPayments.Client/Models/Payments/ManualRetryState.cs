using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<ManualRetryState, ManualRetryStateFromRaw>))]
public sealed record class ManualRetryState : JsonModel
{
    public required bool CanRetry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("can_retry");
        }
        init { this._rawData.Set("can_retry", value); }
    }

    public required long SendsAllowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sends_allowed");
        }
        init { this._rawData.Set("sends_allowed", value); }
    }

    public required long SendsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sends_used");
        }
        init { this._rawData.Set("sends_used", value); }
    }

    /// <summary>
    /// The number of the queued automatic retry, starting at 1.
    /// </summary>
    public int? AutomaticRetryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("automatic_retry_number");
        }
        init { this._rawData.Set("automatic_retry_number", value); }
    }

    /// <summary>
    /// The number of automatic retries that the current configuration plans for this
    /// invoice. It is never less than `automatic_retry_number`.
    /// </summary>
    public int? AutomaticRetryTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("automatic_retry_total");
        }
        init { this._rawData.Set("automatic_retry_total", value); }
    }

    /// <summary>
    /// When the next automatic retry on this invoice is scheduled. Null when no automatic
    /// retry is queued or automatic retries are disabled.
    /// </summary>
    public DateTimeOffset? NextAutomaticRetryAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("next_automatic_retry_at");
        }
        init { this._rawData.Set("next_automatic_retry_at", value); }
    }

    /// <summary>
    /// The code `POST` would fail with. Null when `can_retry` is true.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// When the next send becomes available. Null when no send is left, or when
    /// the block has nothing to do with the cooldown.
    /// </summary>
    public DateTimeOffset? RetryAvailableAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("retry_available_at");
        }
        init { this._rawData.Set("retry_available_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanRetry;
        _ = this.SendsAllowed;
        _ = this.SendsUsed;
        _ = this.AutomaticRetryNumber;
        _ = this.AutomaticRetryTotal;
        _ = this.NextAutomaticRetryAt;
        _ = this.Reason;
        _ = this.RetryAvailableAt;
    }

    public ManualRetryState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManualRetryState(ManualRetryState manualRetryState)
        : base(manualRetryState) { }
#pragma warning restore CS8618

    public ManualRetryState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ManualRetryState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ManualRetryStateFromRaw.FromRawUnchecked"/>
    public static ManualRetryState FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ManualRetryStateFromRaw : IFromRawJson<ManualRetryState>
{
    /// <inheritdoc/>
    public ManualRetryState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ManualRetryState.FromRawUnchecked(rawData);
}
