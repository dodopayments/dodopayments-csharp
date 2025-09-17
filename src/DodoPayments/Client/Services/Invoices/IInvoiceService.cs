using Payments = DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public interface IInvoiceService
{
    Payments::IPaymentService Payments { get; }
}
