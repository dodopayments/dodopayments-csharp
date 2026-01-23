using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<LicenseKeyDuration, LicenseKeyDurationFromRaw>))]
public sealed record class LicenseKeyDuration : JsonModel
{
    public required int Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required ApiEnum<string, TimeInterval> Interval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TimeInterval>>("interval");
        }
        init { this._rawData.Set("interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        this.Interval.Validate();
    }

    public LicenseKeyDuration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKeyDuration(LicenseKeyDuration licenseKeyDuration)
        : base(licenseKeyDuration) { }
#pragma warning restore CS8618

    public LicenseKeyDuration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyDuration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyDurationFromRaw.FromRawUnchecked"/>
    public static LicenseKeyDuration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyDurationFromRaw : IFromRawJson<LicenseKeyDuration>
{
    /// <inheritdoc/>
    public LicenseKeyDuration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyDuration.FromRawUnchecked(rawData);
}
