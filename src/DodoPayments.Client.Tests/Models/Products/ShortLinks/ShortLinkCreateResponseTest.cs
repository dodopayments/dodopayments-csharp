using System.Text.Json;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShortLinkCreateResponse { FullUrl = "full_url", ShortUrl = "short_url" };

        string expectedFullUrl = "full_url";
        string expectedShortUrl = "short_url";

        Assert.Equal(expectedFullUrl, model.FullUrl);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShortLinkCreateResponse { FullUrl = "full_url", ShortUrl = "short_url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkCreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShortLinkCreateResponse { FullUrl = "full_url", ShortUrl = "short_url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkCreateResponse>(element);
        Assert.NotNull(deserialized);

        string expectedFullUrl = "full_url";
        string expectedShortUrl = "short_url";

        Assert.Equal(expectedFullUrl, deserialized.FullUrl);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShortLinkCreateResponse { FullUrl = "full_url", ShortUrl = "short_url" };

        model.Validate();
    }
}
