using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.PaymentProperties.IntersectionMember1Properties;

[JsonConverter(typeof(Dodopayments::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : Dodopayments::IEnum<PayloadType, string>
{
    public static readonly PayloadType Payment = new("Payment");

    readonly string _value = value;

    public enum Value
    {
        Payment,
    }

    public Value Known() =>
        _value switch
        {
            "Payment" => Value.Payment,
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
