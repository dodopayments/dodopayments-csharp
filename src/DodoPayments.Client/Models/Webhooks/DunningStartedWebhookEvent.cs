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
    typeof(JsonModelConverter<DunningStartedWebhookEvent, DunningStartedWebhookEventFromRaw>)
)]
public sealed record class DunningStartedWebhookEvent : JsonModel
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
    public required DunningStartedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DunningStartedWebhookEventData>("data");
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
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("dunning.started"))
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public DunningStartedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("dunning.started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DunningStartedWebhookEvent(DunningStartedWebhookEvent dunningStartedWebhookEvent)
        : base(dunningStartedWebhookEvent) { }
#pragma warning restore CS8618

    public DunningStartedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("dunning.started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DunningStartedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static DunningStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DunningStartedWebhookEventFromRaw : IFromRawJson<DunningStartedWebhookEvent>
{
    /// <inheritdoc/>
    public DunningStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DunningStartedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Webhook payload for dunning.started and dunning.recovered events
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DunningStartedWebhookEventData,
        DunningStartedWebhookEventDataFromRaw
    >)
)]
public sealed record class DunningStartedWebhookEventData : JsonModel
{
    /// <summary>
    /// Brand id this dunning attempt belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

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

    public required ApiEnum<string, DunningStartedWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DunningStartedWebhookEventDataStatus>
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

    public required ApiEnum<string, DunningStartedWebhookEventDataTriggerState> TriggerState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DunningStartedWebhookEventDataTriggerState>
            >("trigger_state");
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
        _ = this.BrandID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.Status.Validate();
        _ = this.SubscriptionID;
        this.TriggerState.Validate();
        _ = this.PaymentID;
    }

    public DunningStartedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DunningStartedWebhookEventData(
        DunningStartedWebhookEventData dunningStartedWebhookEventData
    )
        : base(dunningStartedWebhookEventData) { }
#pragma warning restore CS8618

    public DunningStartedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DunningStartedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningStartedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static DunningStartedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DunningStartedWebhookEventDataFromRaw : IFromRawJson<DunningStartedWebhookEventData>
{
    /// <inheritdoc/>
    public DunningStartedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DunningStartedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DunningStartedWebhookEventDataStatusConverter))]
public enum DunningStartedWebhookEventDataStatus
{
    Recovering,
    Recovered,
    Exhausted,
}

sealed class DunningStartedWebhookEventDataStatusConverter
    : JsonConverter<DunningStartedWebhookEventDataStatus>
{
    public override DunningStartedWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recovering" => DunningStartedWebhookEventDataStatus.Recovering,
            "recovered" => DunningStartedWebhookEventDataStatus.Recovered,
            "exhausted" => DunningStartedWebhookEventDataStatus.Exhausted,
            _ => (DunningStartedWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DunningStartedWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DunningStartedWebhookEventDataStatus.Recovering => "recovering",
                DunningStartedWebhookEventDataStatus.Recovered => "recovered",
                DunningStartedWebhookEventDataStatus.Exhausted => "exhausted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DunningStartedWebhookEventDataTriggerStateConverter))]
public enum DunningStartedWebhookEventDataTriggerState
{
    OnHold,
    Cancelled,
}

sealed class DunningStartedWebhookEventDataTriggerStateConverter
    : JsonConverter<DunningStartedWebhookEventDataTriggerState>
{
    public override DunningStartedWebhookEventDataTriggerState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "on_hold" => DunningStartedWebhookEventDataTriggerState.OnHold,
            "cancelled" => DunningStartedWebhookEventDataTriggerState.Cancelled,
            _ => (DunningStartedWebhookEventDataTriggerState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DunningStartedWebhookEventDataTriggerState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DunningStartedWebhookEventDataTriggerState.OnHold => "on_hold",
                DunningStartedWebhookEventDataTriggerState.Cancelled => "cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
