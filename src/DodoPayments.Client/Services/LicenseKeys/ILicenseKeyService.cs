using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services.LicenseKeys;

public interface ILicenseKeyService
{
    ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKey> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKey> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyListPageResponse> List(
        LicenseKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
