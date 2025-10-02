using System;
using System.Net;
using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsApiException : DodoPaymentsException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public DodoPaymentsApiException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }

    protected DodoPaymentsApiException(HttpRequestException? innerException)
        : base(innerException) { }

    public required HttpStatusCode StatusCode { get; init; }

    public required string ResponseBody { get; init; }

    public override string Message
    {
        get { return string.Format("Status Code: {0}\n{1}", StatusCode, ResponseBody); }
    }
}
