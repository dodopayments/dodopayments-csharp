using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsUnauthorizedException : DodoPayments4xxException
{
    public DodoPaymentsUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
