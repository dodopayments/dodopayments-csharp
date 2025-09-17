using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.LicenseKeyProperties.IntersectionMember1Properties;

[JsonConverter(typeof(Dodopayments::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : Dodopayments::IEnum<PayloadType, string>
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
