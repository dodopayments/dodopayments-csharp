using System;
using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsIOException : DodoPaymentsException
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

    public DodoPaymentsIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
