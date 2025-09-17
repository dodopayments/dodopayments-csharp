using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Invoices.Payments;

namespace Dodopayments.Services.Invoices.Payments;

public interface IPaymentService
{
    Task<JsonElement> Retrieve(PaymentRetrieveParams parameters);

    Task<JsonElement> RetrieveRefund(PaymentRetrieveRefundParams parameters);
}
