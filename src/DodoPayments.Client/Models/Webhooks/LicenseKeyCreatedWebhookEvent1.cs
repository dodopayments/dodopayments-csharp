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
    typeof(JsonModelConverter<LicenseKeyCreatedWebhookEvent, LicenseKeyCreatedWebhookEventFromRaw1>)
)]
public sealed record class LicenseKeyCreatedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required Data6 Data
    {
        get { return JsonModel.GetNotNullClass<Data6>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, Type6> Type
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Type6>>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventFromRaw1 : IFromRawJson<LicenseKeyCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data6, Data6FromRaw>))]
public sealed record class Data6 : JsonModel
{
    /// <summary>
    /// The unique identifier of the license key.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the license key.
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key was created, in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The unique identifier of the customer associated with the license key.
    /// </summary>
    public required string CustomerID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { JsonModel.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// The current number of instances activated for this license key.
    /// </summary>
    public required int InstancesCount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "instances_count"); }
        init { JsonModel.Set(this._rawData, "instances_count", value); }
    }

    /// <summary>
    /// The license key string.
    /// </summary>
    public required string Key
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "key"); }
        init { JsonModel.Set(this._rawData, "key", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the license key.
    /// </summary>
    public required string PaymentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the product associated with the license key.
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    public required ApiEnum<string, LicenseKeyStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, LicenseKeyStatus>>(
                this.RawData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The maximum number of activations allowed for this license key.
    /// </summary>
    public int? ActivationsLimit
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "activations_limit"); }
        init { JsonModel.Set(this._rawData, "activations_limit", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key expires, in UTC.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expires_at");
        }
        init { JsonModel.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription associated with the license key,
    /// if any.
    /// </summary>
    public string? SubscriptionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { JsonModel.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data6IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Data6IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator LicenseKey(Data6 data6) =>
        new()
        {
            ID = data6.ID,
            BusinessID = data6.BusinessID,
            CreatedAt = data6.CreatedAt,
            CustomerID = data6.CustomerID,
            InstancesCount = data6.InstancesCount,
            Key = data6.Key,
            PaymentID = data6.PaymentID,
            ProductID = data6.ProductID,
            Status = data6.Status,
            ActivationsLimit = data6.ActivationsLimit,
            ExpiresAt = data6.ExpiresAt,
            SubscriptionID = data6.SubscriptionID,
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

    public Data6() { }

    public Data6(Data6 data6)
        : base(data6) { }

    public Data6(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data6(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data6FromRaw.FromRawUnchecked"/>
    public static Data6 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data6FromRaw : IFromRawJson<Data6>
{
    /// <inheritdoc/>
    public Data6 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data6.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<Data6IntersectionMember1, Data6IntersectionMember1FromRaw>)
)]
public sealed record class Data6IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data6IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Data6IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public Data6IntersectionMember1() { }

    public Data6IntersectionMember1(Data6IntersectionMember1 data6IntersectionMember1)
        : base(data6IntersectionMember1) { }

    public Data6IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data6IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data6IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static Data6IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data6IntersectionMember1FromRaw : IFromRawJson<Data6IntersectionMember1>
{
    /// <inheritdoc/>
    public Data6IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Data6IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(Data6IntersectionMember1PayloadTypeConverter))]
public enum Data6IntersectionMember1PayloadType
{
    LicenseKey,
}

sealed class Data6IntersectionMember1PayloadTypeConverter
    : JsonConverter<Data6IntersectionMember1PayloadType>
{
    public override Data6IntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LicenseKey" => Data6IntersectionMember1PayloadType.LicenseKey,
            _ => (Data6IntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Data6IntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Data6IntersectionMember1PayloadType.LicenseKey => "LicenseKey",
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
[JsonConverter(typeof(Type6Converter))]
public enum Type6
{
    LicenseKeyCreated,
}

sealed class Type6Converter : JsonConverter<Type6>
{
    public override Type6 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "license_key.created" => Type6.LicenseKeyCreated,
            _ => (Type6)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type6 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type6.LicenseKeyCreated => "license_key.created",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
