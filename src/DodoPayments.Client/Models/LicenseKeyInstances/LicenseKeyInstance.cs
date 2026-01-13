using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

[JsonConverter(typeof(JsonModelConverter<LicenseKeyInstance, LicenseKeyInstanceFromRaw>))]
public sealed record class LicenseKeyInstance : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required string LicenseKeyID
    {
        get { return this._rawData.GetNotNullClass<string>("license_key_id"); }
        init { this._rawData.Set("license_key_id", value); }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.LicenseKeyID;
        _ = this.Name;
    }

    public LicenseKeyInstance() { }

    public LicenseKeyInstance(LicenseKeyInstance licenseKeyInstance)
        : base(licenseKeyInstance) { }

    public LicenseKeyInstance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyInstanceFromRaw.FromRawUnchecked"/>
    public static LicenseKeyInstance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyInstanceFromRaw : IFromRawJson<LicenseKeyInstance>
{
    /// <inheritdoc/>
    public LicenseKeyInstance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyInstance.FromRawUnchecked(rawData);
}
