using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services;

public interface IDisputeService
{
    IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<GetDispute> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<DisputeListPageResponse> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
