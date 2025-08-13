using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Disputes.DisputeListParamsProperties;

/// <summary>
/// Filter by dispute stage
/// </summary>
[JsonConverter(typeof(DodoPayments::EnumConverter<DisputeStage1, string>))]
public sealed record class DisputeStage1(string value) : DodoPayments::IEnum<DisputeStage1, string>
{
    public static readonly DisputeStage1 PreDispute = new("pre_dispute");

    public static readonly DisputeStage1 Dispute = new("dispute");

    public static readonly DisputeStage1 PreArbitration = new("pre_arbitration");

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

    public static DisputeStage1 FromRaw(string value)
    {
        return new(value);
    }
}
