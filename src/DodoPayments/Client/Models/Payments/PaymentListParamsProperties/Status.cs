using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Payments.PaymentListParamsProperties;

/// <summary>
/// Filter by status
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Client::IEnum<Status, string>
{
    public static readonly Status Succeeded = new("succeeded");

    public static readonly Status Failed = new("failed");

    public static readonly Status Cancelled = new("cancelled");

    public static readonly Status Processing = new("processing");

    public static readonly Status RequiresCustomerAction = new("requires_customer_action");

    public static readonly Status RequiresMerchantAction = new("requires_merchant_action");

    public static readonly Status RequiresPaymentMethod = new("requires_payment_method");

    public static readonly Status RequiresConfirmation = new("requires_confirmation");

    public static readonly Status RequiresCapture = new("requires_capture");

    public static readonly Status PartiallyCaptured = new("partially_captured");

    public static readonly Status PartiallyCapturedAndCapturable = new(
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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
