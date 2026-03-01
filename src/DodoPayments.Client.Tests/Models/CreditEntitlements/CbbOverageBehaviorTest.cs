using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CbbOverageBehaviorTest : TestBase
{
    [Theory]
    [InlineData(CbbOverageBehavior.ForgiveAtReset)]
    [InlineData(CbbOverageBehavior.InvoiceAtBilling)]
    [InlineData(CbbOverageBehavior.CarryDeficit)]
    [InlineData(CbbOverageBehavior.CarryDeficitAutoRepay)]
    public void Validation_Works(CbbOverageBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CbbOverageBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CbbOverageBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CbbOverageBehavior.ForgiveAtReset)]
    [InlineData(CbbOverageBehavior.InvoiceAtBilling)]
    [InlineData(CbbOverageBehavior.CarryDeficit)]
    [InlineData(CbbOverageBehavior.CarryDeficitAutoRepay)]
    public void SerializationRoundtrip_Works(CbbOverageBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CbbOverageBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CbbOverageBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CbbOverageBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CbbOverageBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
