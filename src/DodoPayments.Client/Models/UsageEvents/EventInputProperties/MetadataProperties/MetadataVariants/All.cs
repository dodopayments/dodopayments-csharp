using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents.EventInputProperties.MetadataProperties.MetadataVariants;

public sealed record class String(string Value) : Metadata, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Number(double Value) : Metadata, IVariant<Number, double>
{
    public static Number From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Boolean(bool Value) : Metadata, IVariant<Boolean, bool>
{
    public static Boolean From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
