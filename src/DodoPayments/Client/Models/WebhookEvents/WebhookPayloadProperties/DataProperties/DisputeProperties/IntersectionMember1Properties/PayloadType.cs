using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.DisputeProperties.IntersectionMember1Properties;

[JsonConverter(typeof(Client::EnumConverter<PayloadType, string>))]
public sealed record class PayloadType(string value) : Client::IEnum<PayloadType, string>
{
    public static readonly PayloadType Dispute = new("Dispute");

    readonly string _value = value;

    public enum Value
    {
        Dispute,
    }

    public Value Known() =>
        _value switch
        {
            "Dispute" => Value.Dispute,
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
