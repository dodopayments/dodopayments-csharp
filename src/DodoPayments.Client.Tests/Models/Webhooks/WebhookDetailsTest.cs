using System.Collections.Generic;
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
            URL = "url",
            Disabled = true,
            FilterTypes = ["string"],
            RateLimit = 0,
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedUpdatedAt = "updated_at";
        string expectedURL = "url";
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
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedFilterTypes.Count, model.FilterTypes.Count);
        for (int i = 0; i < expectedFilterTypes.Count; i++)
        {
            Assert.Equal(expectedFilterTypes[i], model.FilterTypes[i]);
        }
        Assert.Equal(expectedRateLimit, model.RateLimit);
    }
}
