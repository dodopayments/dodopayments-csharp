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
    readonly Lazy<IShortLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IShortLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IShortLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShortLinkService(this._client.WithOptions(modifier));
    }

    public ShortLinkService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ShortLinkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ShortLinkCreateResponse> Create(
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ShortLinkCreateResponse> Create(
        string id,
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ShortLinkListPage> List(
        ShortLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ShortLinkServiceWithRawResponse : IShortLinkServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IShortLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShortLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ShortLinkServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShortLinkCreateResponse>> Create(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var shortLink = await response
                    .Deserialize<ShortLinkCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    shortLink.Validate();
                }
                return shortLink;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ShortLinkCreateResponse>> Create(
        string id,
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShortLinkListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ShortLinkListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ShortLinkListPage(this, parameters, page);
            }
        );
    }
}
