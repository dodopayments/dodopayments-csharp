using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsForbiddenException : DodoPayments4xxException
{
    public DodoPaymentsForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
