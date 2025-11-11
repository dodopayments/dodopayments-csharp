using System;
using DodoPayments.Client.Core;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

public interface IInvoiceService
{
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Invoices::IPaymentService Payments { get; }
}
