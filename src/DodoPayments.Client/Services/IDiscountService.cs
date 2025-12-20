using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDiscountService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDiscountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// POST /discounts If `code` is omitted or empty, a random 16-char uppercase
    /// code is generated.
    /// </summary>
    Task<Discount> Create(
        DiscountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GET /discounts/{discount_id}
    /// </summary>
    Task<Discount> Retrieve(
        DiscountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DiscountRetrieveParams, CancellationToken)"/>
    Task<Discount> Retrieve(
        string discountID,
        DiscountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// PATCH /discounts/{discount_id}
    /// </summary>
    Task<Discount> Update(
        DiscountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DiscountUpdateParams, CancellationToken)"/>
    Task<Discount> Update(
        string discountID,
        DiscountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GET /discounts
    /// </summary>
    Task<DiscountListPage> List(
        DiscountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// DELETE /discounts/{discount_id}
    /// </summary>
    Task Delete(DiscountDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DiscountDeleteParams, CancellationToken)"/>
    Task Delete(
        string discountID,
        DiscountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
