using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(ModelConverter<LicenseKeyCreatedWebhookEvent, LicenseKeyCreatedWebhookEventFromRaw>)
)]
public sealed record class LicenseKeyCreatedWebhookEvent : ModelBase
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required LicenseKeyCreatedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<LicenseKeyCreatedWebhookEventData>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, LicenseKeyCreatedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, LicenseKeyCreatedWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public LicenseKeyCreatedWebhookEvent() { }

    public LicenseKeyCreatedWebhookEvent(
        LicenseKeyCreatedWebhookEvent licenseKeyCreatedWebhookEvent
    )
        : base(licenseKeyCreatedWebhookEvent) { }

    public LicenseKeyCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventFromRaw : IFromRaw<LicenseKeyCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        LicenseKeyCreatedWebhookEventData,
        LicenseKeyCreatedWebhookEventDataFromRaw
    >)
)]
public sealed record class LicenseKeyCreatedWebhookEventData : ModelBase
{
    /// <summary>
    /// The unique identifier of the license key.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the license key.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key was created, in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The unique identifier of the customer associated with the license key.
    /// </summary>
    public required string CustomerID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { ModelBase.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// The current number of instances activated for this license key.
    /// </summary>
    public required int InstancesCount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "instances_count"); }
        init { ModelBase.Set(this._rawData, "instances_count", value); }
    }

    /// <summary>
    /// The license key string.
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the license key.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the product associated with the license key.
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    public required ApiEnum<string, LicenseKeyStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, LicenseKeyStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The maximum number of activations allowed for this license key.
    /// </summary>
    public int? ActivationsLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "activations_limit"); }
        init { ModelBase.Set(this._rawData, "activations_limit", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key expires, in UTC.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expires_at");
        }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription associated with the license key,
    /// if any.
    /// </summary>
    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { ModelBase.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator LicenseKey(
        LicenseKeyCreatedWebhookEventData licenseKeyCreatedWebhookEventData
    ) =>
        new()
        {
            ID = licenseKeyCreatedWebhookEventData.ID,
            BusinessID = licenseKeyCreatedWebhookEventData.BusinessID,
            CreatedAt = licenseKeyCreatedWebhookEventData.CreatedAt,
            CustomerID = licenseKeyCreatedWebhookEventData.CustomerID,
            InstancesCount = licenseKeyCreatedWebhookEventData.InstancesCount,
            Key = licenseKeyCreatedWebhookEventData.Key,
            PaymentID = licenseKeyCreatedWebhookEventData.PaymentID,
            ProductID = licenseKeyCreatedWebhookEventData.ProductID,
            Status = licenseKeyCreatedWebhookEventData.Status,
            ActivationsLimit = licenseKeyCreatedWebhookEventData.ActivationsLimit,
            ExpiresAt = licenseKeyCreatedWebhookEventData.ExpiresAt,
            SubscriptionID = licenseKeyCreatedWebhookEventData.SubscriptionID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.InstancesCount;
        _ = this.Key;
        _ = this.PaymentID;
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
        _ = this.SubscriptionID;
        this.PayloadType?.Validate();
    }

    public LicenseKeyCreatedWebhookEventData() { }

    public LicenseKeyCreatedWebhookEventData(
        LicenseKeyCreatedWebhookEventData licenseKeyCreatedWebhookEventData
    )
        : base(licenseKeyCreatedWebhookEventData) { }

    public LicenseKeyCreatedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventDataFromRaw : IFromRaw<LicenseKeyCreatedWebhookEventData>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        LicenseKeyCreatedWebhookEventDataIntersectionMember1,
        LicenseKeyCreatedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class LicenseKeyCreatedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public LicenseKeyCreatedWebhookEventDataIntersectionMember1() { }

    public LicenseKeyCreatedWebhookEventDataIntersectionMember1(
        LicenseKeyCreatedWebhookEventDataIntersectionMember1 licenseKeyCreatedWebhookEventDataIntersectionMember1
    )
        : base(licenseKeyCreatedWebhookEventDataIntersectionMember1) { }

    public LicenseKeyCreatedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<LicenseKeyCreatedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
{
    LicenseKey,
}

sealed class LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType>
{
    public override LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LicenseKey" =>
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
            _ => (LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey =>
                    "LicenseKey",
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
[JsonConverter(typeof(LicenseKeyCreatedWebhookEventTypeConverter))]
public enum LicenseKeyCreatedWebhookEventType
{
    LicenseKeyCreated,
}

sealed class LicenseKeyCreatedWebhookEventTypeConverter
    : JsonConverter<LicenseKeyCreatedWebhookEventType>
{
    public override LicenseKeyCreatedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "license_key.created" => LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
            _ => (LicenseKeyCreatedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseKeyCreatedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseKeyCreatedWebhookEventType.LicenseKeyCreated => "license_key.created",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
