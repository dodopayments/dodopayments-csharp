using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(Client::EnumConverter<RefundStatus, string>))]
public sealed record class RefundStatus(string value) : Client::IEnum<RefundStatus, string>
{
    public static readonly RefundStatus Succeeded = new("succeeded");

    public static readonly RefundStatus Failed = new("failed");

    public static readonly RefundStatus Pending = new("pending");

    public static readonly RefundStatus Review = new("review");

    readonly string _value = value;

    public enum Value
    {
        Succeeded,
        Failed,
        Pending,
        Review,
    }

    public Value Known() =>
        _value switch
        {
            "succeeded" => Value.Succeeded,
            "failed" => Value.Failed,
            "pending" => Value.Pending,
            "review" => Value.Review,
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

    public static RefundStatus FromRaw(string value)
    {
        return new(value);
    }
}
