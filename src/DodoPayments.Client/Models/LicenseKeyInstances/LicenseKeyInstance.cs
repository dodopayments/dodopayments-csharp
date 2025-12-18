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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required string LicenseKeyID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "license_key_id"); }
        init { JsonModel.Set(this._rawData, "license_key_id", value); }
    }

    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
