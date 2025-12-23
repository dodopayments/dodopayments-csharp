using System.Text.Json;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShortLinkCreateResponse { FullURL = "full_url", ShortURL = "short_url" };

        string expectedFullURL = "full_url";
        string expectedShortURL = "short_url";

        Assert.Equal(expectedFullURL, model.FullURL);
        Assert.Equal(expectedShortURL, model.ShortURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShortLinkCreateResponse { FullURL = "full_url", ShortURL = "short_url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkCreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShortLinkCreateResponse { FullURL = "full_url", ShortURL = "short_url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShortLinkCreateResponse>(element);
        Assert.NotNull(deserialized);

        string expectedFullURL = "full_url";
        string expectedShortURL = "short_url";

        Assert.Equal(expectedFullURL, deserialized.FullURL);
        Assert.Equal(expectedShortURL, deserialized.ShortURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShortLinkCreateResponse { FullURL = "full_url", ShortURL = "short_url" };

        model.Validate();
    }
}
