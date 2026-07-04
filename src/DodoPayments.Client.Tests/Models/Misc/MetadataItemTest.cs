using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Misc;

public class MetadataItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MetadataItem value = "string";
        value.Validate();
    }

    [Fact]
    public void NumberValidationWorks()
    {
        MetadataItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BooleanValidationWorks()
    {
        MetadataItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MetadataItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumberSerializationRoundtripWorks()
    {
        MetadataItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BooleanSerializationRoundtripWorks()
    {
        MetadataItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
