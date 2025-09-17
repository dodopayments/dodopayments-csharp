using System.Threading.Tasks;
using Dodopayments.Models.Payments;

namespace Dodopayments.Services.Payments;

public interface IPaymentService
{
    Task<PaymentCreateResponse> Create(PaymentCreateParams parameters);

    Task<Payment> Retrieve(PaymentRetrieveParams parameters);

    Task<PaymentListPageResponse> List(PaymentListParams parameters);

    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters
    );
}
