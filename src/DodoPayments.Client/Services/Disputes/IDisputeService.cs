using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services.Disputes;

public interface IDisputeService
{
    IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<GetDispute> Retrieve(DisputeRetrieveParams parameters);

    Task<DisputeListPageResponse> List(DisputeListParams? parameters = null);
}
