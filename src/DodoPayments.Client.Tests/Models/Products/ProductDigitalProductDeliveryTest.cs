using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductDigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        List<DigitalProductDeliveryFile> expectedFiles =
        [
            new()
            {
                DownloadUrl = "download_url",
                ExpiresIn = 0,
                FileID = "file_id",
                Filename = "filename",
                ContentType = "content_type",
                FileSize = 0,
            },
        ];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDigitalProductDelivery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDigitalProductDelivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DigitalProductDeliveryFile> expectedFiles =
        [
            new()
            {
                DownloadUrl = "download_url",
                ExpiresIn = 0,
                FileID = "file_id",
                Filename = "filename",
                ContentType = "content_type",
                FileSize = 0,
            },
        ];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
        };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],

            ExternalUrl = null,
            Instructions = null,
        };

        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],

            ExternalUrl = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductDigitalProductDelivery
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        ProductDigitalProductDelivery copied = new(model);

        Assert.Equal(model, copied);
    }
}
