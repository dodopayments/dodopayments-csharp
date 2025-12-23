using System;
using System.Text.Json;
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
            FullURL = "full_url",
            ProductID = "product_id",
            ShortURL = "short_url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullURL = "full_url";
        string expectedProductID = "product_id";
        string expectedShortURL = "short_url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFullURL, model.FullURL);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedShortURL, model.ShortURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullURL = "full_url",
            ProductID = "product_id",
            ShortURL = "short_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullURL = "full_url",
            ProductID = "product_id",
            ShortURL = "short_url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkListResponse>(element);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullURL = "full_url";
        string expectedProductID = "product_id";
        string expectedShortURL = "short_url";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFullURL, deserialized.FullURL);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedShortURL, deserialized.ShortURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShortLinkListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullURL = "full_url",
            ProductID = "product_id",
            ShortURL = "short_url",
        };

        model.Validate();
    }
}
