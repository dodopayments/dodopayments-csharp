using System.Threading.Tasks;
using Dodopayments.Models.Meters;

namespace Dodopayments.Services.Meters;

public interface IMeterService
{
    Task<Meter> Create(MeterCreateParams parameters);

    Task<Meter> Retrieve(MeterRetrieveParams parameters);

    Task<MeterListPageResponse> List(MeterListParams parameters);

    Task Archive(MeterArchiveParams parameters);

    Task Unarchive(MeterUnarchiveParams parameters);
}
