using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Tests.Models.Entitlements.Files;

public class FileUploadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileUploadResponse { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileUploadResponse { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUploadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileUploadResponse { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUploadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, deserialized.FileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileUploadResponse { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileUploadResponse { FileID = "file_id" };

        FileUploadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
