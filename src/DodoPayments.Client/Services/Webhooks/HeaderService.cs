using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

/// <inheritdoc />
public sealed class HeaderService : IHeaderService
{
    /// <inheritdoc/>
    public IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HeaderService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public HeaderService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<HeaderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var header = await response
            .Deserialize<HeaderRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            header.Validate();
        }
        return header;
    }

    /// <inheritdoc/>
    public async Task<HeaderRetrieveResponse> Retrieve(
        string webhookID,
        HeaderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<HeaderUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string webhookID,
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { WebhookID = webhookID }, cancellationToken);
    }
}
