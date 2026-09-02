using System;
using DodoPayments.Client.Core;
using Blocklist = DodoPayments.Client.Services.Blocklist;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class BlocklistService : IBlocklistService
{
    readonly Lazy<IBlocklistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBlocklistServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IBlocklistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BlocklistService(this._client.WithOptions(modifier));
    }

    public BlocklistService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BlocklistServiceWithRawResponse(client.WithRawResponse));
        _customers = new(() => new Blocklist::CustomerService(client));
    }

    readonly Lazy<Blocklist::ICustomerService> _customers;
    public Blocklist::ICustomerService Customers
    {
        get { return _customers.Value; }
    }
}

/// <inheritdoc/>
public sealed class BlocklistServiceWithRawResponse : IBlocklistServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBlocklistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BlocklistServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BlocklistServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _customers = new(() => new Blocklist::CustomerServiceWithRawResponse(client));
    }

    readonly Lazy<Blocklist::ICustomerServiceWithRawResponse> _customers;
    public Blocklist::ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }
}
