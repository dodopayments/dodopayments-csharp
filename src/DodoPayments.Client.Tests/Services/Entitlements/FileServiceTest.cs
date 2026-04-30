using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Entitlements;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Entitlements.Files.Delete(
            "file_id",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Upload_Works()
    {
        var response = await this.client.Entitlements.Files.Upload(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
