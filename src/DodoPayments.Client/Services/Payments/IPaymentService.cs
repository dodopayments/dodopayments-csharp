using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services.Payments;

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
