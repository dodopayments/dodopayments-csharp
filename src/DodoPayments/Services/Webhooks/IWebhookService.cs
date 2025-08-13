using System.Threading.Tasks;
using DodoPayments.Models.Webhooks;
using Headers = DodoPayments.Services.Webhooks.Headers;

namespace DodoPayments.Services.Webhooks;

public interface IWebhookService
{
    Headers::IHeaderService Headers { get; }

    /// <summary>
    /// Create a new webhook
    /// </summary>
    Task<WebhookCreateResponse> Create(WebhookCreateParams parameters);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<WebhookRetrieveResponse> Retrieve(WebhookRetrieveParams parameters);

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task<WebhookUpdateResponse> Update(WebhookUpdateParams parameters);

    /// <summary>
    /// List all webhooks
    /// </summary>
    Task<WebhookListPageResponse> List(WebhookListParams parameters);

    /// <summary>
    /// Delete a webhook by id
    /// </summary>
    Task Delete(WebhookDeleteParams parameters);
}
