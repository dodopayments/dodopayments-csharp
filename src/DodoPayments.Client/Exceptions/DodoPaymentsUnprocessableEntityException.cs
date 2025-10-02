using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsUnprocessableEntityException : DodoPayments4xxException
{
    public DodoPaymentsUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
