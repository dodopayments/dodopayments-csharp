using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodoPayments.Client.Models.UsageEvents.EventInputProperties.MetadataProperties;

namespace DodoPayments.Client.Tests.Services.UsageEvents;

public class UsageEventServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var event1 = await this.client.UsageEvents.Retrieve(new() { EventID = "event_id" });
        event1.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.UsageEvents.List();
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
                        Metadata = new Dictionary<string, Metadata>() { { "foo", new("string") } },
                        Timestamp = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            }
        );
        response.Validate();
    }
}
