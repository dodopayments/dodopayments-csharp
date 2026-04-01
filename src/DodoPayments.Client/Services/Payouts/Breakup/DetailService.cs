using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Services.Payouts.Breakup;

/// <inheritdoc/>
public sealed class DetailService : IDetailService
{
    readonly Lazy<IDetailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDetailServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IDetailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DetailService(this._client.WithOptions(modifier));
    }

    public DetailService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DetailServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DetailListPage> List(
        DetailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DetailListPage> List(
        string payoutID,
        DetailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PayoutID = payoutID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DownloadCsv(
        DetailDownloadCsvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DownloadCsv(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DownloadCsv(
        string payoutID,
        DetailDownloadCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.DownloadCsv(parameters with { PayoutID = payoutID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DetailServiceWithRawResponse : IDetailServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDetailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DetailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DetailServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailListPage>> List(
        DetailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PayoutID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PayoutID' cannot be null");
        }

        HttpRequest<DetailListParams> request = new()
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
                    .Deserialize<DetailListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DetailListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DetailListPage>> List(
        string payoutID,
        DetailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PayoutID = payoutID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadCsv(
        DetailDownloadCsvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PayoutID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PayoutID' cannot be null");
        }

        HttpRequest<DetailDownloadCsvParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadCsv(
        string payoutID,
        DetailDownloadCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DownloadCsv(parameters with { PayoutID = payoutID }, cancellationToken);
    }
}
