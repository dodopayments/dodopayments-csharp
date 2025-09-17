using System.Threading.Tasks;
using Dodopayments.Models.Disputes;

namespace Dodopayments.Services.Disputes;

public interface IDisputeService
{
    Task<GetDispute> Retrieve(DisputeRetrieveParams parameters);

    Task<DisputeListPageResponse> List(DisputeListParams parameters);
}
