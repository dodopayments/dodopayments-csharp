using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsBadRequestException : DodoPayments4xxException
{
    public DodoPaymentsBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
