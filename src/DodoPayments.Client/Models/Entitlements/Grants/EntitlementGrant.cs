using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Models.Entitlements.Grants;

/// <summary>
/// Detailed view of a single entitlement grant: who it's for, its lifecycle state,
/// and any integration-specific delivery payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntitlementGrant, EntitlementGrantFromRaw>))]
public sealed record class EntitlementGrant : JsonModel
{
    /// <summary>
    /// Unique identifier of the grant.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Identifier of the business that owns the grant.
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
    /// Timestamp when the grant was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Identifier of the customer the grant was issued to.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// Identifier of the entitlement this grant was issued from.
    /// </summary>
    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_id");
        }
        init { this._rawData.Set("entitlement_id", value); }
    }

    /// <summary>
    /// The integration type of the grant's entitlement (e.g. `license_key`).
    /// </summary>
    public required ApiEnum<string, EntitlementIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementIntegrationType>>(
                "integration_type"
            );
        }
        init { this._rawData.Set("integration_type", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata recorded on the grant.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Lifecycle status of the grant.
    /// </summary>
    public required ApiEnum<string, EntitlementGrantStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementGrantStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp when the grant was last modified.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Timestamp when the grant transitioned to `delivered`, when applicable.
    /// </summary>
    public DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("delivered_at");
        }
        init { this._rawData.Set("delivered_at", value); }
    }

    /// <summary>
    /// Digital-product-delivery payload, present when the entitlement integration
    /// is `digital_files`.
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

    /// <summary>
    /// Machine-readable code reported when delivery failed, when applicable.
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// Human-readable message reported when delivery failed, when applicable.
    /// </summary>
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
    /// License-key delivery payload, present when the entitlement integration is `license_key`.
    /// </summary>
    public LicenseKeyGrant? LicenseKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LicenseKeyGrant>("license_key");
        }
        init { this._rawData.Set("license_key", value); }
    }

    /// <summary>
    /// Timestamp when `oauth_url` stops being valid, when applicable.
    /// </summary>
    public DateTimeOffset? OAuthExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("oauth_expires_at");
        }
        init { this._rawData.Set("oauth_expires_at", value); }
    }

    /// <summary>
    /// Customer-facing OAuth URL for OAuth-style integrations. Populated during
    /// the customer-portal accept flow; `null` until the customer completes that
    /// step, and on grants for non-OAuth integrations.
    /// </summary>
    public string? OAuthUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("oauth_url");
        }
        init { this._rawData.Set("oauth_url", value); }
    }

    /// <summary>
    /// Identifier of the payment that triggered this grant, when applicable.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Reason recorded when the grant was revoked, when applicable.
    /// </summary>
    public string? RevocationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("revocation_reason");
        }
        init { this._rawData.Set("revocation_reason", value); }
    }

    /// <summary>
    /// Timestamp when the grant transitioned to `revoked`, when applicable.
    /// </summary>
    public DateTimeOffset? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("revoked_at");
        }
        init { this._rawData.Set("revoked_at", value); }
    }

    /// <summary>
    /// Identifier of the subscription that triggered this grant, when applicable.
    /// </summary>
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
        this.IntegrationType.Validate();
        _ = this.Metadata;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.DeliveredAt;
        this.DigitalProductDelivery?.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        this.LicenseKey?.Validate();
        _ = this.OAuthExpiresAt;
        _ = this.OAuthUrl;
        _ = this.PaymentID;
        _ = this.RevocationReason;
        _ = this.RevokedAt;
        _ = this.SubscriptionID;
    }

    public EntitlementGrant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrant(EntitlementGrant entitlementGrant)
        : base(entitlementGrant) { }
#pragma warning restore CS8618

    public EntitlementGrant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFromRaw.FromRawUnchecked"/>
    public static EntitlementGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFromRaw : IFromRawJson<EntitlementGrant>
{
    /// <inheritdoc/>
    public EntitlementGrant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntitlementGrant.FromRawUnchecked(rawData);
}

/// <summary>
/// Lifecycle status of the grant.
/// </summary>
[JsonConverter(typeof(EntitlementGrantStatusConverter))]
public enum EntitlementGrantStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class EntitlementGrantStatusConverter : JsonConverter<EntitlementGrantStatus>
{
    public override EntitlementGrantStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => EntitlementGrantStatus.Pending,
            "Delivered" => EntitlementGrantStatus.Delivered,
            "Failed" => EntitlementGrantStatus.Failed,
            "Revoked" => EntitlementGrantStatus.Revoked,
            _ => (EntitlementGrantStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantStatus.Pending => "Pending",
                EntitlementGrantStatus.Delivered => "Delivered",
                EntitlementGrantStatus.Failed => "Failed",
                EntitlementGrantStatus.Revoked => "Revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
