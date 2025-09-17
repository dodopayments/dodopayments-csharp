using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Payments.CustomerRequestVariants;

public sealed record class AttachExistingCustomerVariant(Payments::AttachExistingCustomer Value)
    : Payments::CustomerRequest,
        IVariant<AttachExistingCustomerVariant, Payments::AttachExistingCustomer>
{
    public static AttachExistingCustomerVariant From(Payments::AttachExistingCustomer value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewCustomerVariant(Payments::NewCustomer Value)
    : Payments::CustomerRequest,
        IVariant<NewCustomerVariant, Payments::NewCustomer>
{
    public static NewCustomerVariant From(Payments::NewCustomer value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
