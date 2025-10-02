using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionChangePlanParamsProperties;

/// <summary>
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(ProrationBillingModeConverter))]
public enum ProrationBillingMode
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
}

sealed class ProrationBillingModeConverter : JsonConverter<ProrationBillingMode>
{
    public override ProrationBillingMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" => ProrationBillingMode.ProratedImmediately,
            "full_immediately" => ProrationBillingMode.FullImmediately,
            "difference_immediately" => ProrationBillingMode.DifferenceImmediately,
            _ => (ProrationBillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBillingMode.ProratedImmediately => "prorated_immediately",
                ProrationBillingMode.FullImmediately => "full_immediately",
                ProrationBillingMode.DifferenceImmediately => "difference_immediately",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
