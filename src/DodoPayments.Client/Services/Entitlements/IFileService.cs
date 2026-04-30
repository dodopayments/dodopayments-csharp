using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Services.Entitlements;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Companion to `post_entitlement_file`. Deletes the file from the Entitlements
    /// Engine (force=true) and atomically removes the `file_id` from the entitlement's
    /// `integration_config.digital_file_ids` JSONB array. EE delete happens first; if
    /// it fails we surface the error and leave local state untouched.
    /// </summary>
    Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Streams a multipart/form-data body to the Entitlements Engine (`POST
    /// /api/digital-files/dodo/files/upload`) and appends the returned `file_id` to the
    /// entitlement's `integration_config.digital_file_ids` using a JSONB array append.
    /// Compensates EE-side on local DB write failure (best-effort delete of the
    /// just-uploaded file).
    /// </summary>
    Task<FileUploadResponse> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(FileUploadParams, CancellationToken)"/>
    Task<FileUploadResponse> Upload(
        string id,
        FileUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /entitlements/{id}/files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entitlements/{id}/files</c>, but is otherwise the
    /// same as <see cref="IFileService.Upload(FileUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(FileUploadParams, CancellationToken)"/>
    Task<HttpResponse<FileUploadResponse>> Upload(
        string id,
        FileUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
