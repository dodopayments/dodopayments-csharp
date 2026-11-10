using System.Threading.Tasks;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services;

public class InvoiceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var invoice = await this.client.Invoices.Create(
            new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Currency = Currency.Aed,
                CustomerID = "customer_id",
                Items =
                [
                    new CustomItem()
                    {
                        Description = "description",
                        TaxCategory = TaxCategory.DigitalProducts,
                        UnitAmount = 0,
                        Quantity = 0,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var invoice = await this.client.Invoices.Retrieve(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var invoice = await this.client.Invoices.Update(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Invoices.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Invoices.Delete(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task AddNote_Works()
    {
        var invoice = await this.client.Invoices.AddNote(
            "invoice_id",
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task CreateHostedLink_Works()
    {
        var response = await this.client.Invoices.CreateHostedLink(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Duplicate_Works()
    {
        var invoice = await this.client.Invoices.Duplicate(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Finalize_Works()
    {
        var invoice = await this.client.Invoices.Finalize(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task ListEvents_Works()
    {
        var response = await this.client.Invoices.ListEvents(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task MarkUncollectable_Works()
    {
        var invoice = await this.client.Invoices.MarkUncollectable(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Preview_Works()
    {
        await this.client.Invoices.Preview(
            new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Currency = Currency.Aed,
                CustomerID = "customer_id",
                Items =
                [
                    new InvoicePreviewParamsItemCustomItem()
                    {
                        Description = "description",
                        TaxCategory = TaxCategory.DigitalProducts,
                        UnitAmount = 0,
                        Quantity = 0,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task PreviewExisting_Works()
    {
        await this.client.Invoices.PreviewExisting(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retry_Works()
    {
        var invoice = await this.client.Invoices.Retry(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Send_Works()
    {
        var invoice = await this.client.Invoices.Send(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task UpdateDunning_Works()
    {
        var invoice = await this.client.Invoices.UpdateDunning(
            "invoice_id",
            new() { Action = Action.Pause, IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Void_Works()
    {
        var invoice = await this.client.Invoices.Void(
            "invoice_id",
            new() { IfMatch = "If-Match" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }
}
