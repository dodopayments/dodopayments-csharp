using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.AppInstallation;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class AppInstallationService : IAppInstallationService
{
    readonly Lazy<IAppInstallationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAppInstallationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IAppInstallationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AppInstallationService(this._client.WithOptions(modifier));
    }

    public AppInstallationService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AppInstallationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AppInstallationRetrieveSettingsResponse> RetrieveSettings(
        AppInstallationRetrieveSettingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSettings(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AppInstallationServiceWithRawResponse : IAppInstallationServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAppInstallationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AppInstallationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AppInstallationServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AppInstallationRetrieveSettingsResponse>> RetrieveSettings(
        AppInstallationRetrieveSettingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AppInstallationRetrieveSettingsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AppInstallationRetrieveSettingsResponse>(token)
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
