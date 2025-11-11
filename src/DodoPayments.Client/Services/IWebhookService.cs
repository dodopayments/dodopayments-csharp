using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client.Services;

public interface IWebhookService
{
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHeaderService Headers { get; }

    /// <summary>
    /// Create a new webhook
    /// </summary>
    Task<WebhookDetails> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<WebhookDetails> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task<WebhookDetails> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all webhooks
    /// </summary>
    Task<WebhookListPageResponse> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a webhook by id
    /// </summary>
    Task Delete(WebhookDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get webhook secret by id
    /// </summary>
    Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    );
}
