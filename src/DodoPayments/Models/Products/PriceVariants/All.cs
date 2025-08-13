using PriceProperties = DodoPayments.Models.Products.PriceProperties;

namespace DodoPayments.Models.Products.PriceVariants;

/// <summary>
/// One-time price details.
/// </summary>
public sealed record class OneTimePrice(PriceProperties::OneTimePrice Value)
    : Price,
        IVariant<OneTimePrice, PriceProperties::OneTimePrice>
{
    public static OneTimePrice From(PriceProperties::OneTimePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Recurring price details.
/// </summary>
public sealed record class RecurringPrice(PriceProperties::RecurringPrice Value)
    : Price,
        IVariant<RecurringPrice, PriceProperties::RecurringPrice>
{
    public static RecurringPrice From(PriceProperties::RecurringPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
