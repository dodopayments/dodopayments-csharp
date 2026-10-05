using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundNetworkReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(RefundNetworkReferenceType.AcquirerReferenceNumber)]
    [InlineData(RefundNetworkReferenceType.SystemTraceAuditNumber)]
    [InlineData(RefundNetworkReferenceType.RetrievalReferenceNumber)]
    [InlineData(RefundNetworkReferenceType.Other)]
    public void Validation_Works(RefundNetworkReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundNetworkReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundNetworkReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefundNetworkReferenceType.AcquirerReferenceNumber)]
    [InlineData(RefundNetworkReferenceType.SystemTraceAuditNumber)]
    [InlineData(RefundNetworkReferenceType.RetrievalReferenceNumber)]
    [InlineData(RefundNetworkReferenceType.Other)]
    public void SerializationRoundtrip_Works(RefundNetworkReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundNetworkReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefundNetworkReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundNetworkReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefundNetworkReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
