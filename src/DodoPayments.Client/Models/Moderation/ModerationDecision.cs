using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// The verdict. `allow` means the content passed. `deny` means block the content.
/// `flag` means apply your own judgement. It is not a soft deny.
/// </summary>
[JsonConverter(typeof(ModerationDecisionConverter))]
public enum ModerationDecision
{
    Allow,
    Flag,
    Deny,
}

sealed class ModerationDecisionConverter : JsonConverter<ModerationDecision>
{
    public override ModerationDecision Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => ModerationDecision.Allow,
            "flag" => ModerationDecision.Flag,
            "deny" => ModerationDecision.Deny,
            _ => (ModerationDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModerationDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModerationDecision.Allow => "allow",
                ModerationDecision.Flag => "flag",
                ModerationDecision.Deny => "deny",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
