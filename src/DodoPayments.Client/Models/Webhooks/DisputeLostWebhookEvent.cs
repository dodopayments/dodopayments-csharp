using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<DisputeLostWebhookEvent, DisputeLostWebhookEventFromRaw>))]
public sealed record class DisputeLostWebhookEvent : ModelBase
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required DisputeLostWebhookEventData Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DisputeLostWebhookEventData>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'timestamp' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timestamp",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, DisputeLostWebhookEventType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DisputeLostWebhookEventType>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentNullException("type")
                );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public DisputeLostWebhookEvent() { }

    public DisputeLostWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeLostWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeLostWebhookEventFromRaw : IFromRaw<DisputeLostWebhookEvent>
{
    public DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeLostWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<DisputeLostWebhookEventData, DisputeLostWebhookEventDataFromRaw>)
)]
public sealed record class DisputeLostWebhookEventData : ModelBase
{
    /// <summary>
    /// The amount involved in the dispute, represented as a string to accommodate precision.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the business involved in the dispute.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the dispute was created, in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency of the disputed amount, represented as an ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the dispute.
    /// </summary>
    public required string DisputeID
    {
        get
        {
            if (!this._rawData.TryGetValue("dispute_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'dispute_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dispute_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'dispute_id' cannot be null",
                    new System::ArgumentNullException("dispute_id")
                );
        }
        init
        {
            this._rawData["dispute_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DisputeDisputeStage> DisputeStage
    {
        get
        {
            if (!this._rawData.TryGetValue("dispute_stage", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'dispute_stage' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dispute_stage",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStage>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'dispute_stage' cannot be null",
                    new System::ArgumentNullException("dispute_stage")
                );
        }
        init
        {
            this._rawData["dispute_stage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DisputeDisputeStatus> DisputeStatus
    {
        get
        {
            if (!this._rawData.TryGetValue("dispute_status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'dispute_status' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dispute_status",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStatus>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'dispute_status' cannot be null",
                    new System::ArgumentNullException("dispute_status")
                );
        }
        init
        {
            this._rawData["dispute_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the dispute.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "payment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new System::ArgumentNullException("payment_id")
                );
        }
        init
        {
            this._rawData["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Remarks
    /// </summary>
    public string? Remarks
    {
        get
        {
            if (!this._rawData.TryGetValue("remarks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["remarks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, DisputeLostWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            if (!this._rawData.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                DisputeLostWebhookEventDataIntersectionMember1PayloadType
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator Dispute(
        DisputeLostWebhookEventData disputeLostWebhookEventData
    ) =>
        new()
        {
            Amount = disputeLostWebhookEventData.Amount,
            BusinessID = disputeLostWebhookEventData.BusinessID,
            CreatedAt = disputeLostWebhookEventData.CreatedAt,
            Currency = disputeLostWebhookEventData.Currency,
            DisputeID = disputeLostWebhookEventData.DisputeID,
            DisputeStage = disputeLostWebhookEventData.DisputeStage,
            DisputeStatus = disputeLostWebhookEventData.DisputeStatus,
            PaymentID = disputeLostWebhookEventData.PaymentID,
            Remarks = disputeLostWebhookEventData.Remarks,
        };

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        _ = this.Remarks;
        this.PayloadType?.Validate();
    }

    public DisputeLostWebhookEventData() { }

    public DisputeLostWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeLostWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DisputeLostWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeLostWebhookEventDataFromRaw : IFromRaw<DisputeLostWebhookEventData>
{
    public DisputeLostWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeLostWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        DisputeLostWebhookEventDataIntersectionMember1,
        DisputeLostWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class DisputeLostWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, DisputeLostWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            if (!this._rawData.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                DisputeLostWebhookEventDataIntersectionMember1PayloadType
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public DisputeLostWebhookEventDataIntersectionMember1() { }

    public DisputeLostWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeLostWebhookEventDataIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DisputeLostWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeLostWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<DisputeLostWebhookEventDataIntersectionMember1>
{
    public DisputeLostWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeLostWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(DisputeLostWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum DisputeLostWebhookEventDataIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DisputeLostWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<DisputeLostWebhookEventDataIntersectionMember1PayloadType>
{
    public override DisputeLostWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DisputeLostWebhookEventDataIntersectionMember1PayloadType.Dispute,
            _ => (DisputeLostWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeLostWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeLostWebhookEventDataIntersectionMember1PayloadType.Dispute => "Dispute",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(DisputeLostWebhookEventTypeConverter))]
public enum DisputeLostWebhookEventType
{
    DisputeLost,
}

sealed class DisputeLostWebhookEventTypeConverter : JsonConverter<DisputeLostWebhookEventType>
{
    public override DisputeLostWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.lost" => DisputeLostWebhookEventType.DisputeLost,
            _ => (DisputeLostWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeLostWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeLostWebhookEventType.DisputeLost => "dispute.lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
