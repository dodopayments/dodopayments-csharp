using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class PaymentService : IPaymentService
{
    /// <inheritdoc/>
    public IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PaymentCreateResponse> Create(
        PaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PaymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var payment = await response
            .Deserialize<PaymentCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            payment.Validate();
        }
        return payment;
    }

    /// <inheritdoc/>
    public async Task<Payment> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PaymentID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PaymentID' cannot be null");
        }

        HttpRequest<PaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var payment = await response.Deserialize<Payment>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            payment.Validate();
        }
        return payment;
    }

    /// <inheritdoc/>
    public async Task<Payment> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { PaymentID = paymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaymentListPageResponse> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PaymentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PaymentListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PaymentID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PaymentID' cannot be null");
        }

        HttpRequest<PaymentRetrieveLineItemsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PaymentRetrieveLineItemsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        string paymentID,
        PaymentRetrieveLineItemsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveLineItems(
            parameters with
            {
                PaymentID = paymentID,
            },
            cancellationToken
        );
    }
}
