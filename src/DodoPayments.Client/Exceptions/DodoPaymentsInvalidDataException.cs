using System;

namespace DodoPayments.Client.Exceptions;

public class DodoPaymentsInvalidDataException : DodoPaymentsException
{
    public DodoPaymentsInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
