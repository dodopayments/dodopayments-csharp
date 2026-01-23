using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullUrl = "full_url",
            ProductID = "product_id",
            ShortUrl = "short_url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullUrl = "full_url";
        string expectedProductID = "product_id";
        string expectedShortUrl = "short_url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFullUrl, model.FullUrl);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullUrl = "full_url",
            ProductID = "product_id",
            ShortUrl = "short_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullUrl = "full_url",
            ProductID = "product_id",
            ShortUrl = "short_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullUrl = "full_url";
        string expectedProductID = "product_id";
        string expectedShortUrl = "short_url";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFullUrl, deserialized.FullUrl);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullUrl = "full_url",
            ProductID = "product_id",
            ShortUrl = "short_url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullUrl = "full_url",
            ProductID = "product_id",
            ShortUrl = "short_url",
        };

        ShortLinkListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
