using System.Threading.Tasks;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services.Disputes;

public interface IDisputeService
{
    Task<GetDispute> Retrieve(DisputeRetrieveParams parameters);

    Task<DisputeListPageResponse> List(DisputeListParams parameters);
}
