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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILicenseKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /license_keys</c>.
    /// </summary>
    Task<LicenseKey> Create(
        LicenseKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /license_keys/{id}</c>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<LicenseKey> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseKeyRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<LicenseKey> Retrieve(
        string id,
        LicenseKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /license_keys/{id}</c>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<LicenseKey> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LicenseKeyUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<LicenseKey> Update(
        string id,
        LicenseKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /license_keys</c>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<LicenseKeyListPage> List(
        LicenseKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILicenseKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILicenseKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /license_keys</c>, but is otherwise the
    /// same as <see cref="ILicenseKeyService.Create(LicenseKeyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseKey>> Create(
        LicenseKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /license_keys/{id}</c>, but is otherwise the
    /// same as <see cref="ILicenseKeyService.Retrieve(LicenseKeyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<LicenseKey>> Retrieve(
        LicenseKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseKeyRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<LicenseKey>> Retrieve(
        string id,
        LicenseKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /license_keys/{id}</c>, but is otherwise the
    /// same as <see cref="ILicenseKeyService.Update(LicenseKeyUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<LicenseKey>> Update(
        LicenseKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LicenseKeyUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<LicenseKey>> Update(
        string id,
        LicenseKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /license_keys</c>, but is otherwise the
    /// same as <see cref="ILicenseKeyService.List(LicenseKeyListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<LicenseKeyListPage>> List(
        LicenseKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
