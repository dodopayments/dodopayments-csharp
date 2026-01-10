using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class LicenseKeyInstanceService : ILicenseKeyInstanceService
{
    readonly Lazy<ILicenseKeyInstanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILicenseKeyInstanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseKeyInstanceService(this._client.WithOptions(modifier));
    }

    public LicenseKeyInstanceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new LicenseKeyInstanceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyInstance> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseKeyInstance> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyInstance> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseKeyInstance> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyInstanceListPage> List(
        LicenseKeyInstanceListParams? parameters = null,
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
public sealed class LicenseKeyInstanceServiceWithRawResponse
    : ILicenseKeyInstanceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILicenseKeyInstanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LicenseKeyInstanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LicenseKeyInstanceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseKeyInstance>> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyInstanceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var licenseKeyInstance = await response
                    .Deserialize<LicenseKeyInstance>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    licenseKeyInstance.Validate();
                }
                return licenseKeyInstance;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseKeyInstance>> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseKeyInstance>> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyInstanceUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var licenseKeyInstance = await response
                    .Deserialize<LicenseKeyInstance>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    licenseKeyInstance.Validate();
                }
                return licenseKeyInstance;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseKeyInstance>> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseKeyInstanceListPage>> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LicenseKeyInstanceListParams> request = new()
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
                    .Deserialize<LicenseKeyInstanceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LicenseKeyInstanceListPage(this, parameters, page);
            }
        );
    }
}
