using System.Threading.Tasks;
using DodoPayments.Models.Payouts;

namespace DodoPayments.Services.Payouts;

public interface IPayoutService
{
    Task<PayoutListPageResponse> List(PayoutListParams parameters);
}
