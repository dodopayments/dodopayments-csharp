using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(IntentStatusConverter))]
public enum IntentStatus
{
    Succeeded,
    Failed,
    Cancelled,
    Processing,
    RequiresCustomerAction,
    RequiresMerchantAction,
    RequiresPaymentMethod,
    RequiresConfirmation,
    RequiresCapture,
    PartiallyCaptured,
    PartiallyCapturedAndCapturable,
}

sealed class IntentStatusConverter : JsonConverter<IntentStatus>
{
    public override IntentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => IntentStatus.Succeeded,
            "failed" => IntentStatus.Failed,
            "cancelled" => IntentStatus.Cancelled,
            "processing" => IntentStatus.Processing,
            "requires_customer_action" => IntentStatus.RequiresCustomerAction,
            "requires_merchant_action" => IntentStatus.RequiresMerchantAction,
            "requires_payment_method" => IntentStatus.RequiresPaymentMethod,
            "requires_confirmation" => IntentStatus.RequiresConfirmation,
            "requires_capture" => IntentStatus.RequiresCapture,
            "partially_captured" => IntentStatus.PartiallyCaptured,
            "partially_captured_and_capturable" => IntentStatus.PartiallyCapturedAndCapturable,
            _ => (IntentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntentStatus.Succeeded => "succeeded",
                IntentStatus.Failed => "failed",
                IntentStatus.Cancelled => "cancelled",
                IntentStatus.Processing => "processing",
                IntentStatus.RequiresCustomerAction => "requires_customer_action",
                IntentStatus.RequiresMerchantAction => "requires_merchant_action",
                IntentStatus.RequiresPaymentMethod => "requires_payment_method",
                IntentStatus.RequiresConfirmation => "requires_confirmation",
                IntentStatus.RequiresCapture => "requires_capture",
                IntentStatus.PartiallyCaptured => "partially_captured",
                IntentStatus.PartiallyCapturedAndCapturable => "partially_captured_and_capturable",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
