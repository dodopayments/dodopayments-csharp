using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(CbbProrationBehaviorConverter))]
public enum CbbProrationBehavior
{
    Prorate,
    NoProrate,
}

sealed class CbbProrationBehaviorConverter : JsonConverter<CbbProrationBehavior>
{
    public override CbbProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorate" => CbbProrationBehavior.Prorate,
            "no_prorate" => CbbProrationBehavior.NoProrate,
            _ => (CbbProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CbbProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CbbProrationBehavior.Prorate => "prorate",
                CbbProrationBehavior.NoProrate => "no_prorate",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
