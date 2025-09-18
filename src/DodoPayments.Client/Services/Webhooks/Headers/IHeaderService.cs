using System.Threading.Tasks;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks.Headers;

public interface IHeaderService
{
    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<HeaderRetrieveResponse> Retrieve(HeaderRetrieveParams parameters);

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task Update(HeaderUpdateParams parameters);
}
