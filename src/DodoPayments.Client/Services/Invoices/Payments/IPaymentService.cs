using System;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices.Payments;

public interface IPaymentService
{
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<JsonElement> Retrieve(PaymentRetrieveParams parameters);

    Task<JsonElement> RetrieveRefund(PaymentRetrieveRefundParams parameters);
}
