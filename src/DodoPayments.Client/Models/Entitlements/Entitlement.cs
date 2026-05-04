using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// Detailed view of a single entitlement: identity, integration type, integration-specific
/// configuration, and metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entitlement, EntitlementFromRaw>))]
public sealed record class Entitlement : JsonModel
{
    /// <summary>
    /// Unique identifier of the entitlement.
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
    /// Identifier of the business that owns this entitlement.
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
    /// Timestamp when the entitlement was created.
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
    /// Integration-specific configuration. For `digital_files` entitlements this
    /// includes presigned download URLs for each attached file.
    /// </summary>
    public required IntegrationConfigResponse IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationConfigResponse>("integration_config");
        }
        init { this._rawData.Set("integration_config", value); }
    }

    /// <summary>
    /// Platform integration this entitlement uses.
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
    /// Always `true` for entitlements returned by the public API; soft-deleted entitlements
    /// are not returned.
    /// </summary>
    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_active");
        }
        init { this._rawData.Set("is_active", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata supplied at creation or via PATCH.
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
    /// Display name supplied at creation.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Timestamp when the entitlement was last modified.
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
    /// Optional description supplied at creation.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.IntegrationConfig.Validate();
        this.IntegrationType.Validate();
        _ = this.IsActive;
        _ = this.Metadata;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
    }

    public Entitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entitlement(Entitlement entitlement)
        : base(entitlement) { }
#pragma warning restore CS8618

    public Entitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFromRaw.FromRawUnchecked"/>
    public static Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementFromRaw : IFromRawJson<Entitlement>
{
    /// <inheritdoc/>
    public Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entitlement.FromRawUnchecked(rawData);
}
