using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailFailureCodeTest : TestBase
{
    [Theory]
    [InlineData(EmailFailureCode.MailboxNotFound)]
    [InlineData(EmailFailureCode.AddressRejected)]
    [InlineData(EmailFailureCode.AddressSuppressed)]
    [InlineData(EmailFailureCode.MailboxFull)]
    [InlineData(EmailFailureCode.TemporaryFailure)]
    [InlineData(EmailFailureCode.MessageTooLarge)]
    [InlineData(EmailFailureCode.MarkedAsSpam)]
    [InlineData(EmailFailureCode.SendFailed)]
    [InlineData(EmailFailureCode.TestModeQuotaSpent)]
    public void Validation_Works(EmailFailureCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailFailureCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailFailureCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmailFailureCode.MailboxNotFound)]
    [InlineData(EmailFailureCode.AddressRejected)]
    [InlineData(EmailFailureCode.AddressSuppressed)]
    [InlineData(EmailFailureCode.MailboxFull)]
    [InlineData(EmailFailureCode.TemporaryFailure)]
    [InlineData(EmailFailureCode.MessageTooLarge)]
    [InlineData(EmailFailureCode.MarkedAsSpam)]
    [InlineData(EmailFailureCode.SendFailed)]
    [InlineData(EmailFailureCode.TestModeQuotaSpent)]
    public void SerializationRoundtrip_Works(EmailFailureCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailFailureCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailFailureCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailFailureCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailFailureCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
