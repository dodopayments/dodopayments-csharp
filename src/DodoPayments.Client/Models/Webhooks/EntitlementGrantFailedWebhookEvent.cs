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
        EntitlementGrantFailedWebhookEvent,
        EntitlementGrantFailedWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantFailedWebhookEvent : JsonModel
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

    public required EntitlementGrantFailedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementGrantFailedWebhookEventData>("data");
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
    public required ApiEnum<string, EntitlementGrantFailedWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantFailedWebhookEventType>
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

    public EntitlementGrantFailedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantFailedWebhookEvent(
        EntitlementGrantFailedWebhookEvent entitlementGrantFailedWebhookEvent
    )
        : base(entitlementGrantFailedWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantFailedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantFailedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFailedWebhookEventFromRaw : IFromRawJson<EntitlementGrantFailedWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantFailedWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantFailedWebhookEventData,
        EntitlementGrantFailedWebhookEventDataFromRaw
    >)
)]
public sealed record class EntitlementGrantFailedWebhookEventData : JsonModel
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

    public required ApiEnum<string, EntitlementGrantFailedWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantFailedWebhookEventDataStatus>
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
    public EntitlementGrantFailedWebhookEventDataLicenseKey? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementGrantFailedWebhookEventDataLicenseKey>(
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

    public EntitlementGrantFailedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantFailedWebhookEventData(
        EntitlementGrantFailedWebhookEventData entitlementGrantFailedWebhookEventData
    )
        : base(entitlementGrantFailedWebhookEventData) { }
#pragma warning restore CS8618

    public EntitlementGrantFailedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantFailedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFailedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFailedWebhookEventDataFromRaw
    : IFromRawJson<EntitlementGrantFailedWebhookEventData>
{
    /// <inheritdoc/>
    public EntitlementGrantFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantFailedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementGrantFailedWebhookEventDataStatusConverter))]
public enum EntitlementGrantFailedWebhookEventDataStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class EntitlementGrantFailedWebhookEventDataStatusConverter
    : JsonConverter<EntitlementGrantFailedWebhookEventDataStatus>
{
    public override EntitlementGrantFailedWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => EntitlementGrantFailedWebhookEventDataStatus.Pending,
            "Delivered" => EntitlementGrantFailedWebhookEventDataStatus.Delivered,
            "Failed" => EntitlementGrantFailedWebhookEventDataStatus.Failed,
            "Revoked" => EntitlementGrantFailedWebhookEventDataStatus.Revoked,
            _ => (EntitlementGrantFailedWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantFailedWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantFailedWebhookEventDataStatus.Pending => "Pending",
                EntitlementGrantFailedWebhookEventDataStatus.Delivered => "Delivered",
                EntitlementGrantFailedWebhookEventDataStatus.Failed => "Failed",
                EntitlementGrantFailedWebhookEventDataStatus.Revoked => "Revoked",
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
        EntitlementGrantFailedWebhookEventDataLicenseKey,
        EntitlementGrantFailedWebhookEventDataLicenseKeyFromRaw
    >)
)]
public sealed record class EntitlementGrantFailedWebhookEventDataLicenseKey : JsonModel
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

    public EntitlementGrantFailedWebhookEventDataLicenseKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantFailedWebhookEventDataLicenseKey(
        EntitlementGrantFailedWebhookEventDataLicenseKey entitlementGrantFailedWebhookEventDataLicenseKey
    )
        : base(entitlementGrantFailedWebhookEventDataLicenseKey) { }
#pragma warning restore CS8618

    public EntitlementGrantFailedWebhookEventDataLicenseKey(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantFailedWebhookEventDataLicenseKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFailedWebhookEventDataLicenseKeyFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantFailedWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFailedWebhookEventDataLicenseKeyFromRaw
    : IFromRawJson<EntitlementGrantFailedWebhookEventDataLicenseKey>
{
    /// <inheritdoc/>
    public EntitlementGrantFailedWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantFailedWebhookEventDataLicenseKey.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(EntitlementGrantFailedWebhookEventTypeConverter))]
public enum EntitlementGrantFailedWebhookEventType
{
    EntitlementGrantFailed,
}

sealed class EntitlementGrantFailedWebhookEventTypeConverter
    : JsonConverter<EntitlementGrantFailedWebhookEventType>
{
    public override EntitlementGrantFailedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entitlement_grant.failed" =>
                EntitlementGrantFailedWebhookEventType.EntitlementGrantFailed,
            _ => (EntitlementGrantFailedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantFailedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantFailedWebhookEventType.EntitlementGrantFailed =>
                    "entitlement_grant.failed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
