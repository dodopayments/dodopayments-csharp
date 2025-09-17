using DataProperties = Dodopayments.Models.WebhookEvents.WebhookPayloadProperties.DataProperties;

namespace Dodopayments.Models.WebhookEvents.WebhookPayloadProperties.DataVariants;

public sealed record class Payment(DataProperties::Payment Value)
    : Data,
        IVariant<Payment, DataProperties::Payment>
{
    public static Payment From(DataProperties::Payment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Response struct representing subscription details
/// </summary>
public sealed record class Subscription(DataProperties::Subscription Value)
    : Data,
        IVariant<Subscription, DataProperties::Subscription>
{
    public static Subscription From(DataProperties::Subscription value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Refund(DataProperties::Refund Value)
    : Data,
        IVariant<Refund, DataProperties::Refund>
{
    public static Refund From(DataProperties::Refund value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Dispute(DataProperties::Dispute Value)
    : Data,
        IVariant<Dispute, DataProperties::Dispute>
{
    public static Dispute From(DataProperties::Dispute value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class LicenseKey(DataProperties::LicenseKey Value)
    : Data,
        IVariant<LicenseKey, DataProperties::LicenseKey>
{
    public static LicenseKey From(DataProperties::LicenseKey value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
