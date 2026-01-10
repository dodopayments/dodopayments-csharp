using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Services;

namespace DodoPayments.Client.Models.Webhooks;

public sealed class WebhookListPage(
    IWebhookServiceWithRawResponse service,
    WebhookListParams parameters,
    WebhookListPageResponse response
) : IPage<WebhookDetails>
{
    /// <inheritdoc/>
    public IReadOnlyList<WebhookDetails> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Iterator != null;
        }
        catch (DodoPaymentsInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<WebhookDetails>> IPage<WebhookDetails>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<WebhookListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.Iterator ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { Iterator = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
