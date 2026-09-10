using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class EmailServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Emails.List(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task RetrieveBody_Works()
    {
        var emailBody = await this.client.Customers.Emails.RetrieveBody(
            "email_log_id",
            new() { CustomerID = "customer_id" },
            TestContext.Current.CancellationToken
        );
        emailBody.Validate();
    }
}
