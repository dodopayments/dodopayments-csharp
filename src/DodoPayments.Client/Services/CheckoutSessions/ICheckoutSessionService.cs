using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services.CheckoutSessions;

public interface ICheckoutSessionService
{
    ICheckoutSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CheckoutSessionResponse> Create(CheckoutSessionCreateParams parameters);

    Task<CheckoutSessionStatus> Retrieve(CheckoutSessionRetrieveParams parameters);
}
