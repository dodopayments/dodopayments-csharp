using System;
using DodoPayments.Client.Core;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Invoices::IPaymentService Payments { get; }
}
