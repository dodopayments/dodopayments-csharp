using System.Threading.Tasks;
using DodoPayments.Models.Payments;

namespace DodoPayments.Services.Payments;

public interface IPaymentService
{
    Task<PaymentCreateResponse> Create(PaymentCreateParams parameters);

    Task<Payment> Retrieve(PaymentRetrieveParams parameters);

    Task<PaymentListPageResponse> List(PaymentListParams parameters);

    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters
    );
}
