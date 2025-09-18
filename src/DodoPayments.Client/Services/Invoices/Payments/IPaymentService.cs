using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices.Payments;

public interface IPaymentService
{
    Task<JsonElement> Retrieve(PaymentRetrieveParams parameters);

    Task<JsonElement> RetrieveRefund(PaymentRetrieveRefundParams parameters);
}
