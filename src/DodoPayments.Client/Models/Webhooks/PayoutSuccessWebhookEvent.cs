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
    typeof(JsonModelConverter<PayoutSuccessWebhookEvent, PayoutSuccessWebhookEventFromRaw>)
)]
public sealed record class PayoutSuccessWebhookEvent : JsonModel
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

    public required PayoutSuccessWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutSuccessWebhookEventData>("data");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("payout.success")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public PayoutSuccessWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("payout.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutSuccessWebhookEvent(PayoutSuccessWebhookEvent payoutSuccessWebhookEvent)
        : base(payoutSuccessWebhookEvent) { }
#pragma warning restore CS8618

    public PayoutSuccessWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payout.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutSuccessWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutSuccessWebhookEventFromRaw.FromRawUnchecked"/>
    public static PayoutSuccessWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutSuccessWebhookEventFromRaw : IFromRawJson<PayoutSuccessWebhookEvent>
{
    /// <inheritdoc/>
    public PayoutSuccessWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutSuccessWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PayoutSuccessWebhookEventData, PayoutSuccessWebhookEventDataFromRaw>)
)]
public sealed record class PayoutSuccessWebhookEventData : JsonModel
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
    public required ApiEnum<string, PayoutSuccessWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutSuccessWebhookEventDataStatus>
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
    public PayoutSuccessWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutSuccessWebhookEventData(
        PayoutSuccessWebhookEventData payoutSuccessWebhookEventData
    )
        : base(payoutSuccessWebhookEventData) { }
#pragma warning restore CS8618

    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    public PayoutSuccessWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: chargebacks, refunds, tax")]
    [SetsRequiredMembers]
    PayoutSuccessWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutSuccessWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PayoutSuccessWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutSuccessWebhookEventDataFromRaw : IFromRawJson<PayoutSuccessWebhookEventData>
{
    /// <inheritdoc/>
    public PayoutSuccessWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutSuccessWebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the payout.
/// </summary>
[JsonConverter(typeof(PayoutSuccessWebhookEventDataStatusConverter))]
public enum PayoutSuccessWebhookEventDataStatus
{
    NotInitiated,
    InProgress,
    OnHold,
    Failed,
    Success,
}

sealed class PayoutSuccessWebhookEventDataStatusConverter
    : JsonConverter<PayoutSuccessWebhookEventDataStatus>
{
    public override PayoutSuccessWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_initiated" => PayoutSuccessWebhookEventDataStatus.NotInitiated,
            "in_progress" => PayoutSuccessWebhookEventDataStatus.InProgress,
            "on_hold" => PayoutSuccessWebhookEventDataStatus.OnHold,
            "failed" => PayoutSuccessWebhookEventDataStatus.Failed,
            "success" => PayoutSuccessWebhookEventDataStatus.Success,
            _ => (PayoutSuccessWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutSuccessWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutSuccessWebhookEventDataStatus.NotInitiated => "not_initiated",
                PayoutSuccessWebhookEventDataStatus.InProgress => "in_progress",
                PayoutSuccessWebhookEventDataStatus.OnHold => "on_hold",
                PayoutSuccessWebhookEventDataStatus.Failed => "failed",
                PayoutSuccessWebhookEventDataStatus.Success => "success",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
