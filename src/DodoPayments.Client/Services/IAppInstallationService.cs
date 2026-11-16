using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.AppInstallation;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAppInstallationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAppInstallationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAppInstallationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// The settings of the App Installation of the app token, with the secret values.
    /// The token grant gives the installation. The token needs `app_settings:read`.
    /// </summary>
    Task<AppInstallationRetrieveSettingsResponse> RetrieveSettings(
        AppInstallationRetrieveSettingsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAppInstallationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAppInstallationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAppInstallationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /app-installation/settings</c>, but is otherwise the
    /// same as <see cref="IAppInstallationService.RetrieveSettings(AppInstallationRetrieveSettingsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AppInstallationRetrieveSettingsResponse>> RetrieveSettings(
        AppInstallationRetrieveSettingsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
