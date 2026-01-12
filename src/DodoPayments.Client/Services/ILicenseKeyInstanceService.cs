using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILicenseKeyInstanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILicenseKeyInstanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>get /license_key_instances/{id}<c/>.
    /// </summary>
    Task<LicenseKeyInstance> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseKeyInstanceRetrieveParams, CancellationToken)"/>
    Task<LicenseKeyInstance> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /license_key_instances/{id}<c/>.
    /// </summary>
    Task<LicenseKeyInstance> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LicenseKeyInstanceUpdateParams, CancellationToken)"/>
    Task<LicenseKeyInstance> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /license_key_instances<c/>.
    /// </summary>
    Task<LicenseKeyInstanceListPage> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILicenseKeyInstanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILicenseKeyInstanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseKeyInstanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /license_key_instances/{id}`, but is otherwise the
    /// same as <see cref="ILicenseKeyInstanceService.Retrieve(LicenseKeyInstanceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseKeyInstance>> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseKeyInstanceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LicenseKeyInstance>> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /license_key_instances/{id}`, but is otherwise the
    /// same as <see cref="ILicenseKeyInstanceService.Update(LicenseKeyInstanceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseKeyInstance>> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LicenseKeyInstanceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LicenseKeyInstance>> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /license_key_instances`, but is otherwise the
    /// same as <see cref="ILicenseKeyInstanceService.List(LicenseKeyInstanceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseKeyInstanceListPage>> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
