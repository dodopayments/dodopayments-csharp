using System;
using Dodopayments = Dodopayments;
using Payments = Dodopayments.Services.Invoices.Payments;

namespace Dodopayments.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public InvoiceService(Dodopayments::IDodoPaymentsClient client)
    {
        _payments = new(() => new Payments::PaymentService(client));
    }

    readonly Lazy<Payments::IPaymentService> _payments;
    public Payments::IPaymentService Payments
    {
        get { return _payments.Value; }
    }
}
