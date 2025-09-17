using System.Threading.Tasks;
using Dodopayments.Models.Payouts;

namespace Dodopayments.Services.Payouts;

public interface IPayoutService
{
    Task<PayoutListPageResponse> List(PayoutListParams parameters);
}
