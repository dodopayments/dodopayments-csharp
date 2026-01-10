using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class LicenseService : ILicenseService
{
    readonly Lazy<ILicenseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILicenseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseService(this._client.WithOptions(modifier));
    }

    public LicenseService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LicenseServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LicenseActivateResponse> Activate(
        LicenseActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Activate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LicenseValidateResponse> Validate(
        LicenseValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Validate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class LicenseServiceWithRawResponse : ILicenseServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILicenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LicenseServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseActivateResponse>> Activate(
        LicenseActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseActivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<LicenseActivateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseDeactivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseValidateResponse>> Validate(
        LicenseValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseValidateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<LicenseValidateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
