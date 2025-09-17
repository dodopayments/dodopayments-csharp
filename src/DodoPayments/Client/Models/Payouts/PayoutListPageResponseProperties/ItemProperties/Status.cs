using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Payouts.PayoutListPageResponseProperties.ItemProperties;

/// <summary>
/// The current status of the payout.
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Client::IEnum<Status, string>
{
    public static readonly Status NotInitiated = new("not_initiated");

    public static readonly Status InProgress = new("in_progress");

    public static readonly Status OnHold = new("on_hold");

    public static readonly Status Failed = new("failed");

    public static readonly Status Success = new("success");

    readonly string _value = value;

    public enum Value
    {
        NotInitiated,
        InProgress,
        OnHold,
        Failed,
        Success,
    }

    public Value Known() =>
        _value switch
        {
            "not_initiated" => Value.NotInitiated,
            "in_progress" => Value.InProgress,
            "on_hold" => Value.OnHold,
            "failed" => Value.Failed,
            "success" => Value.Success,
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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
