using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.YourWebhookURL.YourWebhookURLCreateParamsProperties.DataProperties.LicenseKeyProperties.IntersectionMember1Properties;

[JsonConverter(typeof(DodoPayments::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : DodoPayments::IEnum<PayloadType, string>
{
    public static readonly PayloadType LicenseKey = new("LicenseKey");

    readonly string _value = value;

    public enum Value
    {
        LicenseKey,
    }

    public Value Known() =>
        _value switch
        {
            "LicenseKey" => Value.LicenseKey,
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

    public static PayloadType FromRaw(string value)
    {
        return new(value);
    }
}
