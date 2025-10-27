using System.Threading.Tasks;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services.CheckoutSessions;

public interface ICheckoutSessionService
{
    Task<CheckoutSessionResponse> Create(CheckoutSessionCreateParams parameters);

    Task<CheckoutSessionStatus> Retrieve(CheckoutSessionRetrieveParams parameters);
}
