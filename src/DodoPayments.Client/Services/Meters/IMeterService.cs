using System.Threading.Tasks;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services.Meters;

public interface IMeterService
{
    Task<Meter> Create(MeterCreateParams parameters);

    Task<Meter> Retrieve(MeterRetrieveParams parameters);

    Task<MeterListPageResponse> List(MeterListParams? parameters = null);

    Task Archive(MeterArchiveParams parameters);

    Task Unarchive(MeterUnarchiveParams parameters);
}
