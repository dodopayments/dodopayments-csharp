using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements.Grants;

/// <summary>
/// Nested representation of license-key grant fields. Present only when the grant's
/// entitlement has `integration_type = 'license_key'` and a row exists in `license_keys`.
/// The grant's top-level `status` is the source of truth for the grant's lifecycle
/// — no per-license-key status is exposed here.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LicenseKeyGrant, LicenseKeyGrantFromRaw>))]
public sealed record class LicenseKeyGrant : JsonModel
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
