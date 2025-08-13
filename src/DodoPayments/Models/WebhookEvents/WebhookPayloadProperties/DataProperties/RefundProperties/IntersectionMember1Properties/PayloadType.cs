using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.RefundProperties.IntersectionMember1Properties;

[JsonConverter(typeof(DodoPayments::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : DodoPayments::IEnum<PayloadType, string>
{
    public static readonly PayloadType Refund = new("Refund");

    readonly string _value = value;

    public enum Value
    {
        Refund,
    }

    public Value Known() =>
        _value switch
        {
            "Refund" => Value.Refund,
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
