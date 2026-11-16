using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.AppInstallation;

/// <summary>
/// The settings of the App Installation of the app token, with the secret values.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AppInstallationRetrieveSettingsResponse,
        AppInstallationRetrieveSettingsResponseFromRaw
    >)
)]
public sealed record class AppInstallationRetrieveSettingsResponse : JsonModel
{
    /// <summary>
    /// `true` when a required field has no value, or a stored value fails a live rule.
    /// </summary>
    public required bool ActionNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("action_needed");
        }
        init { this._rawData.Set("action_needed", value); }
    }

    public required string AppID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("app_id");
        }
        init { this._rawData.Set("app_id", value); }
    }

    public required string InstallationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("installation_id");
        }
        init { this._rawData.Set("installation_id", value); }
    }

    /// <summary>
    /// The keys that need an action.
    /// </summary>
    public required IReadOnlyList<string> InvalidKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("invalid_keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "invalid_keys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The values of the secret fields of the live manifest, by key.
    /// </summary>
    public required JsonElement Secrets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("secrets");
        }
        init { this._rawData.Set("secrets", value); }
    }

    /// <summary>
    /// The values of the fields of the live manifest that are not secrets.
    /// </summary>
    public required JsonElement Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("values");
        }
        init { this._rawData.Set("values", value); }
    }

    /// <summary>
    /// The version of the live settings manifest. It is `null` when the app has
    /// no live manifest. Then `values` and `secrets` are empty.
    /// </summary>
    public int? LiveManifestVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("live_manifest_version");
        }
        init { this._rawData.Set("live_manifest_version", value); }
    }

    /// <summary>
    /// The manifest version of the last save. It is `null` when the installation
    /// has no settings.
    /// </summary>
    public int? ManifestVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("manifest_version");
        }
        init { this._rawData.Set("manifest_version", value); }
    }

    /// <summary>
    /// The time of the last save.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActionNeeded;
        _ = this.AppID;
        _ = this.InstallationID;
        _ = this.InvalidKeys;
        _ = this.Secrets;
        _ = this.Values;
        _ = this.LiveManifestVersion;
        _ = this.ManifestVersion;
        _ = this.UpdatedAt;
    }

    public AppInstallationRetrieveSettingsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AppInstallationRetrieveSettingsResponse(
        AppInstallationRetrieveSettingsResponse appInstallationRetrieveSettingsResponse
    )
        : base(appInstallationRetrieveSettingsResponse) { }
#pragma warning restore CS8618

    public AppInstallationRetrieveSettingsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppInstallationRetrieveSettingsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AppInstallationRetrieveSettingsResponseFromRaw.FromRawUnchecked"/>
    public static AppInstallationRetrieveSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AppInstallationRetrieveSettingsResponseFromRaw
    : IFromRawJson<AppInstallationRetrieveSettingsResponse>
{
    /// <inheritdoc/>
    public AppInstallationRetrieveSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AppInstallationRetrieveSettingsResponse.FromRawUnchecked(rawData);
}
