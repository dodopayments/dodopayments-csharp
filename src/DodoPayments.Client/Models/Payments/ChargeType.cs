using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

/// <summary>
/// The type of subscription charge that a payment is for.
///
/// <para>A payment has one invoice, and the invoice has one type. Thus each payment
/// has one charge type. A payment that charges no subscription has no charge type.</para>
///
/// <para>- `new`: the first payment of one or more subscriptions. A retry of that
/// payment   is also `new`. A cart with new subscriptions and one-time products
/// is `new`.   Read the one-time products from `product_cart`. - `renewal`: a charge
/// at the billing date. A dunning retry and a manual retry of   that charge are also
/// `renewal`. A `renewal` does not always extend the service   period. For example,
/// the usage settlement of a paused subscription is a `renewal`   with `includes_usage`
/// true and no entry in `service_periods`. Examine   `service_periods` before you
/// extend access. - `plan_change`: a charge for a plan change. The change applies
/// now or at the next billing date. - `on_demand`: an on-demand charge of an on-demand subscription.</para>
/// </summary>
[JsonConverter(typeof(ChargeTypeConverter))]
public enum ChargeType
{
    New,
    Renewal,
    PlanChange,
    OnDemand,
}

sealed class ChargeTypeConverter : JsonConverter<ChargeType>
{
    public override ChargeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "new" => ChargeType.New,
            "renewal" => ChargeType.Renewal,
            "plan_change" => ChargeType.PlanChange,
            "on_demand" => ChargeType.OnDemand,
            _ => (ChargeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeType.New => "new",
                ChargeType.Renewal => "renewal",
                ChargeType.PlanChange => "plan_change",
                ChargeType.OnDemand => "on_demand",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
