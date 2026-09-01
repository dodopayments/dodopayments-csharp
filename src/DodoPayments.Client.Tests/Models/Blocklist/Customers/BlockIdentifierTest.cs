using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class BlockIdentifierTest : TestBase
{
    [Fact]
    public void ByCustomerIDValidationWorks()
    {
        BlockIdentifier value = new BlockByCustomerID("customer_id");
        value.Validate();
    }

    [Fact]
    public void ByEmailValidationWorks()
    {
        BlockIdentifier value = new BlockByEmail("email");
        value.Validate();
    }

    [Fact]
    public void ByCustomerIDSerializationRoundtripWorks()
    {
        BlockIdentifier value = new BlockByCustomerID("customer_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockIdentifier>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ByEmailSerializationRoundtripWorks()
    {
        BlockIdentifier value = new BlockByEmail("email");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockIdentifier>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
