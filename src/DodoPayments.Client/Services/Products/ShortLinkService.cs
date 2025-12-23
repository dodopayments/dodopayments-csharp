using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Services.Products;

/// <inheritdoc/>
public sealed class ShortLinkService : IShortLinkService
{
    /// <inheritdoc/>
    public IShortLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShortLinkService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public ShortLinkService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ShortLinkCreateResponse> Create(
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ShortLinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var shortLink = await response
            .Deserialize<ShortLinkCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            shortLink.Validate();
        }
        return shortLink;
    }

    /// <inheritdoc/>
    public async Task<ShortLinkCreateResponse> Create(
        string id,
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ShortLinkListPage> List(
        ShortLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ShortLinkListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ShortLinkListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new ShortLinkListPage(this, parameters, page);
    }
}
