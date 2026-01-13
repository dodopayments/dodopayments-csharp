using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(JsonModelConverter<GetDispute, GetDisputeFromRaw>))]
public sealed record class GetDispute : JsonModel
{
    /// <summary>
    /// The amount involved in the dispute, represented as a string to accommodate precision.
    /// </summary>
    public required string Amount
    {
        get { return this._rawData.GetNotNullClass<string>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The unique identifier of the business involved in the dispute.
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The timestamp of when the dispute was created, in UTC.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The currency of the disputed amount, represented as an ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get { return this._rawData.GetNotNullClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The customer who filed the dispute
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer"); }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// The unique identifier of the dispute.
    /// </summary>
    public required string DisputeID
    {
        get { return this._rawData.GetNotNullClass<string>("dispute_id"); }
        init { this._rawData.Set("dispute_id", value); }
    }

    /// <summary>
    /// The current stage of the dispute process.
    /// </summary>
    public required ApiEnum<string, DisputeDisputeStage> DisputeStage
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DisputeDisputeStage>>(
                "dispute_stage"
            );
        }
        init { this._rawData.Set("dispute_stage", value); }
    }

    /// <summary>
    /// The current status of the dispute.
    /// </summary>
    public required ApiEnum<string, DisputeDisputeStatus> DisputeStatus
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DisputeDisputeStatus>>(
                "dispute_status"
            );
        }
        init { this._rawData.Set("dispute_status", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the dispute.
    /// </summary>
    public required string PaymentID
    {
        get { return this._rawData.GetNotNullClass<string>("payment_id"); }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Reason for the dispute
    /// </summary>
    public string? Reason
    {
        get { return this._rawData.GetNullableClass<string>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Remarks
    /// </summary>
    public string? Remarks
    {
        get { return this._rawData.GetNullableClass<string>("remarks"); }
        init { this._rawData.Set("remarks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        _ = this.Reason;
        _ = this.Remarks;
    }

    public GetDispute() { }

    public GetDispute(GetDispute getDispute)
        : base(getDispute) { }

    public GetDispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GetDispute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GetDisputeFromRaw.FromRawUnchecked"/>
    public static GetDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GetDisputeFromRaw : IFromRawJson<GetDispute>
{
    /// <inheritdoc/>
    public GetDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GetDispute.FromRawUnchecked(rawData);
}
