using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Invoices.Payments;

namespace DodoPayments.Services.Invoices.Payments;

public interface IPaymentService
{
    Task<JsonElement> Retrieve(PaymentRetrieveParams parameters);
}
