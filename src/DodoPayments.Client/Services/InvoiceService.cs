using System;
using DodoPayments.Client.Core;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class InvoiceService : IInvoiceService
{
    readonly Lazy<IInvoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    public InvoiceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvoiceServiceWithRawResponse(client.WithRawResponse));
        _payments = new(() => new Invoices::PaymentService(client));
    }

    readonly Lazy<Invoices::IPaymentService> _payments;
    public Invoices::IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}

/// <inheritdoc/>
public sealed class InvoiceServiceWithRawResponse : IInvoiceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _payments = new(() => new Invoices::PaymentServiceWithRawResponse(client));
    }

    readonly Lazy<Invoices::IPaymentServiceWithRawResponse> _payments;
    public Invoices::IPaymentServiceWithRawResponse Payments
    {
        get { return _payments.Value; }
    }
}
