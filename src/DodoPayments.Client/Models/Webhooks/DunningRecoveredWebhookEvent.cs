using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<DunningRecoveredWebhookEvent, DunningRecoveredWebhookEventFromRaw>)
)]
public sealed record class DunningRecoveredWebhookEvent : JsonModel
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

    /// <summary>
    /// Webhook payload for dunning.started and dunning.recovered events
    /// </summary>
    public required DunningRecoveredWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DunningRecoveredWebhookEventData>("data");
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("dunning.recovered")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public DunningRecoveredWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("dunning.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DunningRecoveredWebhookEvent(DunningRecoveredWebhookEvent dunningRecoveredWebhookEvent)
        : base(dunningRecoveredWebhookEvent) { }
#pragma warning restore CS8618

    public DunningRecoveredWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("dunning.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DunningRecoveredWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningRecoveredWebhookEventFromRaw.FromRawUnchecked"/>
    public static DunningRecoveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DunningRecoveredWebhookEventFromRaw : IFromRawJson<DunningRecoveredWebhookEvent>
{
    /// <inheritdoc/>
    public DunningRecoveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DunningRecoveredWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Webhook payload for dunning.started and dunning.recovered events
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DunningRecoveredWebhookEventData,
        DunningRecoveredWebhookEventDataFromRaw
    >)
)]
public sealed record class DunningRecoveredWebhookEventData : JsonModel
{
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required ApiEnum<string, DunningRecoveredWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DunningRecoveredWebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public required ApiEnum<string, TriggerState> TriggerState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TriggerState>>("trigger_state");
        }
        init { this._rawData.Set("trigger_state", value); }
    }

    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.Status.Validate();
        _ = this.SubscriptionID;
        this.TriggerState.Validate();
        _ = this.PaymentID;
    }

    public DunningRecoveredWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DunningRecoveredWebhookEventData(
        DunningRecoveredWebhookEventData dunningRecoveredWebhookEventData
    )
        : base(dunningRecoveredWebhookEventData) { }
#pragma warning restore CS8618

    public DunningRecoveredWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DunningRecoveredWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningRecoveredWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static DunningRecoveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DunningRecoveredWebhookEventDataFromRaw : IFromRawJson<DunningRecoveredWebhookEventData>
{
    /// <inheritdoc/>
    public DunningRecoveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DunningRecoveredWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DunningRecoveredWebhookEventDataStatusConverter))]
public enum DunningRecoveredWebhookEventDataStatus
{
    Recovering,
    Recovered,
    Exhausted,
}

sealed class DunningRecoveredWebhookEventDataStatusConverter
    : JsonConverter<DunningRecoveredWebhookEventDataStatus>
{
    public override DunningRecoveredWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recovering" => DunningRecoveredWebhookEventDataStatus.Recovering,
            "recovered" => DunningRecoveredWebhookEventDataStatus.Recovered,
            "exhausted" => DunningRecoveredWebhookEventDataStatus.Exhausted,
            _ => (DunningRecoveredWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DunningRecoveredWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DunningRecoveredWebhookEventDataStatus.Recovering => "recovering",
                DunningRecoveredWebhookEventDataStatus.Recovered => "recovered",
                DunningRecoveredWebhookEventDataStatus.Exhausted => "exhausted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TriggerStateConverter))]
public enum TriggerState
{
    OnHold,
    Cancelled,
}

sealed class TriggerStateConverter : JsonConverter<TriggerState>
{
    public override TriggerState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "on_hold" => TriggerState.OnHold,
            "cancelled" => TriggerState.Cancelled,
            _ => (TriggerState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TriggerState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TriggerState.OnHold => "on_hold",
                TriggerState.Cancelled => "cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
