using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Services;

public class UsageEventServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var event_ = await this.client.UsageEvents.Retrieve(
            "event_id",
            new(),
            TestContext.Current.CancellationToken
        );
        event_.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.UsageEvents.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Ingest_Works()
    {
        var response = await this.client.UsageEvents.Ingest(
            new()
            {
                Events =
                [
                    new()
                    {
                        CustomerID = "customer_id",
                        EventID = "event_id",
                        EventName = "event_name",
                        Metadata = new Dictionary<string, EventInputMetadata>()
                        {
                            { "foo", "string" },
                        },
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
