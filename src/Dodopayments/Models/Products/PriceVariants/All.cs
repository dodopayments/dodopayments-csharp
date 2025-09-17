using PriceProperties = Dodopayments.Models.Products.PriceProperties;

namespace Dodopayments.Models.Products.PriceVariants;

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

/// <summary>
/// Usage Based price details.
/// </summary>
public sealed record class UsageBasedPrice(PriceProperties::UsageBasedPrice Value)
    : Price,
        IVariant<UsageBasedPrice, PriceProperties::UsageBasedPrice>
{
    public static UsageBasedPrice From(PriceProperties::UsageBasedPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
