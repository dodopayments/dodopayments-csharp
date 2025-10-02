using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPayments5xxException : DodoPaymentsApiException
{
    public DodoPayments5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
