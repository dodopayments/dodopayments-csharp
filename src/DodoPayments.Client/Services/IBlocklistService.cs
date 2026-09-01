using System;
using DodoPayments.Client.Core;
using Blocklist = DodoPayments.Client.Services.Blocklist;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBlocklistService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBlocklistServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBlocklistService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Blocklist::ICustomerService Customers { get; }
}

/// <summary>
/// A view of <see cref="IBlocklistService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBlocklistServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBlocklistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Blocklist::ICustomerServiceWithRawResponse Customers { get; }
}
