using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeterService
{
    IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Meter> Create(MeterCreateParams parameters, CancellationToken cancellationToken = default);

    Task<Meter> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<Meter> Retrieve(
        string id,
        MeterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<MeterListPageResponse> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(MeterArchiveParams parameters, CancellationToken cancellationToken = default);
    Task Archive(
        string id,
        MeterArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Unarchive(MeterUnarchiveParams parameters, CancellationToken cancellationToken = default);
    Task Unarchive(
        string id,
        MeterUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
