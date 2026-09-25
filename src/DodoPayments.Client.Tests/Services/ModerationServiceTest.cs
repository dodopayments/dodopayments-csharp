using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class ModerationServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveUsage_Works()
    {
        var response = await this.client.Moderation.RetrieveUsage(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Screen_Works()
    {
        var response = await this.client.Moderation.Screen(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
