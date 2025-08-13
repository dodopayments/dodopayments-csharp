using System;
using DodoPayments = DodoPayments;
using Payments = DodoPayments.Services.Invoices.Payments;

namespace DodoPayments.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public InvoiceService(DodoPayments::IDodoPaymentsClient client)
    {
        _payments = new(() => new Payments::PaymentService(client));
    }

    readonly Lazy<Payments::IPaymentService> _payments;
    public Payments::IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
