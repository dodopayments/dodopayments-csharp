using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Webhooks.Headers;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Services.Webhooks;

public interface IWebhookService
{
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHeaderService Headers { get; }

    /// <summary>
    /// Create a new webhook
    /// </summary>
    Task<Webhooks::WebhookDetails> Create(Webhooks::WebhookCreateParams parameters);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<Webhooks::WebhookDetails> Retrieve(Webhooks::WebhookRetrieveParams parameters);

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task<Webhooks::WebhookDetails> Update(Webhooks::WebhookUpdateParams parameters);

    /// <summary>
    /// List all webhooks
    /// </summary>
    Task<Webhooks::WebhookListPageResponse> List(Webhooks::WebhookListParams? parameters = null);

    /// <summary>
    /// Delete a webhook by id
    /// </summary>
    Task Delete(Webhooks::WebhookDeleteParams parameters);

    /// <summary>
    /// Get webhook secret by id
    /// </summary>
    Task<Webhooks::WebhookRetrieveSecretResponse> RetrieveSecret(
        Webhooks::WebhookRetrieveSecretParams parameters
    );
}
