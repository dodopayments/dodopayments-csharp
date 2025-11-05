using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public interface IInvoiceService
{
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPaymentService Payments { get; }
}
