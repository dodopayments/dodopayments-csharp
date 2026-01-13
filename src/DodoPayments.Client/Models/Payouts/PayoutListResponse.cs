using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payouts;

[JsonConverter(typeof(JsonModelConverter<PayoutListResponse, PayoutListResponseFromRaw>))]
public sealed record class PayoutListResponse : JsonModel
{
    /// <summary>
    /// The total amount of the payout.
    /// </summary>
    public required long Amount
    {
        get { return this._rawData.GetNotNullStruct<long>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the payout.
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The total value of chargebacks associated with the payout.
    /// </summary>
    [Obsolete("deprecated")]
    public required long Chargebacks
    {
        get { return this._rawData.GetNotNullStruct<long>("chargebacks"); }
        init { this._rawData.Set("chargebacks", value); }
    }

    /// <summary>
    /// The timestamp when the payout was created, in UTC.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The currency of the payout, represented as an ISO 4217 currency code.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The fee charged for processing the payout.
    /// </summary>
    public required long Fee
    {
        get { return this._rawData.GetNotNullStruct<long>("fee"); }
        init { this._rawData.Set("fee", value); }
    }

    /// <summary>
    /// The payment method used for the payout (e.g., bank transfer, card, etc.).
    /// </summary>
    public required string PaymentMethod
    {
        get { return this._rawData.GetNotNullClass<string>("payment_method"); }
        init { this._rawData.Set("payment_method", value); }
    }

    /// <summary>
    /// The unique identifier of the payout.
    /// </summary>
    public required string PayoutID
    {
        get { return this._rawData.GetNotNullClass<string>("payout_id"); }
        init { this._rawData.Set("payout_id", value); }
    }

    /// <summary>
    /// The total value of refunds associated with the payout.
    /// </summary>
    [Obsolete("deprecated")]
    public required long Refunds
    {
        get { return this._rawData.GetNotNullStruct<long>("refunds"); }
        init { this._rawData.Set("refunds", value); }
    }

    /// <summary>
    /// The current status of the payout.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status"); }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The tax applied to the payout.
    /// </summary>
    [Obsolete("deprecated")]
    public required long Tax
    {
        get { return this._rawData.GetNotNullStruct<long>("tax"); }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// The timestamp when the payout was last updated, in UTC.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The name of the payout recipient or purpose.
    /// </summary>
    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The URL of the document associated with the payout.
    /// </summary>
    public string? PayoutDocumentUrl
    {
        get { return this._rawData.GetNullableClass<string>("payout_document_url"); }
        init { this._rawData.Set("payout_document_url", value); }
    }

    /// <summary>
    /// Any additional remarks or notes associated with the payout.
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
        _ = this.Chargebacks;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Fee;
        _ = this.PaymentMethod;
        _ = this.PayoutID;
        _ = this.Refunds;
        this.Status.Validate();
        _ = this.Tax;
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.PayoutDocumentUrl;
        _ = this.Remarks;
    }

    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutListResponse() { }

    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutListResponse(PayoutListResponse payoutListResponse)
        : base(payoutListResponse) { }

    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    [SetsRequiredMembers]
    PayoutListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutListResponseFromRaw.FromRawUnchecked"/>
    public static PayoutListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutListResponseFromRaw : IFromRawJson<PayoutListResponse>
{
    /// <inheritdoc/>
    public PayoutListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayoutListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the payout.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotInitiated,
    InProgress,
    OnHold,
    Failed,
    Success,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_initiated" => Status.NotInitiated,
            "in_progress" => Status.InProgress,
            "on_hold" => Status.OnHold,
            "failed" => Status.Failed,
            "success" => Status.Success,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.NotInitiated => "not_initiated",
                Status.InProgress => "in_progress",
                Status.OnHold => "on_hold",
                Status.Failed => "failed",
                Status.Success => "success",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
