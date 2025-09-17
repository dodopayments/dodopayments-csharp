using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Disputes.DisputeListParamsProperties;

/// <summary>
/// Filter by dispute status
/// </summary>
[JsonConverter(typeof(Dodopayments::EnumConverter<DisputeStatus1, string>))]
public sealed record class DisputeStatus1(string value)
    : Dodopayments::IEnum<DisputeStatus1, string>
{
    public static readonly DisputeStatus1 DisputeOpened = new("dispute_opened");

    public static readonly DisputeStatus1 DisputeExpired = new("dispute_expired");

    public static readonly DisputeStatus1 DisputeAccepted = new("dispute_accepted");

    public static readonly DisputeStatus1 DisputeCancelled = new("dispute_cancelled");

    public static readonly DisputeStatus1 DisputeChallenged = new("dispute_challenged");

    public static readonly DisputeStatus1 DisputeWon = new("dispute_won");

    public static readonly DisputeStatus1 DisputeLost = new("dispute_lost");

    readonly string _value = value;

    public enum Value
    {
        DisputeOpened,
        DisputeExpired,
        DisputeAccepted,
        DisputeCancelled,
        DisputeChallenged,
        DisputeWon,
        DisputeLost,
    }

    public Value Known() =>
        _value switch
        {
            "dispute_opened" => Value.DisputeOpened,
            "dispute_expired" => Value.DisputeExpired,
            "dispute_accepted" => Value.DisputeAccepted,
            "dispute_cancelled" => Value.DisputeCancelled,
            "dispute_challenged" => Value.DisputeChallenged,
            "dispute_won" => Value.DisputeWon,
            "dispute_lost" => Value.DisputeLost,
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

    public static DisputeStatus1 FromRaw(string value)
    {
        return new(value);
    }
}
