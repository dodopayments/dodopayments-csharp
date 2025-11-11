using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services;

public sealed class LicenseKeyService : ILicenseKeyService
{
    public ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseKeyService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public LicenseKeyService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseKey> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<LicenseKey> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseKeyUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
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
