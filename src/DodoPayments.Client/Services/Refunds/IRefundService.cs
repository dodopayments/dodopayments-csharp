using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Services.Refunds;

public interface IRefundService
{
    IRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Refund> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Refund> Retrieve(
        RefundRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<RefundListPageResponse> List(
        RefundListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
