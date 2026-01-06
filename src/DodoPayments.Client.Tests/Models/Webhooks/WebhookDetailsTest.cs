using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
            Disabled = true,
            FilterTypes = ["string"],
            RateLimit = 0,
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedUpdatedAt = "updated_at";
        string expectedUrl = "url";
        bool expectedDisabled = true;
        List<string> expectedFilterTypes = ["string"];
        int expectedRateLimit = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.NotNull(model.FilterTypes);
        Assert.Equal(expectedFilterTypes.Count, model.FilterTypes.Count);
        for (int i = 0; i < expectedFilterTypes.Count; i++)
        {
            Assert.Equal(expectedFilterTypes[i], model.FilterTypes[i]);
        }
        Assert.Equal(expectedRateLimit, model.RateLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
            Disabled = true,
            FilterTypes = ["string"],
            RateLimit = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookDetails>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
            Disabled = true,
            FilterTypes = ["string"],
            RateLimit = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookDetails>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedUpdatedAt = "updated_at";
        string expectedUrl = "url";
        bool expectedDisabled = true;
        List<string> expectedFilterTypes = ["string"];
        int expectedRateLimit = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.NotNull(deserialized.FilterTypes);
        Assert.Equal(expectedFilterTypes.Count, deserialized.FilterTypes.Count);
        for (int i = 0; i < expectedFilterTypes.Count; i++)
        {
            Assert.Equal(expectedFilterTypes[i], deserialized.FilterTypes[i]);
        }
        Assert.Equal(expectedRateLimit, deserialized.RateLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
            Disabled = true,
            FilterTypes = ["string"],
            RateLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
        };

        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.FilterTypes);
        Assert.False(model.RawData.ContainsKey("filter_types"));
        Assert.Null(model.RateLimit);
        Assert.False(model.RawData.ContainsKey("rate_limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",

            Disabled = null,
            FilterTypes = null,
            RateLimit = null,
        };

        Assert.Null(model.Disabled);
        Assert.True(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.FilterTypes);
        Assert.True(model.RawData.ContainsKey("filter_types"));
        Assert.Null(model.RateLimit);
        Assert.True(model.RawData.ContainsKey("rate_limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookDetails
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UpdatedAt = "updated_at",
            Url = "url",

            Disabled = null,
            FilterTypes = null,
            RateLimit = null,
        };

        model.Validate();
    }
}
