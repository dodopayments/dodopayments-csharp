using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Services.Entitlements;

/// <inheritdoc/>
public sealed class FileService : IFileService
{
    readonly Lazy<IFileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    public FileService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { FileID = fileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FileUploadResponse> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileUploadResponse> Upload(
        string id,
        FileUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Upload(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FileServiceWithRawResponse : IFileServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FileServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FileUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FileUploadResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileUploadResponse>> Upload(
        string id,
        FileUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Upload(parameters with { ID = id }, cancellationToken);
    }
}
