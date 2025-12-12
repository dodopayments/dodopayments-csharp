using System.Threading.Tasks;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Services;

public class MeterServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var meter = await this.client.Meters.Create(
            new()
            {
                Aggregation = new() { Type = Type.Count, Key = "key" },
                EventName = "event_name",
                MeasurementUnit = "measurement_unit",
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        meter.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var meter = await this.client.Meters.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        meter.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Meters.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        await this.client.Meters.Archive("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Unarchive_Works()
    {
        await this.client.Meters.Unarchive("id", new(), TestContext.Current.CancellationToken);
    }
}
