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
        EntitlementGrantRevokedWebhookEvent,
        EntitlementGrantRevokedWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantRevokedWebhookEvent : JsonModel
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

    public required EntitlementGrantRevokedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementGrantRevokedWebhookEventData>("data");
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
    public required ApiEnum<string, EntitlementGrantRevokedWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantRevokedWebhookEventType>
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

    public EntitlementGrantRevokedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantRevokedWebhookEvent(
        EntitlementGrantRevokedWebhookEvent entitlementGrantRevokedWebhookEvent
    )
        : base(entitlementGrantRevokedWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantRevokedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantRevokedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantRevokedWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantRevokedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantRevokedWebhookEventFromRaw : IFromRawJson<EntitlementGrantRevokedWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantRevokedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantRevokedWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantRevokedWebhookEventData,
        EntitlementGrantRevokedWebhookEventDataFromRaw
    >)
)]
public sealed record class EntitlementGrantRevokedWebhookEventData : JsonModel
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

    public required ApiEnum<string, EntitlementGrantRevokedWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantRevokedWebhookEventDataStatus>
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
    public EntitlementGrantRevokedWebhookEventDataLicenseKey? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementGrantRevokedWebhookEventDataLicenseKey>(
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

    public EntitlementGrantRevokedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantRevokedWebhookEventData(
        EntitlementGrantRevokedWebhookEventData entitlementGrantRevokedWebhookEventData
    )
        : base(entitlementGrantRevokedWebhookEventData) { }
#pragma warning restore CS8618

    public EntitlementGrantRevokedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantRevokedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantRevokedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantRevokedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantRevokedWebhookEventDataFromRaw
    : IFromRawJson<EntitlementGrantRevokedWebhookEventData>
{
    /// <inheritdoc/>
    public EntitlementGrantRevokedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantRevokedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementGrantRevokedWebhookEventDataStatusConverter))]
public enum EntitlementGrantRevokedWebhookEventDataStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class EntitlementGrantRevokedWebhookEventDataStatusConverter
    : JsonConverter<EntitlementGrantRevokedWebhookEventDataStatus>
{
    public override EntitlementGrantRevokedWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => EntitlementGrantRevokedWebhookEventDataStatus.Pending,
            "Delivered" => EntitlementGrantRevokedWebhookEventDataStatus.Delivered,
            "Failed" => EntitlementGrantRevokedWebhookEventDataStatus.Failed,
            "Revoked" => EntitlementGrantRevokedWebhookEventDataStatus.Revoked,
            _ => (EntitlementGrantRevokedWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantRevokedWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantRevokedWebhookEventDataStatus.Pending => "Pending",
                EntitlementGrantRevokedWebhookEventDataStatus.Delivered => "Delivered",
                EntitlementGrantRevokedWebhookEventDataStatus.Failed => "Failed",
                EntitlementGrantRevokedWebhookEventDataStatus.Revoked => "Revoked",
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
        EntitlementGrantRevokedWebhookEventDataLicenseKey,
        EntitlementGrantRevokedWebhookEventDataLicenseKeyFromRaw
    >)
)]
public sealed record class EntitlementGrantRevokedWebhookEventDataLicenseKey : JsonModel
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

    public EntitlementGrantRevokedWebhookEventDataLicenseKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantRevokedWebhookEventDataLicenseKey(
        EntitlementGrantRevokedWebhookEventDataLicenseKey entitlementGrantRevokedWebhookEventDataLicenseKey
    )
        : base(entitlementGrantRevokedWebhookEventDataLicenseKey) { }
#pragma warning restore CS8618

    public EntitlementGrantRevokedWebhookEventDataLicenseKey(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantRevokedWebhookEventDataLicenseKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantRevokedWebhookEventDataLicenseKeyFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantRevokedWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantRevokedWebhookEventDataLicenseKeyFromRaw
    : IFromRawJson<EntitlementGrantRevokedWebhookEventDataLicenseKey>
{
    /// <inheritdoc/>
    public EntitlementGrantRevokedWebhookEventDataLicenseKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantRevokedWebhookEventDataLicenseKey.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(EntitlementGrantRevokedWebhookEventTypeConverter))]
public enum EntitlementGrantRevokedWebhookEventType
{
    EntitlementGrantRevoked,
}

sealed class EntitlementGrantRevokedWebhookEventTypeConverter
    : JsonConverter<EntitlementGrantRevokedWebhookEventType>
{
    public override EntitlementGrantRevokedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entitlement_grant.revoked" =>
                EntitlementGrantRevokedWebhookEventType.EntitlementGrantRevoked,
            _ => (EntitlementGrantRevokedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantRevokedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantRevokedWebhookEventType.EntitlementGrantRevoked =>
                    "entitlement_grant.revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
