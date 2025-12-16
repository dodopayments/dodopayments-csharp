using System.Collections.Generic;
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
}
