using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class RefundService : IRefundService
{
    /// <inheritdoc/>
    public IRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefundService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public RefundService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Refund> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RefundCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var refund = await response.Deserialize<Refund>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            refund.Validate();
        }
        return refund;
    }

    /// <inheritdoc/>
    public async Task<Refund> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var refund = await response.Deserialize<Refund>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            refund.Validate();
        }
        return refund;
    }

    /// <inheritdoc/>
    public async Task<Refund> Retrieve(
        string refundID,
        RefundRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { RefundID = refundID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RefundListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<RefundListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
