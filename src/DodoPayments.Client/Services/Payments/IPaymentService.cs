using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services.Payments;

public interface IPaymentService
{
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<PaymentCreateResponse> Create(PaymentCreateParams parameters);

    Task<Payment> Retrieve(PaymentRetrieveParams parameters);

    Task<PaymentListPageResponse> List(PaymentListParams? parameters = null);

    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters
    );
}
