using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HeaderRetrieveResponse
        {
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Sensitive = ["string"],
        };

        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        List<string> expectedSensitive = ["string"];

        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedSensitive.Count, model.Sensitive.Count);
        for (int i = 0; i < expectedSensitive.Count; i++)
        {
            Assert.Equal(expectedSensitive[i], model.Sensitive[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HeaderRetrieveResponse
        {
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Sensitive = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HeaderRetrieveResponse
        {
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Sensitive = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        List<string> expectedSensitive = ["string"];

        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedSensitive.Count, deserialized.Sensitive.Count);
        for (int i = 0; i < expectedSensitive.Count; i++)
        {
            Assert.Equal(expectedSensitive[i], deserialized.Sensitive[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HeaderRetrieveResponse
        {
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Sensitive = ["string"],
        };

        model.Validate();
    }
}
