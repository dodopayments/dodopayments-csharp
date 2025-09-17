using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Products.PriceProperties.UsageBasedPriceProperties;

[JsonConverter(typeof(Client::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Client::IEnum<Type, string>
{
    public static readonly Type UsageBasedPrice = new("usage_based_price");

    readonly string _value = value;

    public enum Value
    {
        UsageBasedPrice,
    }

    public Value Known() =>
        _value switch
        {
            "usage_based_price" => Value.UsageBasedPrice,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
