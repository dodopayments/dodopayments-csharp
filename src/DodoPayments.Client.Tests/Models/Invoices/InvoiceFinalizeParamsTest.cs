using System;
using System.Collections.Generic;
using System.Net.Http;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceFinalizeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            Send = true,
        };

        string expectedInvoiceID = "invoice_id";
        string expectedIfMatch = "If-Match";
        List<string> expectedCcEmails = ["string"];
        string expectedCustomerEmail = "customer_email";
        bool expectedSend = true;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedIfMatch, parameters.IfMatch);
        Assert.NotNull(parameters.CcEmails);
        Assert.Equal(expectedCcEmails.Count, parameters.CcEmails.Count);
        for (int i = 0; i < expectedCcEmails.Count; i++)
        {
            Assert.Equal(expectedCcEmails[i], parameters.CcEmails[i]);
        }
        Assert.Equal(expectedCustomerEmail, parameters.CustomerEmail);
        Assert.Equal(expectedSend, parameters.Send);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
        };

        Assert.Null(parameters.Send);
        Assert.False(parameters.RawBodyData.ContainsKey("send"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            CcEmails = ["string"],
            CustomerEmail = "customer_email",

            // Null should be interpreted as omitted for these properties
            Send = null,
        };

        Assert.Null(parameters.Send);
        Assert.False(parameters.RawBodyData.ContainsKey("send"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            Send = true,
        };

        Assert.Null(parameters.CcEmails);
        Assert.False(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CustomerEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_email"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            Send = true,

            CcEmails = null,
            CustomerEmail = null,
        };

        Assert.Null(parameters.CcEmails);
        Assert.True(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CustomerEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_email"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceFinalizeParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id/finalize"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InvoiceFinalizeParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["If-Match"], requestMessage.Headers.GetValues("If-Match"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceFinalizeParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            Send = true,
        };

        InvoiceFinalizeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
