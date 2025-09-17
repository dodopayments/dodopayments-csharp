using System.Threading.Tasks;
using Dodopayments.Models.Webhooks.Headers;

namespace Dodopayments.Services.Webhooks.Headers;

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
