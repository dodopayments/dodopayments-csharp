using System.Text.Json;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookRetrieveSecretResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveSecretResponse { Secret = "secret" };

        string expectedSecret = "secret";

        Assert.Equal(expectedSecret, model.Secret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookRetrieveSecretResponse { Secret = "secret" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveSecretResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRetrieveSecretResponse { Secret = "secret" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveSecretResponse>(element);
        Assert.NotNull(deserialized);

        string expectedSecret = "secret";

        Assert.Equal(expectedSecret, deserialized.Secret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookRetrieveSecretResponse { Secret = "secret" };

        model.Validate();
    }
}
