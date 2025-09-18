namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties.ValueVariants;

public sealed record class String(string Value) : Value, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : Value, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : Value, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
