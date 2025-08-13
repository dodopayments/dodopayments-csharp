using System.Threading.Tasks;
using DodoPayments.Models.Webhooks.Headers;

namespace DodoPayments.Services.Webhooks.Headers;

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
