using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.ProductCollections.Groups;
using DodoPayments.Client.Services.ProductCollections.Groups;

namespace DodoPayments.Client.Services.ProductCollections;

/// <inheritdoc/>
public sealed class GroupService : IGroupService
{
    readonly Lazy<IGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GroupService(this._client.WithOptions(modifier));
    }

    public GroupService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GroupServiceWithRawResponse(client.WithRawResponse));
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }

    /// <inheritdoc/>
    public async Task<ProductCollectionGroupResponse> Create(
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProductCollectionGroupResponse> Create(
        string id,
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(GroupUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string groupID,
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { GroupID = groupID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(GroupDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string groupID,
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { GroupID = groupID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GroupServiceWithRawResponse : IGroupServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GroupServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _items = new(() => new ItemServiceWithRawResponse(client));
    }

    readonly Lazy<IItemServiceWithRawResponse> _items;
    public IItemServiceWithRawResponse Items
    {
        get { return _items.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollectionGroupResponse>> Create(
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var productCollectionGroupResponse = await response
                    .Deserialize<ProductCollectionGroupResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    productCollectionGroupResponse.Validate();
                }
                return productCollectionGroupResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ProductCollectionGroupResponse>> Create(
        string id,
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GroupID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.GroupID' cannot be null");
        }

        HttpRequest<GroupUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string groupID,
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { GroupID = groupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GroupID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.GroupID' cannot be null");
        }

        HttpRequest<GroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string groupID,
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { GroupID = groupID }, cancellationToken);
    }
}
