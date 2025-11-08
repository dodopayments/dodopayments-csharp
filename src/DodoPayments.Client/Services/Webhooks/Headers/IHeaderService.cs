using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks.Headers;

public interface IHeaderService
{
    IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task Update(HeaderUpdateParams parameters, CancellationToken cancellationToken = default);
}
