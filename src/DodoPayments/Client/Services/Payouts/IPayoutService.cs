using System.Threading.Tasks;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services.Payouts;

public interface IPayoutService
{
    Task<PayoutListPageResponse> List(PayoutListParams parameters);
}
