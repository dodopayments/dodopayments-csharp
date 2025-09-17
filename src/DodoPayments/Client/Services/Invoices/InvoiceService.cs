using System;
using Client = DodoPayments.Client;
using Payments = DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public InvoiceService(Client::IDodoPaymentsClient client)
    {
        _payments = new(() => new Payments::PaymentService(client));
    }

    readonly Lazy<Payments::IPaymentService> _payments;
    public Payments::IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
