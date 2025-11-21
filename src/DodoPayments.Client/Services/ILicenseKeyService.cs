using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILicenseKeyService
{
    ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKey> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<LicenseKey> Retrieve(
        string id,
        LicenseKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKey> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<LicenseKey> Update(
        string id,
        LicenseKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyListPageResponse> List(
        LicenseKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
