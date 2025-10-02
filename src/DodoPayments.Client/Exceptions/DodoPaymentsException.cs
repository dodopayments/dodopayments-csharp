using System;
using System.Net.Http;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsException : Exception
{
    public DodoPaymentsException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected DodoPaymentsException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
