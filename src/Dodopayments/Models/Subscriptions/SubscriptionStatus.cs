using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Subscriptions;

[JsonConverter(typeof(Dodopayments::EnumConverter<SubscriptionStatus, string>))]
public sealed record class SubscriptionStatus(string value)
    : Dodopayments::IEnum<SubscriptionStatus, string>
{
    public static readonly SubscriptionStatus Pending = new("pending");

    public static readonly SubscriptionStatus Active = new("active");

    public static readonly SubscriptionStatus OnHold = new("on_hold");

    public static readonly SubscriptionStatus Cancelled = new("cancelled");

    public static readonly SubscriptionStatus Failed = new("failed");

    public static readonly SubscriptionStatus Expired = new("expired");

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

    public static SubscriptionStatus FromRaw(string value)
    {
        return new(value);
    }
}
