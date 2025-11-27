using System;
using DodoPayments.Client.Core;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class InvoiceService : IInvoiceService
{
    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public InvoiceService(IDodoPaymentsClient client)
    {
        _client = client;
        _payments = new(() => new Invoices::PaymentService(client));
    }

    readonly Lazy<Invoices::IPaymentService> _payments;
    public Invoices::IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
