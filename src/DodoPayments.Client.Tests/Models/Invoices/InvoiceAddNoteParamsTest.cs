using System;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceAddNoteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceAddNoteParams { InvoiceID = "invoice_id", Text = "text" };

        string expectedInvoiceID = "invoice_id";
        string expectedText = "text";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceAddNoteParams parameters = new() { InvoiceID = "invoice_id", Text = "text" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id/notes"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceAddNoteParams { InvoiceID = "invoice_id", Text = "text" };

        InvoiceAddNoteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
