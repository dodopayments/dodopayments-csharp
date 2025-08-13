using Payments = DodoPayments.Services.Invoices.Payments;

namespace DodoPayments.Services.Invoices;

public interface IInvoiceService
{
    Payments::IPaymentService Payments { get; }
}
