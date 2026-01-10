using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class RefundService : IRefundService
{
    readonly Lazy<IRefundServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRefundServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefundService(this._client.WithOptions(modifier));
    }

    public RefundService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RefundServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Refund> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Refund> Retrieve(
        RefundRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Refund> Retrieve(
        string refundID,
        RefundRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RefundID = refundID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RefundListPage> List(
        RefundListParams? parameters = null,
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
public sealed class RefundServiceWithRawResponse : IRefundServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRefundServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefundServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RefundServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Refund>> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RefundCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var refund = await response.Deserialize<Refund>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    refund.Validate();
                }
                return refund;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Refund>> Retrieve(
        RefundRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RefundID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.RefundID' cannot be null");
        }

        HttpRequest<RefundRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var refund = await response.Deserialize<Refund>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    refund.Validate();
                }
                return refund;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Refund>> Retrieve(
        string refundID,
        RefundRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RefundID = refundID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RefundListPage>> List(
        RefundListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RefundListParams> request = new()
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
                    .Deserialize<RefundListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RefundListPage(this, parameters, page);
            }
        );
    }
}
