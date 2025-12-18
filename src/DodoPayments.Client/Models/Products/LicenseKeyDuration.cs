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
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "count"); }
        init { JsonModel.Set(this._rawData, "count", value); }
    }

    public required ApiEnum<string, TimeInterval> Interval
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                this.RawData,
                "interval"
            );
        }
        init { JsonModel.Set(this._rawData, "interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        this.Interval.Validate();
    }

    public LicenseKeyDuration() { }

    public LicenseKeyDuration(LicenseKeyDuration licenseKeyDuration)
        : base(licenseKeyDuration) { }

    public LicenseKeyDuration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyDuration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
