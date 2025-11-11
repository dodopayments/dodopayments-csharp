using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services;

public interface IMeterService
{
    IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Meter> Create(MeterCreateParams parameters, CancellationToken cancellationToken = default);

    Task<Meter> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<MeterListPageResponse> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(MeterArchiveParams parameters, CancellationToken cancellationToken = default);

    Task Unarchive(MeterUnarchiveParams parameters, CancellationToken cancellationToken = default);
}
