using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPayments4xxException : DodoPaymentsApiException
{
    public DodoPayments4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
