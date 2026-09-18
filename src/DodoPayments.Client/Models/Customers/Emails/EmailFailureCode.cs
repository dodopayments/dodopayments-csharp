using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers.Emails;

/// <summary>
/// Why an email did not reach the recipient.
///
/// <para>The code is stable. `send_failed` is the catch-all: it covers every failure
/// that the other codes do not name.</para>
/// </summary>
[JsonConverter(typeof(EmailFailureCodeConverter))]
public enum EmailFailureCode
{
    MailboxNotFound,
    AddressRejected,
    AddressSuppressed,
    MailboxFull,
    TemporaryFailure,
    MessageTooLarge,
    MarkedAsSpam,
    SendFailed,
    TestModeQuotaSpent,
}

sealed class EmailFailureCodeConverter : JsonConverter<EmailFailureCode>
{
    public override EmailFailureCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mailbox_not_found" => EmailFailureCode.MailboxNotFound,
            "address_rejected" => EmailFailureCode.AddressRejected,
            "address_suppressed" => EmailFailureCode.AddressSuppressed,
            "mailbox_full" => EmailFailureCode.MailboxFull,
            "temporary_failure" => EmailFailureCode.TemporaryFailure,
            "message_too_large" => EmailFailureCode.MessageTooLarge,
            "marked_as_spam" => EmailFailureCode.MarkedAsSpam,
            "send_failed" => EmailFailureCode.SendFailed,
            "test_mode_quota_spent" => EmailFailureCode.TestModeQuotaSpent,
            _ => (EmailFailureCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailFailureCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmailFailureCode.MailboxNotFound => "mailbox_not_found",
                EmailFailureCode.AddressRejected => "address_rejected",
                EmailFailureCode.AddressSuppressed => "address_suppressed",
                EmailFailureCode.MailboxFull => "mailbox_full",
                EmailFailureCode.TemporaryFailure => "temporary_failure",
                EmailFailureCode.MessageTooLarge => "message_too_large",
                EmailFailureCode.MarkedAsSpam => "marked_as_spam",
                EmailFailureCode.SendFailed => "send_failed",
                EmailFailureCode.TestModeQuotaSpent => "test_mode_quota_spent",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
