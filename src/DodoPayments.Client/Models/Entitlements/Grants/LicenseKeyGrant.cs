using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Models.Entitlements.Grants;

/// <summary>
/// License-key delivery payload, present on grants for `license_key` entitlements.
/// The grant's top-level `status` is the source of truth for the grant's lifecycle.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LicenseKeyGrant, LicenseKeyGrantFromRaw>))]
public sealed record class LicenseKeyGrant : JsonModel
{
    /// <summary>
    /// Identifier of the issued license key.
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
    /// Number of instances currently active. Activation increments it and deactivation
    /// decrements it, so it is a live count and not a total.
    /// </summary>
    public required int ActivationsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("activations_used");
        }
        init { this._rawData.Set("activations_used", value); }
    }

    /// <summary>
    /// Issued license key.
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Current status of the license key. Activation fails unless it is `active`,
    /// so a client can warn before the customer tries.
    /// </summary>
    public required ApiEnum<string, LicenseKeyStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LicenseKeyStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Maximum activations allowed by the entitlement, when set.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    /// <summary>
    /// When the license key expires, when applicable.
    /// </summary>
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
        _ = this.ID;
        _ = this.ActivationsUsed;
        _ = this.Key;
        this.Status.Validate();
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
    }

    public LicenseKeyGrant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKeyGrant(LicenseKeyGrant licenseKeyGrant)
        : base(licenseKeyGrant) { }
#pragma warning restore CS8618

    public LicenseKeyGrant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyGrant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyGrantFromRaw.FromRawUnchecked"/>
    public static LicenseKeyGrant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyGrantFromRaw : IFromRawJson<LicenseKeyGrant>
{
    /// <inheritdoc/>
    public LicenseKeyGrant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyGrant.FromRawUnchecked(rawData);
}
