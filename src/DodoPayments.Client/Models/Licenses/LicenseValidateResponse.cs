using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Licenses;

[JsonConverter(typeof(ModelConverter<LicenseValidateResponse, LicenseValidateResponseFromRaw>))]
public sealed record class LicenseValidateResponse : ModelBase
{
    public required bool Valid
    {
        get
        {
            if (!this._rawData.TryGetValue("valid", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'valid' cannot be null",
                    new ArgumentOutOfRangeException("valid", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["valid"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Valid;
    }

    public LicenseValidateResponse() { }

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
    public LicenseValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseValidateResponse.FromRawUnchecked(rawData);
}
