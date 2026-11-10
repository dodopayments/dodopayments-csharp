using System;
using System.Net.Http;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceSendParams { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        string expectedInvoiceID = "invoice_id";
        string expectedIfMatch = "If-Match";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedIfMatch, parameters.IfMatch);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceSendParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id/send"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InvoiceSendParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["If-Match"], requestMessage.Headers.GetValues("If-Match"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceSendParams { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        InvoiceSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
