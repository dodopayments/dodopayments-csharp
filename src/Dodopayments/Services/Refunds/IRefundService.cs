using System.Threading.Tasks;
using Dodopayments.Models.Refunds;

namespace Dodopayments.Services.Refunds;

public interface IRefundService
{
    Task<Refund> Create(RefundCreateParams parameters);

    Task<Refund> Retrieve(RefundRetrieveParams parameters);

    Task<RefundListPageResponse> List(RefundListParams parameters);
}
