using DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public interface IInvoiceService
{
    IPaymentService Payments { get; }
}
