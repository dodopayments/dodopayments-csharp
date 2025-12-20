using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class MeterService : IMeterService
{
    /// <inheritdoc/>
    public IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeterService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public MeterService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Meter> Create(
        MeterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response.Deserialize<Meter>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    /// <inheritdoc/>
    public async Task<Meter> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MeterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response.Deserialize<Meter>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    /// <inheritdoc/>
    public async Task<Meter> Retrieve(
        string id,
        MeterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeterListPage> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MeterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<MeterListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new MeterListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task Archive(
        MeterArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MeterArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string id,
        MeterArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unarchive(
        MeterUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MeterUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Unarchive(
        string id,
        MeterUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unarchive(parameters with { ID = id }, cancellationToken);
    }
}
