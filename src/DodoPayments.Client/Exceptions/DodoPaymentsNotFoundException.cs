using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsNotFoundException : DodoPayments4xxException
{
    public DodoPaymentsNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
