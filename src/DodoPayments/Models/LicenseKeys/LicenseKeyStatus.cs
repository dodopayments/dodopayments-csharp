using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.LicenseKeys;

[JsonConverter(typeof(DodoPayments::EnumConverter<LicenseKeyStatus, string>))]
public sealed record class LicenseKeyStatus(string value)
    : DodoPayments::IEnum<LicenseKeyStatus, string>
{
    public static readonly LicenseKeyStatus Active = new("active");

    public static readonly LicenseKeyStatus Expired = new("expired");

    public static readonly LicenseKeyStatus Disabled = new("disabled");

    readonly string _value = value;

    public enum Value
    {
        Active,
        Expired,
        Disabled,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "expired" => Value.Expired,
            "disabled" => Value.Disabled,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static LicenseKeyStatus FromRaw(string value)
    {
        return new(value);
    }
}
