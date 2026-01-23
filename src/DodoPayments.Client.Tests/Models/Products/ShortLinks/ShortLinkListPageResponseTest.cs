using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShortLinkListPageResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FullUrl = "full_url",
                    ProductID = "product_id",
                    ShortUrl = "short_url",
                },
            ],
        };

        List<ShortLinkListResponse> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FullUrl = "full_url",
                ProductID = "product_id",
                ShortUrl = "short_url",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShortLinkListPageResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FullUrl = "full_url",
                    ProductID = "product_id",
                    ShortUrl = "short_url",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShortLinkListPageResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FullUrl = "full_url",
                    ProductID = "product_id",
                    ShortUrl = "short_url",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ShortLinkListResponse> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FullUrl = "full_url",
                ProductID = "product_id",
                ShortUrl = "short_url",
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShortLinkListPageResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FullUrl = "full_url",
                    ProductID = "product_id",
                    ShortUrl = "short_url",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ShortLinkListPageResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FullUrl = "full_url",
                    ProductID = "product_id",
                    ShortUrl = "short_url",
                },
            ],
        };

        ShortLinkListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
