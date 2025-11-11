using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services;

public interface ILicenseService
{
    ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseActivateResponse> Activate(
        LicenseActivateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseValidateResponse> Validate(
        LicenseValidateParams parameters,
        CancellationToken cancellationToken = default
    );
}
