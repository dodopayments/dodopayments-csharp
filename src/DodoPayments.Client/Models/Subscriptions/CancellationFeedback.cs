using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(CancellationFeedbackConverter))]
public enum CancellationFeedback
{
    TooExpensive,
    MissingFeatures,
    SwitchedService,
    Unused,
    CustomerService,
    LowQuality,
    TooComplex,
    Other,
}

sealed class CancellationFeedbackConverter : JsonConverter<CancellationFeedback>
{
    public override CancellationFeedback Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "too_expensive" => CancellationFeedback.TooExpensive,
            "missing_features" => CancellationFeedback.MissingFeatures,
            "switched_service" => CancellationFeedback.SwitchedService,
            "unused" => CancellationFeedback.Unused,
            "customer_service" => CancellationFeedback.CustomerService,
            "low_quality" => CancellationFeedback.LowQuality,
            "too_complex" => CancellationFeedback.TooComplex,
            "other" => CancellationFeedback.Other,
            _ => (CancellationFeedback)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationFeedback value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationFeedback.TooExpensive => "too_expensive",
                CancellationFeedback.MissingFeatures => "missing_features",
                CancellationFeedback.SwitchedService => "switched_service",
                CancellationFeedback.Unused => "unused",
                CancellationFeedback.CustomerService => "customer_service",
                CancellationFeedback.LowQuality => "low_quality",
                CancellationFeedback.TooComplex => "too_complex",
                CancellationFeedback.Other => "other",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
