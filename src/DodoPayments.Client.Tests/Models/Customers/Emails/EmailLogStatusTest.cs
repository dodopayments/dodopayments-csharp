using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailLogStatusTest : TestBase
{
    [Theory]
    [InlineData(EmailLogStatus.Sent)]
    [InlineData(EmailLogStatus.Delivered)]
    [InlineData(EmailLogStatus.Failed)]
    [InlineData(EmailLogStatus.Complained)]
    [InlineData(EmailLogStatus.Blocked)]
    public void Validation_Works(EmailLogStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailLogStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailLogStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmailLogStatus.Sent)]
    [InlineData(EmailLogStatus.Delivered)]
    [InlineData(EmailLogStatus.Failed)]
    [InlineData(EmailLogStatus.Complained)]
    [InlineData(EmailLogStatus.Blocked)]
    public void SerializationRoundtrip_Works(EmailLogStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailLogStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailLogStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailLogStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailLogStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
