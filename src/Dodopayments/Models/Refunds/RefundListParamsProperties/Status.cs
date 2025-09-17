using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Refunds.RefundListParamsProperties;

/// <summary>
/// Filter by status
/// </summary>
[JsonConverter(typeof(Dodopayments::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Dodopayments::IEnum<Status, string>
{
    public static readonly Status Succeeded = new("succeeded");

    public static readonly Status Failed = new("failed");

    public static readonly Status Pending = new("pending");

    public static readonly Status Review = new("review");

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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
