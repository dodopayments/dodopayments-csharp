using System.Threading.Tasks;
using Dodopayments.Models.Webhooks;
using Headers = Dodopayments.Services.Webhooks.Headers;

namespace Dodopayments.Services.Webhooks;

public interface IWebhookService
{
    Headers::IHeaderService Headers { get; }

    /// <summary>
    /// Create a new webhook
    /// </summary>
    Task<WebhookDetails> Create(WebhookCreateParams parameters);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<WebhookDetails> Retrieve(WebhookRetrieveParams parameters);

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task<WebhookDetails> Update(WebhookUpdateParams parameters);

    /// <summary>
    /// List all webhooks
    /// </summary>
    Task<WebhookListPageResponse> List(WebhookListParams parameters);

    /// <summary>
    /// Delete a webhook by id
    /// </summary>
    Task Delete(WebhookDeleteParams parameters);

    /// <summary>
    /// Get webhook secret by id
    /// </summary>
    Task<WebhookRetrieveSecretResponse> RetrieveSecret(WebhookRetrieveSecretParams parameters);
}
