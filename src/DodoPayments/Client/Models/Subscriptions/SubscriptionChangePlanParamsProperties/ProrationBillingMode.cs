using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionChangePlanParamsProperties;

/// <summary>
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<ProrationBillingMode, string>))]
public sealed record class ProrationBillingMode(string value)
    : Client::IEnum<ProrationBillingMode, string>
{
    public static readonly ProrationBillingMode ProratedImmediately = new("prorated_immediately");

    public static readonly ProrationBillingMode FullImmediately = new("full_immediately");

    public static readonly ProrationBillingMode DifferenceImmediately = new(
        "difference_immediately"
    );

    readonly string _value = value;

    public enum Value
    {
        ProratedImmediately,
        FullImmediately,
        DifferenceImmediately,
    }

    public Value Known() =>
        _value switch
        {
            "prorated_immediately" => Value.ProratedImmediately,
            "full_immediately" => Value.FullImmediately,
            "difference_immediately" => Value.DifferenceImmediately,
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

    public static ProrationBillingMode FromRaw(string value)
    {
        return new(value);
    }
}
