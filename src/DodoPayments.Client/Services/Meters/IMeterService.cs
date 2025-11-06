using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services.Meters;

public interface IMeterService
{
    IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Meters::Meter> Create(Meters::MeterCreateParams parameters);

    Task<Meters::Meter> Retrieve(Meters::MeterRetrieveParams parameters);

    Task<Meters::MeterListPageResponse> List(Meters::MeterListParams? parameters = null);

    Task Archive(Meters::MeterArchiveParams parameters);

    Task Unarchive(Meters::MeterUnarchiveParams parameters);
}
