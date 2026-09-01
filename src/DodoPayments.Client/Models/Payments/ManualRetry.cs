using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<ManualRetry, ManualRetryFromRaw>))]
public sealed record class ManualRetry : JsonModel
{
    /// <summary>
    /// The invoice the send charged.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_id");
        }
        init { this._rawData.Set("invoice_id", value); }
    }

    /// <summary>
    /// Always true on this route. Tells the row apart from an automatic attempt.
    /// </summary>
    public required bool IsManualRetry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_manual_retry");
        }
        init { this._rawData.Set("is_manual_retry", value); }
    }

    /// <summary>
    /// The payment row this send created.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Which attempt this send is, counting manual sends on the invoice.
    /// </summary>
    public required int RetryAttempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("retry_attempt");
        }
        init { this._rawData.Set("retry_attempt", value); }
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

    /// <summary>
    /// Manual sends spent on this invoice, including this one.
    /// </summary>
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
    /// When the next send becomes available. Null when no send is left.
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

    /// <summary>
    /// Outcome of the charge. `processing` means the processor has not settled it
    /// yet, and the payment webhooks report the result.
    /// </summary>
    public ApiEnum<string, IntentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntentStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InvoiceID;
        _ = this.IsManualRetry;
        _ = this.PaymentID;
        _ = this.RetryAttempt;
        _ = this.SendsAllowed;
        _ = this.SendsUsed;
        _ = this.RetryAvailableAt;
        this.Status?.Validate();
    }

    public ManualRetry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManualRetry(ManualRetry manualRetry)
        : base(manualRetry) { }
#pragma warning restore CS8618

    public ManualRetry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ManualRetry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ManualRetryFromRaw.FromRawUnchecked"/>
    public static ManualRetry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ManualRetryFromRaw : IFromRawJson<ManualRetry>
{
    /// <inheritdoc/>
    public ManualRetry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ManualRetry.FromRawUnchecked(rawData);
}
