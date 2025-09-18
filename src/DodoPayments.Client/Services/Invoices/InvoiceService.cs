using System;
using DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public InvoiceService(IDodoPaymentsClient client)
    {
        _payments = new(() => new PaymentService(client));
    }

    readonly Lazy<IPaymentService> _payments;
    public IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
