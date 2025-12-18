using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
            Iterator = "iterator",
            PrevIterator = "prev_iterator",
        };

        List<WebhookDetails> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UpdatedAt = "updated_at",
                URL = "url",
                Disabled = true,
                FilterTypes = ["string"],
                RateLimit = 0,
            },
        ];
        bool expectedDone = true;
        string expectedIterator = "iterator";
        string expectedPrevIterator = "prev_iterator";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedDone, model.Done);
        Assert.Equal(expectedIterator, model.Iterator);
        Assert.Equal(expectedPrevIterator, model.PrevIterator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
            Iterator = "iterator",
            PrevIterator = "prev_iterator",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
            Iterator = "iterator",
            PrevIterator = "prev_iterator",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<WebhookDetails> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UpdatedAt = "updated_at",
                URL = "url",
                Disabled = true,
                FilterTypes = ["string"],
                RateLimit = 0,
            },
        ];
        bool expectedDone = true;
        string expectedIterator = "iterator";
        string expectedPrevIterator = "prev_iterator";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedDone, deserialized.Done);
        Assert.Equal(expectedIterator, deserialized.Iterator);
        Assert.Equal(expectedPrevIterator, deserialized.PrevIterator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
            Iterator = "iterator",
            PrevIterator = "prev_iterator",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
        };

        Assert.Null(model.Iterator);
        Assert.False(model.RawData.ContainsKey("iterator"));
        Assert.Null(model.PrevIterator);
        Assert.False(model.RawData.ContainsKey("prev_iterator"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,

            Iterator = null,
            PrevIterator = null,
        };

        Assert.Null(model.Iterator);
        Assert.True(model.RawData.ContainsKey("iterator"));
        Assert.Null(model.PrevIterator);
        Assert.True(model.RawData.ContainsKey("prev_iterator"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    UpdatedAt = "updated_at",
                    URL = "url",
                    Disabled = true,
                    FilterTypes = ["string"],
                    RateLimit = 0,
                },
            ],
            Done = true,

            Iterator = null,
            PrevIterator = null,
        };

        model.Validate();
    }
}
