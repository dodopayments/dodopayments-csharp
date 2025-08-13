using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Subscriptions.SubscriptionListParamsProperties;

/// <summary>
/// Filter by status
/// </summary>
[JsonConverter(typeof(DodoPayments::EnumConverter<Status, string>))]
public sealed record class Status(string value) : DodoPayments::IEnum<Status, string>
{
    public static readonly Status Pending = new("pending");

    public static readonly Status Active = new("active");

    public static readonly Status OnHold = new("on_hold");

    public static readonly Status Cancelled = new("cancelled");

    public static readonly Status Failed = new("failed");

    public static readonly Status Expired = new("expired");

    readonly string _value = value;

    public enum Value
    {
        Pending,
        Active,
        OnHold,
        Cancelled,
        Failed,
        Expired,
    }

    public Value Known() =>
        _value switch
        {
            "pending" => Value.Pending,
            "active" => Value.Active,
            "on_hold" => Value.OnHold,
            "cancelled" => Value.Cancelled,
            "failed" => Value.Failed,
            "expired" => Value.Expired,
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
