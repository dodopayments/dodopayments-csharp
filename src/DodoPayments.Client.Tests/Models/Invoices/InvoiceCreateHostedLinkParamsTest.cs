using System;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceCreateHostedLinkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceCreateHostedLinkParams { InvoiceID = "invoice_id" };

        string expectedInvoiceID = "invoice_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceCreateHostedLinkParams parameters = new() { InvoiceID = "invoice_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id/hosted-link"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceCreateHostedLinkParams { InvoiceID = "invoice_id" };

        InvoiceCreateHostedLinkParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
