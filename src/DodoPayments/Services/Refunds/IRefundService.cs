using System.Threading.Tasks;
using DodoPayments.Models.Refunds;

namespace DodoPayments.Services.Refunds;

public interface IRefundService
{
    Task<Refund> Create(RefundCreateParams parameters);

    Task<Refund> Retrieve(RefundRetrieveParams parameters);

    Task<RefundListPageResponse> List(RefundListParams parameters);
}
