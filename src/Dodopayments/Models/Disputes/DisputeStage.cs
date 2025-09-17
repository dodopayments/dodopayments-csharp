using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Disputes;

[JsonConverter(typeof(Dodopayments::EnumConverter<DisputeStage, string>))]
public sealed record class DisputeStage(string value) : Dodopayments::IEnum<DisputeStage, string>
{
    public static readonly DisputeStage PreDispute = new("pre_dispute");

    public static readonly DisputeStage Dispute = new("dispute");

    public static readonly DisputeStage PreArbitration = new("pre_arbitration");

    readonly string _value = value;

    public enum Value
    {
        PreDispute,
        Dispute,
        PreArbitration,
    }

    public Value Known() =>
        _value switch
        {
            "pre_dispute" => Value.PreDispute,
            "dispute" => Value.Dispute,
            "pre_arbitration" => Value.PreArbitration,
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

    public static DisputeStage FromRaw(string value)
    {
        return new(value);
    }
}
