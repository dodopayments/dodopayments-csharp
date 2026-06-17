using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Entitlements;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Entitlements.Files.Delete(
            "file_id",
            new() { ID = "ent_jt7jcvI79Xh8eehqgWdcm" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Upload_Works()
    {
        var response = await this.client.Entitlements.Files.Upload(
            "ent_jt7jcvI79Xh8eehqgWdcm",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
