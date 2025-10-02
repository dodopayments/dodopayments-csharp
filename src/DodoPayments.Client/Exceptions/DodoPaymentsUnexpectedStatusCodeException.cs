using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsUnexpectedStatusCodeException : DodoPaymentsApiException
{
    public DodoPaymentsUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
