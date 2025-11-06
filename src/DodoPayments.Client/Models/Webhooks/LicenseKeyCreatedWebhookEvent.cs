using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<LicenseKeyCreatedWebhookEvent>))]
public sealed record class LicenseKeyCreatedWebhookEvent
    : ModelBase,
        IFromRaw<LicenseKeyCreatedWebhookEvent>
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
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
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required Data6 Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Data6>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTime Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'timestamp' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timestamp",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, Type6> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Type6>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
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

    public LicenseKeyCreatedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<Data6>))]
public sealed record class Data6 : ModelBase, IFromRaw<Data6>
{
    /// <summary>
    /// The unique identifier of the license key.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the business associated with the license key.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
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
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp indicating when the license key was created, in UTC.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the customer associated with the license key.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "customer_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new System::ArgumentNullException("customer_id")
                );
        }
        set
        {
            this.Properties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current number of instances activated for this license key.
    /// </summary>
    public required int InstancesCount
    {
        get
        {
            if (!this.Properties.TryGetValue("instances_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'instances_count' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "instances_count",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["instances_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The license key string.
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        set
        {
            this.Properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the license key.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
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
        set
        {
            this.Properties["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the product associated with the license key.
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentNullException("product_id")
                );
        }
        set
        {
            this.Properties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, LicenseKeyStatus> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, LicenseKeyStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of activations allowed for this license key.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            if (!this.Properties.TryGetValue("activations_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["activations_limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp indicating when the license key expires, in UTC.
    /// </summary>
    public System::DateTime? ExpiresAt
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the subscription associated with the license key,
    /// if any.
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subscription_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PayloadType6>? PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadType6>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data6(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data6 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<IntersectionMember16>))]
public sealed record class IntersectionMember16 : ModelBase, IFromRaw<IntersectionMember16>
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PayloadType6>? PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadType6>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public IntersectionMember16() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember16(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember16 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PayloadType6Converter))]
public enum PayloadType6
{
    LicenseKey,
}

sealed class PayloadType6Converter : JsonConverter<PayloadType6>
{
    public override PayloadType6 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LicenseKey" => PayloadType6.LicenseKey,
            _ => (PayloadType6)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadType6 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayloadType6.LicenseKey => "LicenseKey",
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
