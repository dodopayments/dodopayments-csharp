using System.Threading.Tasks;
using DodoPayments.Models.Disputes;

namespace DodoPayments.Services.Disputes;

public interface IDisputeService
{
    Task<GetDispute> Retrieve(DisputeRetrieveParams parameters);

    Task<DisputeListPageResponse> List(DisputeListParams parameters);
}
