using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<WebhookDetails> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task<WebhookDetails> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<WebhookDetails> Update(
        string webhookID,
        WebhookUpdateParams? parameters = null,
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

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get webhook secret by id
    /// </summary>
    Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSecret(WebhookRetrieveSecretParams, CancellationToken)"/>
    Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        string webhookID,
        WebhookRetrieveSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
