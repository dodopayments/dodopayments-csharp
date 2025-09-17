using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(Client::EnumConverter<DisputeStatus, string>))]
public sealed record class DisputeStatus(string value) : Client::IEnum<DisputeStatus, string>
{
    public static readonly DisputeStatus DisputeOpened = new("dispute_opened");

    public static readonly DisputeStatus DisputeExpired = new("dispute_expired");

    public static readonly DisputeStatus DisputeAccepted = new("dispute_accepted");

    public static readonly DisputeStatus DisputeCancelled = new("dispute_cancelled");

    public static readonly DisputeStatus DisputeChallenged = new("dispute_challenged");

    public static readonly DisputeStatus DisputeWon = new("dispute_won");

    public static readonly DisputeStatus DisputeLost = new("dispute_lost");

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

    public static DisputeStatus FromRaw(string value)
    {
        return new(value);
    }
}
