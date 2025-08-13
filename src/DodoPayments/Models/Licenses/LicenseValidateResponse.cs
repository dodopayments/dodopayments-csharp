using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Licenses;

[JsonConverter(typeof(DodoPayments::ModelConverter<LicenseValidateResponse>))]
public sealed record class LicenseValidateResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<LicenseValidateResponse>
{
    public required bool Valid
    {
        get
        {
            if (!this.Properties.TryGetValue("valid", out JsonElement element))
                throw new ArgumentOutOfRangeException("valid", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["valid"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Valid;
    }

    public LicenseValidateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseValidateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseValidateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public LicenseValidateResponse(bool valid)
        : this()
    {
        this.Valid = valid;
    }
}
