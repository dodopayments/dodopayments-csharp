using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services.Payouts;

public interface IPayoutService
{
    IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<PayoutListPageResponse> List(PayoutListParams? parameters = null);
}
