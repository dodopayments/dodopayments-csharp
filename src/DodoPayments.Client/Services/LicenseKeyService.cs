using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class LicenseKeyService : ILicenseKeyService
{
    /// <inheritdoc/>
    public ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseKeyService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public LicenseKeyService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<LicenseKey> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var licenseKey = await response
            .Deserialize<LicenseKey>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKey.Validate();
        }
        return licenseKey;
    }

    /// <inheritdoc/>
    public async Task<LicenseKey> Retrieve(
        string id,
        LicenseKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKey> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var licenseKey = await response
            .Deserialize<LicenseKey>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKey.Validate();
        }
        return licenseKey;
    }

    /// <inheritdoc/>
    public async Task<LicenseKey> Update(
        string id,
        LicenseKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyListPageResponse> List(
        LicenseKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LicenseKeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<LicenseKeyListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
