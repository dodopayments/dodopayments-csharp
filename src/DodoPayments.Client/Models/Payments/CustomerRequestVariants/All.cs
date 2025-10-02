using DodoPayments.Client.Core;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Payments.CustomerRequestVariants;

public sealed record class AttachExistingCustomer(Payments::AttachExistingCustomer Value)
    : Payments::CustomerRequest,
        IVariant<AttachExistingCustomer, Payments::AttachExistingCustomer>
{
    public static AttachExistingCustomer From(Payments::AttachExistingCustomer value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewCustomer(Payments::NewCustomer Value)
    : Payments::CustomerRequest,
        IVariant<NewCustomer, Payments::NewCustomer>
{
    public static NewCustomer From(Payments::NewCustomer value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
