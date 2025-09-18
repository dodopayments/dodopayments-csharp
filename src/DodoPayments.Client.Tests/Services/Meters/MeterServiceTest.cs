using System.Threading.Tasks;
using DodoPayments.Client.Models.Meters.MeterAggregationProperties;

namespace DodoPayments.Client.Tests.Services.Meters;

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
            }
        );
        meter.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var meter = await this.client.Meters.Retrieve(new() { ID = "id" });
        meter.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Meters.List();
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        await this.client.Meters.Archive(new() { ID = "id" });
    }

    [Fact]
    public async Task Unarchive_Works()
    {
        await this.client.Meters.Unarchive(new() { ID = "id" });
    }
}
