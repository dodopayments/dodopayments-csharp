using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CreditEntitlements;

/// <summary>
/// Controls how overage is handled at the end of a billing cycle.
///
/// <para>| Preset                  | Charge at billing | Credits reduce overage
/// | Preserve overage at reset | |-------------------------|:-----------------:|:---------------------:|:-------------------------:|
/// | `forgive_at_reset`      | No                | No                    | No
///                     | | `invoice_at_billing`    | Yes               | No
///                | No                        | | `carry_deficit`         | No
///              | No                    | Yes                       | | `carry_deficit_auto_repay`
/// | No             | Yes                   | Yes                       |</para>
/// </summary>
[JsonConverter(typeof(CbbOverageBehaviorConverter))]
public enum CbbOverageBehavior
{
    ForgiveAtReset,
    InvoiceAtBilling,
    CarryDeficit,
    CarryDeficitAutoRepay,
}

sealed class CbbOverageBehaviorConverter : JsonConverter<CbbOverageBehavior>
{
    public override CbbOverageBehavior Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "forgive_at_reset" => CbbOverageBehavior.ForgiveAtReset,
            "invoice_at_billing" => CbbOverageBehavior.InvoiceAtBilling,
            "carry_deficit" => CbbOverageBehavior.CarryDeficit,
            "carry_deficit_auto_repay" => CbbOverageBehavior.CarryDeficitAutoRepay,
            _ => (CbbOverageBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CbbOverageBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CbbOverageBehavior.ForgiveAtReset => "forgive_at_reset",
                CbbOverageBehavior.InvoiceAtBilling => "invoice_at_billing",
                CbbOverageBehavior.CarryDeficit => "carry_deficit",
                CbbOverageBehavior.CarryDeficitAutoRepay => "carry_deficit_auto_repay",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
