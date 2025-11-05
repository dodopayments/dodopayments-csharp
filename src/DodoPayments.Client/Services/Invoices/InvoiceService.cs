using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public InvoiceService(IDodoPaymentsClient client)
    {
        _client = client;
        _payments = new(() => new PaymentService(client));
    }

    readonly Lazy<IPaymentService> _payments;
    public IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
