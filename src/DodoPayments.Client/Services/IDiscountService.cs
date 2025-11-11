using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services;

public interface IDiscountService
{
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

    /// <summary>
    /// PATCH /discounts/{discount_id}
    /// </summary>
    Task<Discount> Update(
        DiscountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GET /discounts
    /// </summary>
    Task<DiscountListPageResponse> List(
        DiscountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// DELETE /discounts/{discount_id}
    /// </summary>
    Task Delete(DiscountDeleteParams parameters, CancellationToken cancellationToken = default);
}
