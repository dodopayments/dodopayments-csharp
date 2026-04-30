using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Models.Entitlements.Grants;

[JsonConverter(typeof(JsonModelConverter<GrantListResponse, GrantListResponseFromRaw>))]
public sealed record class GrantListResponse : JsonModel
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

    public required ApiEnum<string, GrantListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GrantListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

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
    /// Present only when the entitlement integration_type is `digital_files`. Populated
    /// eagerly on every list and single-record endpoint.
    /// </summary>
    public Products::ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Products::ProductDigitalProductDelivery>(
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

    public DateTimeOffset? OAuthExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("oauth_expires_at");
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

    public DateTimeOffset? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("revoked_at");
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

    public GrantListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListResponse(GrantListResponse grantListResponse)
        : base(grantListResponse) { }
#pragma warning restore CS8618

    public GrantListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListResponseFromRaw.FromRawUnchecked"/>
    public static GrantListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantListResponseFromRaw : IFromRawJson<GrantListResponse>
{
    /// <inheritdoc/>
    public GrantListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GrantListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GrantListResponseStatusConverter))]
public enum GrantListResponseStatus
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class GrantListResponseStatusConverter : JsonConverter<GrantListResponseStatus>
{
    public override GrantListResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => GrantListResponseStatus.Pending,
            "Delivered" => GrantListResponseStatus.Delivered,
            "Failed" => GrantListResponseStatus.Failed,
            "Revoked" => GrantListResponseStatus.Revoked,
            _ => (GrantListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseStatus.Pending => "Pending",
                GrantListResponseStatus.Delivered => "Delivered",
                GrantListResponseStatus.Failed => "Failed",
                GrantListResponseStatus.Revoked => "Revoked",
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

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
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
