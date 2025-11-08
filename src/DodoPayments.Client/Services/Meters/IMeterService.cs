using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services.Meters;

public interface IMeterService
{
    IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Meters::Meter> Create(
        Meters::MeterCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Meters::Meter> Retrieve(
        Meters::MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Meters::MeterListPageResponse> List(
        Meters::MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(
        Meters::MeterArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Unarchive(
        Meters::MeterUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}
