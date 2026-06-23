using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Services.Entitlements;

/// <inheritdoc/>
public sealed class GrantService : IGrantService
{
    readonly Lazy<IGrantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGrantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IGrantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GrantService(this._client.WithOptions(modifier));
    }

    public GrantService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GrantServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GrantListPage> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GrantListPage> List(
        string id,
        GrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementGrant> FulfillLicenseKey(
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FulfillLicenseKey(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementGrant> FulfillLicenseKey(
        string grantID,
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FulfillLicenseKey(parameters with { GrantID = grantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementGrant> Revoke(
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementGrant> Revoke(
        string grantID,
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { GrantID = grantID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GrantServiceWithRawResponse : IGrantServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGrantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GrantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GrantServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GrantListPage>> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GrantListParams> request = new()
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
                    .Deserialize<GrantListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new GrantListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GrantListPage>> List(
        string id,
        GrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementGrant>> FulfillLicenseKey(
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GrantID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.GrantID' cannot be null");
        }

        HttpRequest<GrantFulfillLicenseKeyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlementGrant = await response
                    .Deserialize<EntitlementGrant>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlementGrant.Validate();
                }
                return entitlementGrant;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementGrant>> FulfillLicenseKey(
        string grantID,
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FulfillLicenseKey(parameters with { GrantID = grantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementGrant>> Revoke(
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GrantID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.GrantID' cannot be null");
        }

        HttpRequest<GrantRevokeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlementGrant = await response
                    .Deserialize<EntitlementGrant>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlementGrant.Validate();
                }
                return entitlementGrant;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementGrant>> Revoke(
        string grantID,
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { GrantID = grantID }, cancellationToken);
    }
}
