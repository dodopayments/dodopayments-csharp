using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class DisputeServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var getDispute = await this.client.Disputes.Retrieve(
            "dispute_id",
            new(),
            TestContext.Current.CancellationToken
        );
        getDispute.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Disputes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
