using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Licenses;

[JsonConverter(typeof(ModelConverter<LicenseValidateResponse, LicenseValidateResponseFromRaw>))]
public sealed record class LicenseValidateResponse : ModelBase
{
    public required bool Valid
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "valid"); }
        init { ModelBase.Set(this._rawData, "valid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Valid;
    }

    public LicenseValidateResponse() { }

    public LicenseValidateResponse(LicenseValidateResponse licenseValidateResponse)
        : base(licenseValidateResponse) { }

    public LicenseValidateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseValidateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseValidateResponseFromRaw.FromRawUnchecked"/>
    public static LicenseValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LicenseValidateResponse(bool valid)
        : this()
    {
        this.Valid = valid;
    }
}

class LicenseValidateResponseFromRaw : IFromRaw<LicenseValidateResponse>
{
    /// <inheritdoc/>
    public LicenseValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseValidateResponse.FromRawUnchecked(rawData);
}
