using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.LicenseKeys.LicenseKeyListParamsProperties;

/// <summary>
/// Filter by license key status
/// </summary>
[JsonConverter(typeof(DodoPayments::EnumConverter<Status, string>))]
public sealed record class Status(string value) : DodoPayments::IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status Expired = new("expired");

    public static readonly Status Disabled = new("disabled");

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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
