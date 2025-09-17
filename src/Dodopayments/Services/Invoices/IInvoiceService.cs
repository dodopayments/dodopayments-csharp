using Payments = Dodopayments.Services.Invoices.Payments;

namespace Dodopayments.Services.Invoices;

public interface IInvoiceService
{
    Payments::IPaymentService Payments { get; }
}
