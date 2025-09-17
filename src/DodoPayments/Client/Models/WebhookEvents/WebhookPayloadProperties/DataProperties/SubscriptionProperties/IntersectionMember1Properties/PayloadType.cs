using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties.IntersectionMember1Properties;

[JsonConverter(typeof(Client::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : Client::IEnum<PayloadType, string>
{
    public static readonly PayloadType Subscription = new("Subscription");

    readonly string _value = value;

    public enum Value
    {
        Subscription,
    }

    public Value Known() =>
        _value switch
        {
            "Subscription" => Value.Subscription,
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
