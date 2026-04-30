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
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            ContentType = "content_type",
            FileSize = 0,
        };

        string expectedDownloadUrl = "download_url";
        long expectedExpiresIn = 0;
        string expectedFileID = "file_id";
        string expectedFilename = "filename";
        string expectedContentType = "content_type";
        long expectedFileSize = 0;

        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedFileSize, model.FileSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            ContentType = "content_type",
            FileSize = 0,
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
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            ContentType = "content_type",
            FileSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalProductDeliveryFile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadUrl = "download_url";
        long expectedExpiresIn = 0;
        string expectedFileID = "file_id";
        string expectedFilename = "filename";
        string expectedContentType = "content_type";
        long expectedFileSize = 0;

        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            ContentType = "content_type",
            FileSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
        };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",

            ContentType = null,
            FileSize = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.FileSize);
        Assert.True(model.RawData.ContainsKey("file_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",

            ContentType = null,
            FileSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalProductDeliveryFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            ContentType = "content_type",
            FileSize = 0,
        };

        DigitalProductDeliveryFile copied = new(model);

        Assert.Equal(model, copied);
    }
}
