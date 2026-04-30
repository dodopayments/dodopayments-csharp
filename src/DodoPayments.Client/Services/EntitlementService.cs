using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Services.Entitlements;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class EntitlementService : IEntitlementService
{
    readonly Lazy<IEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntitlementService(this._client.WithOptions(modifier));
    }

    public EntitlementService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntitlementServiceWithRawResponse(client.WithRawResponse));
        _files = new(() => new FileService(client));
        _grants = new(() => new GrantService(client));
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<IGrantService> _grants;
    public IGrantService Grants
    {
        get { return _grants.Value; }
    }

    /// <inheritdoc/>
    public async Task<EntitlementCreateResponse> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntitlementRetrieveResponse> Retrieve(
        EntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementRetrieveResponse> Retrieve(
        string id,
        EntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementUpdateResponse> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementUpdateResponse> Update(
        string id,
        EntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementListPage> List(
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        EntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EntitlementServiceWithRawResponse : IEntitlementServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntitlementServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _files = new(() => new FileServiceWithRawResponse(client));
        _grants = new(() => new GrantServiceWithRawResponse(client));
    }

    readonly Lazy<IFileServiceWithRawResponse> _files;
    public IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<IGrantServiceWithRawResponse> _grants;
    public IGrantServiceWithRawResponse Grants
    {
        get { return _grants.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementCreateResponse>> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntitlementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlement = await response
                    .Deserialize<EntitlementCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlement.Validate();
                }
                return entitlement;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementRetrieveResponse>> Retrieve(
        EntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlement = await response
                    .Deserialize<EntitlementRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlement.Validate();
                }
                return entitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementRetrieveResponse>> Retrieve(
        string id,
        EntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementUpdateResponse>> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlement = await response
                    .Deserialize<EntitlementUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlement.Validate();
                }
                return entitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementUpdateResponse>> Update(
        string id,
        EntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementListPage>> List(
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EntitlementListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<EntitlementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EntitlementListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
