using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsRateLimitException : DodoPayments4xxException
{
    public DodoPaymentsRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
