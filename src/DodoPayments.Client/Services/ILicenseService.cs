using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILicenseService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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
