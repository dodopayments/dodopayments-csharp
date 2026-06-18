using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Invoices;

public class PaymentServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Invoices.Payments.Retrieve(
            "pay_gr4RizvMOXFJ6xca3y2tU",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RetrievePayout_Works()
    {
        await this.client.Invoices.Payments.RetrievePayout(
            "pyt_zFTrrn4sk3x3y2vjDBW3T",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RetrieveRefund_Works()
    {
        await this.client.Invoices.Payments.RetrieveRefund(
            "ref_F0gZetLvTxxBrMU2CZcmy",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
