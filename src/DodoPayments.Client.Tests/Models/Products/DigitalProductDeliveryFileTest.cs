using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class DigitalProductDeliveryFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalProductDeliveryFile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalProductDeliveryFile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        DigitalProductDeliveryFile copied = new(model);

        Assert.Equal(model, copied);
    }
}
