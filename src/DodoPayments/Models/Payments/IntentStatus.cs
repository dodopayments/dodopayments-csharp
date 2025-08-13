using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Payments;

[JsonConverter(typeof(DodoPayments::EnumConverter<IntentStatus, string>))]
public sealed record class IntentStatus(string value) : DodoPayments::IEnum<IntentStatus, string>
{
    public static readonly IntentStatus Succeeded = new("succeeded");

    public static readonly IntentStatus Failed = new("failed");

    public static readonly IntentStatus Cancelled = new("cancelled");

    public static readonly IntentStatus Processing = new("processing");

    public static readonly IntentStatus RequiresCustomerAction = new("requires_customer_action");

    public static readonly IntentStatus RequiresMerchantAction = new("requires_merchant_action");

    public static readonly IntentStatus RequiresPaymentMethod = new("requires_payment_method");

    public static readonly IntentStatus RequiresConfirmation = new("requires_confirmation");

    public static readonly IntentStatus RequiresCapture = new("requires_capture");

    public static readonly IntentStatus PartiallyCaptured = new("partially_captured");

    public static readonly IntentStatus PartiallyCapturedAndCapturable = new(
        "partially_captured_and_capturable"
    );

    readonly string _value = value;

    public enum Value
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

    public Value Known() =>
        _value switch
        {
            "succeeded" => Value.Succeeded,
            "failed" => Value.Failed,
            "cancelled" => Value.Cancelled,
            "processing" => Value.Processing,
            "requires_customer_action" => Value.RequiresCustomerAction,
            "requires_merchant_action" => Value.RequiresMerchantAction,
            "requires_payment_method" => Value.RequiresPaymentMethod,
            "requires_confirmation" => Value.RequiresConfirmation,
            "requires_capture" => Value.RequiresCapture,
            "partially_captured" => Value.PartiallyCaptured,
            "partially_captured_and_capturable" => Value.PartiallyCapturedAndCapturable,
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

    public static IntentStatus FromRaw(string value)
    {
        return new(value);
    }
}
