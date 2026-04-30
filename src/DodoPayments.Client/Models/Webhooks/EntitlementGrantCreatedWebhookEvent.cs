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
        EntitlementGrantCreatedWebhookEvent,
        EntitlementGrantCreatedWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantCreatedWebhookEvent : JsonModel
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

    public required EntitlementGrantCreatedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementGrantCreatedWebhookEventData>("data");
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
    public required ApiEnum<string, EntitlementGrantCreatedWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantCreatedWebhookEventType>
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

    public EntitlementGrantCreatedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantCreatedWebhookEvent(
        EntitlementGrantCreatedWebhookEvent entitlementGrantCreatedWebhookEvent
    )
        : base(entitlementGrantCreatedWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantCreatedWebhookEventFromRaw : IFromRawJson<EntitlementGrantCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantCreatedWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantCreatedWebhookEventData,
        EntitlementGrantCreatedWebhookEventDataFromRaw
    >)
)]
public sealed record class EntitlementGrantCreatedWebhookEventData : JsonModel
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

    public required ApiEnum<string, EntitlementGrantCreatedWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantCreatedWebhookEventDataStatus>
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
    public LicenseKey? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LicenseKey>("license_key");
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

    public EntitlementGrantCreatedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantCreatedWebhookEventData(
        EntitlementGrantCreatedWebhookEventData entitlementGrantCreatedWebhookEventData
    )
        : base(entitlementGrantCreatedWebhookEventData) { }
#pragma warning restore CS8618

    public EntitlementGrantCreatedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantCreatedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantCreatedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantCreatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantCreatedWebhookEventDataFromRaw
    : IFromRawJson<EntitlementGrantCreatedWebhookEventData>
{
    /// <inheritdoc/>
    public EntitlementGrantCreatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantCreatedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementGrantCreatedWebhookEventDataStatusConverter))]
public enum EntitlementGrantCreatedWebhookEventDataStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class EntitlementGrantCreatedWebhookEventDataStatusConverter
    : JsonConverter<EntitlementGrantCreatedWebhookEventDataStatus>
{
    public override EntitlementGrantCreatedWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => EntitlementGrantCreatedWebhookEventDataStatus.Pending,
            "Delivered" => EntitlementGrantCreatedWebhookEventDataStatus.Delivered,
            "Failed" => EntitlementGrantCreatedWebhookEventDataStatus.Failed,
            "Revoked" => EntitlementGrantCreatedWebhookEventDataStatus.Revoked,
            _ => (EntitlementGrantCreatedWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantCreatedWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantCreatedWebhookEventDataStatus.Pending => "Pending",
                EntitlementGrantCreatedWebhookEventDataStatus.Delivered => "Delivered",
                EntitlementGrantCreatedWebhookEventDataStatus.Failed => "Failed",
                EntitlementGrantCreatedWebhookEventDataStatus.Revoked => "Revoked",
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
[JsonConverter(typeof(JsonModelConverter<LicenseKey, LicenseKeyFromRaw>))]
public sealed record class LicenseKey : JsonModel
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

    public LicenseKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKey(LicenseKey licenseKey)
        : base(licenseKey) { }
#pragma warning restore CS8618

    public LicenseKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyFromRaw.FromRawUnchecked"/>
    public static LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyFromRaw : IFromRawJson<LicenseKey>
{
    /// <inheritdoc/>
    public LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKey.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(EntitlementGrantCreatedWebhookEventTypeConverter))]
public enum EntitlementGrantCreatedWebhookEventType
{
    EntitlementGrantCreated,
}

sealed class EntitlementGrantCreatedWebhookEventTypeConverter
    : JsonConverter<EntitlementGrantCreatedWebhookEventType>
{
    public override EntitlementGrantCreatedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entitlement_grant.created" =>
                EntitlementGrantCreatedWebhookEventType.EntitlementGrantCreated,
            _ => (EntitlementGrantCreatedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantCreatedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantCreatedWebhookEventType.EntitlementGrantCreated =>
                    "entitlement_grant.created",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
