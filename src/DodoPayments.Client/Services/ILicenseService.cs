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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILicenseServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="ILicenseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILicenseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /licenses/activate`, but is otherwise the
    /// same as <see cref="ILicenseService.Activate(LicenseActivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseActivateResponse>> Activate(
        LicenseActivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /licenses/deactivate`, but is otherwise the
    /// same as <see cref="ILicenseService.Deactivate(LicenseDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /licenses/validate`, but is otherwise the
    /// same as <see cref="ILicenseService.Validate(LicenseValidateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseValidateResponse>> Validate(
        LicenseValidateParams parameters,
        CancellationToken cancellationToken = default
    );
}
