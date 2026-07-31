using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PayoutOnHoldWebhookEvent, PayoutOnHoldWebhookEventFromRaw>)
)]
public sealed record class PayoutOnHoldWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    public required PayoutOnHoldWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutOnHoldWebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("payout.on_hold")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public PayoutOnHoldWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("payout.on_hold");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutOnHoldWebhookEvent(PayoutOnHoldWebhookEvent payoutOnHoldWebhookEvent)
        : base(payoutOnHoldWebhookEvent) { }
#pragma warning restore CS8618

    public PayoutOnHoldWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payout.on_hold");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutOnHoldWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutOnHoldWebhookEventFromRaw.FromRawUnchecked"/>
    public static PayoutOnHoldWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutOnHoldWebhookEventFromRaw : IFromRawJson<PayoutOnHoldWebhookEvent>
{
    /// <inheritdoc/>
    public PayoutOnHoldWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutOnHoldWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PayoutOnHoldWebhookEventData, PayoutOnHoldWebhookEventDataFromRaw>)
)]
public sealed record class PayoutOnHoldWebhookEventData : JsonModel
{
    /// <summary>
    /// The total amount of the payout.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the payout.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The total value of chargebacks associated with the payout.
    /// </summary>
    [Obsolete("Use the v3 payout breakup endpoints instead. Will be removed in a future release.")]
    public required long Chargebacks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("chargebacks");
        }
        init { this._rawData.Set("chargebacks", value); }
    }

    /// <summary>
    /// The timestamp when the payout was created, in UTC.
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
    /// The currency of the payout, represented as an ISO 4217 currency code.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The fee charged for processing the payout.
    /// </summary>
    public required long Fee
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fee");
        }
        init { this._rawData.Set("fee", value); }
    }

    /// <summary>
    /// The payment method used for the payout (e.g., bank transfer, card, etc.).
    /// </summary>
    public required string PaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_method");
        }
        init { this._rawData.Set("payment_method", value); }
    }

    /// <summary>
    /// The unique identifier of the payout.
    /// </summary>
    public required string PayoutID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payout_id");
        }
        init { this._rawData.Set("payout_id", value); }
    }

    /// <summary>
    /// The total value of refunds associated with the payout.
    /// </summary>
    [Obsolete("Use the v3 payout breakup endpoints instead. Will be removed in a future release.")]
    public required long Refunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("refunds");
        }
        init { this._rawData.Set("refunds", value); }
    }

    /// <summary>
    /// The current status of the payout.
    /// </summary>
    public required ApiEnum<string, PayoutOnHoldWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutOnHoldWebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The tax applied to the payout.
    /// </summary>
    [Obsolete("Use the v3 payout breakup endpoints instead. Will be removed in a future release.")]
    public required long Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// The timestamp when the payout was last updated, in UTC.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The name of the payout recipient or purpose.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The URL of the document associated with the payout.
    /// </summary>
    public string? PayoutDocumentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payout_document_url");
        }
        init { this._rawData.Set("payout_document_url", value); }
    }

    /// <summary>
    /// Any additional remarks or notes associated with the payout.
    /// </summary>
    public string? Remarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("remarks");
        }
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
    public PayoutOnHoldWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutOnHoldWebhookEventData(PayoutOnHoldWebhookEventData payoutOnHoldWebhookEventData)
        : base(payoutOnHoldWebhookEventData) { }
#pragma warning restore CS8618

    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutOnHoldWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    [SetsRequiredMembers]
    PayoutOnHoldWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutOnHoldWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PayoutOnHoldWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutOnHoldWebhookEventDataFromRaw : IFromRawJson<PayoutOnHoldWebhookEventData>
{
    /// <inheritdoc/>
    public PayoutOnHoldWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutOnHoldWebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the payout.
/// </summary>
[JsonConverter(typeof(PayoutOnHoldWebhookEventDataStatusConverter))]
public enum PayoutOnHoldWebhookEventDataStatus
{
    NotInitiated,
    InProgress,
    OnHold,
    Failed,
    Success,
}

sealed class PayoutOnHoldWebhookEventDataStatusConverter
    : JsonConverter<PayoutOnHoldWebhookEventDataStatus>
{
    public override PayoutOnHoldWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_initiated" => PayoutOnHoldWebhookEventDataStatus.NotInitiated,
            "in_progress" => PayoutOnHoldWebhookEventDataStatus.InProgress,
            "on_hold" => PayoutOnHoldWebhookEventDataStatus.OnHold,
            "failed" => PayoutOnHoldWebhookEventDataStatus.Failed,
            "success" => PayoutOnHoldWebhookEventDataStatus.Success,
            _ => (PayoutOnHoldWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutOnHoldWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutOnHoldWebhookEventDataStatus.NotInitiated => "not_initiated",
                PayoutOnHoldWebhookEventDataStatus.InProgress => "in_progress",
                PayoutOnHoldWebhookEventDataStatus.OnHold => "on_hold",
                PayoutOnHoldWebhookEventDataStatus.Failed => "failed",
                PayoutOnHoldWebhookEventDataStatus.Success => "success",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
