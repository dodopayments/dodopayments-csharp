using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class IntentStatusTest : TestBase
{
    [Theory]
    [InlineData(IntentStatus.Succeeded)]
    [InlineData(IntentStatus.Failed)]
    [InlineData(IntentStatus.Cancelled)]
    [InlineData(IntentStatus.Processing)]
    [InlineData(IntentStatus.RequiresCustomerAction)]
    [InlineData(IntentStatus.RequiresMerchantAction)]
    [InlineData(IntentStatus.RequiresPaymentMethod)]
    [InlineData(IntentStatus.RequiresConfirmation)]
    [InlineData(IntentStatus.RequiresCapture)]
    [InlineData(IntentStatus.PartiallyCaptured)]
    [InlineData(IntentStatus.PartiallyCapturedAndCapturable)]
    public void Validation_Works(IntentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntentStatus.Succeeded)]
    [InlineData(IntentStatus.Failed)]
    [InlineData(IntentStatus.Cancelled)]
    [InlineData(IntentStatus.Processing)]
    [InlineData(IntentStatus.RequiresCustomerAction)]
    [InlineData(IntentStatus.RequiresMerchantAction)]
    [InlineData(IntentStatus.RequiresPaymentMethod)]
    [InlineData(IntentStatus.RequiresConfirmation)]
    [InlineData(IntentStatus.RequiresCapture)]
    [InlineData(IntentStatus.PartiallyCaptured)]
    [InlineData(IntentStatus.PartiallyCapturedAndCapturable)]
    public void SerializationRoundtrip_Works(IntentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
