using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPaymentService
{
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<PaymentCreateResponse> Create(
        PaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Payment> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<PaymentListPageResponse> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters,
        CancellationToken cancellationToken = default
    );
}
