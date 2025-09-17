using System.Threading.Tasks;
using Dodopayments.Models.CheckoutSessions;

namespace Dodopayments.Services.CheckoutSessions;

public interface ICheckoutSessionService
{
    Task<CheckoutSessionResponse> Create(CheckoutSessionCreateParams parameters);
}
