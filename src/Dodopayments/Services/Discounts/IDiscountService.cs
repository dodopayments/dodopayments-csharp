using System.Threading.Tasks;
using Dodopayments.Models.Discounts;

namespace Dodopayments.Services.Discounts;

public interface IDiscountService
{
    /// <summary>
    /// POST /discounts If `code` is omitted or empty, a random 16-char uppercase
    /// code is generated.
    /// </summary>
    Task<Discount> Create(DiscountCreateParams parameters);

    /// <summary>
    /// GET /discounts/{discount_id}
    /// </summary>
    Task<Discount> Retrieve(DiscountRetrieveParams parameters);

    /// <summary>
    /// PATCH /discounts/{discount_id}
    /// </summary>
    Task<Discount> Update(DiscountUpdateParams parameters);

    /// <summary>
    /// GET /discounts
    /// </summary>
    Task<DiscountListPageResponse> List(DiscountListParams parameters);

    /// <summary>
    /// DELETE /discounts/{discount_id}
    /// </summary>
    Task Delete(DiscountDeleteParams parameters);
}
