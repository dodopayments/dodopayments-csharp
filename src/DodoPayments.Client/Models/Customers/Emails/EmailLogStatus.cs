using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers.Emails;

/// <summary>
/// The delivery status of one email.
///
/// <para>`sent` also covers an email that is still on its way. A status only becomes
/// `delivered`, `failed` or `complained` when the mail server answers.</para>
/// </summary>
[JsonConverter(typeof(EmailLogStatusConverter))]
public enum EmailLogStatus
{
    Sent,
    Delivered,
    Failed,
    Complained,
    Blocked,
}

sealed class EmailLogStatusConverter : JsonConverter<EmailLogStatus>
{
    public override EmailLogStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sent" => EmailLogStatus.Sent,
            "delivered" => EmailLogStatus.Delivered,
            "failed" => EmailLogStatus.Failed,
            "complained" => EmailLogStatus.Complained,
            "blocked" => EmailLogStatus.Blocked,
            _ => (EmailLogStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailLogStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmailLogStatus.Sent => "sent",
                EmailLogStatus.Delivered => "delivered",
                EmailLogStatus.Failed => "failed",
                EmailLogStatus.Complained => "complained",
                EmailLogStatus.Blocked => "blocked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
