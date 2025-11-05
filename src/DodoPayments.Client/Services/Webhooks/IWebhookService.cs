using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

public interface IWebhookService
{
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHeaderService Headers { get; }

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
    Task<WebhookListPageResponse> List(WebhookListParams? parameters = null);

    /// <summary>
    /// Delete a webhook by id
    /// </summary>
    Task Delete(WebhookDeleteParams parameters);

    /// <summary>
    /// Get webhook secret by id
    /// </summary>
    Task<WebhookRetrieveSecretResponse> RetrieveSecret(WebhookRetrieveSecretParams parameters);
}
