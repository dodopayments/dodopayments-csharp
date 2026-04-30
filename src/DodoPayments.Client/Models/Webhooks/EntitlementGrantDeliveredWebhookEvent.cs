using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantDeliveredWebhookEvent,
        EntitlementGrantDeliveredWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantDeliveredWebhookEvent : JsonModel
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

    public required EntitlementGrantDeliveredWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementGrantDeliveredWebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, EntitlementGrantDeliveredWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantDeliveredWebhookEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public EntitlementGrantDeliveredWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantDeliveredWebhookEvent(
        EntitlementGrantDeliveredWebhookEvent entitlementGrantDeliveredWebhookEvent
    )
        : base(entitlementGrantDeliveredWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantDeliveredWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantDeliveredWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantDeliveredWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantDeliveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantDeliveredWebhookEventFromRaw
    : IFromRawJson<EntitlementGrantDeliveredWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantDeliveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantDeliveredWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantDeliveredWebhookEventData,
        EntitlementGrantDeliveredWebhookEventDataFromRaw
    >)
)]
public sealed record class EntitlementGrantDeliveredWebhookEventData : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
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

    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_id");
        }
        init { this._rawData.Set("entitlement_id", value); }
    }

    public required string ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    public required ApiEnum<string, EntitlementGrantDeliveredWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantDeliveredWebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public System::DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("delivered_at");
        }
        init { this._rawData.Set("delivered_at", value); }
    }

    /// <summary>
    /// Present only when the entitlement integration_type is `digital_files`. Populated
    /// eagerly on every list and single-record endpoint.
    /// </summary>
    public ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init { this._rawData.Set("digital_product_delivery", value); }
    }

    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Present only when the entitlement integration_type is `license_key`.
    /// </summary>
    public EntitlementGrantDeliveredWebhookEventDataLicenseKey? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementGrantDeliveredWebhookEventDataLicenseKey>(
                "license_key"
            );
        }
        init { this._rawData.Set("license_key", value); }
    }

    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    public System::DateTimeOffset? OAuthExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("oauth_expires_at");
        }
        init { this._rawData.Set("oauth_expires_at", value); }
    }

    public string? OAuthUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("oauth_url");
        }
        init { this._rawData.Set("oauth_url", value); }
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

    public string? RevocationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("revocation_reason");
        }
        init { this._rawData.Set("revocation_reason", value); }
    }

    public System::DateTimeOffset? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("revoked_at");
        }
        init { this._rawData.Set("revoked_at", value); }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.EntitlementID;
        _ = this.ExternalID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.DeliveredAt;
        this.DigitalProductDelivery?.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        this.LicenseKey?.Validate();
        _ = this.Metadata;
        _ = this.OAuthExpiresAt;
        _ = this.OAuthUrl;
        _ = this.PaymentID;
        _ = this.RevocationReason;
        _ = this.RevokedAt;
        _ = this.SubscriptionID;
    }

    public EntitlementGrantDeliveredWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantDeliveredWebhookEventData(
        EntitlementGrantDeliveredWebhookEventData entitlementGrantDeliveredWebhookEventData
    )
        : base(entitlementGrantDeliveredWebhookEventData) { }
#pragma warning restore CS8618

    public EntitlementGrantDeliveredWebhookEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantDeliveredWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantDeliveredWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantDeliveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantDeliveredWebhookEventDataFromRaw
    : IFromRawJson<EntitlementGrantDeliveredWebhookEventData>
{
    /// <inheritdoc/>
    public EntitlementGrantDeliveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantDeliveredWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementGrantDeliveredWebhookEventDataStatusConverter))]
public enum EntitlementGrantDeliveredWebhookEventDataStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class EntitlementGrantDeliveredWebhookEventDataStatusConverter
    : JsonConverter<EntitlementGrantDeliveredWebhookEventDataStatus>
{
    public override EntitlementGrantDeliveredWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => EntitlementGrantDeliveredWebhookEventDataStatus.Pending,
            "Delivered" => EntitlementGrantDeliveredWebhookEventDataStatus.Delivered,
            "Failed" => EntitlementGrantDeliveredWebhookEventDataStatus.Failed,
            "Revoked" => EntitlementGrantDeliveredWebhookEventDataStatus.Revoked,
            _ => (EntitlementGrantDeliveredWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantDeliveredWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantDeliveredWebhookEventDataStatus.Pending => "Pending",
                EntitlementGrantDeliveredWebhookEventDataStatus.Delivered => "Delivered",
                EntitlementGrantDeliveredWebhookEventDataStatus.Failed => "Failed",
                EntitlementGrantDeliveredWebhookEventDataStatus.Revoked => "Revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Present only when the entitlement integration_type is `license_key`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantDeliveredWebhookEventDataLicenseKey,
        EntitlementGrantDeliveredWebhookEventDataLicenseKeyFromRaw
    >)
)]
public sealed record class EntitlementGrantDeliveredWebhookEventDataLicenseKey : JsonModel
{
    public required int ActivationsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("activations_used");
        }
        init { this._rawData.Set("activations_used", value); }
    }

    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActivationsUsed;
        _ = this.Key;
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
    }

    public EntitlementGrantDeliveredWebhookEventDataLicenseKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantDeliveredWebhookEventDataLicenseKey(
        EntitlementGrantDeliveredWebhookEventDataLicenseKey entitlementGrantDeliveredWebhookEventDataLicenseKey
    )
        : base(entitlementGrantDeliveredWebhookEventDataLicenseKey) { }
#pragma warning restore CS8618

    public EntitlementGrantDeliveredWebhookEventDataLicenseKey(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantDeliveredWebhookEventDataLicenseKey(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantDeliveredWebhookEventDataLicenseKeyFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantDeliveredWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantDeliveredWebhookEventDataLicenseKeyFromRaw
    : IFromRawJson<EntitlementGrantDeliveredWebhookEventDataLicenseKey>
{
    /// <inheritdoc/>
    public EntitlementGrantDeliveredWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantDeliveredWebhookEventDataLicenseKey.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(EntitlementGrantDeliveredWebhookEventTypeConverter))]
public enum EntitlementGrantDeliveredWebhookEventType
{
    EntitlementGrantDelivered,
}

sealed class EntitlementGrantDeliveredWebhookEventTypeConverter
    : JsonConverter<EntitlementGrantDeliveredWebhookEventType>
{
    public override EntitlementGrantDeliveredWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entitlement_grant.delivered" =>
                EntitlementGrantDeliveredWebhookEventType.EntitlementGrantDelivered,
            _ => (EntitlementGrantDeliveredWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantDeliveredWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantDeliveredWebhookEventType.EntitlementGrantDelivered =>
                    "entitlement_grant.delivered",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
