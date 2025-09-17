using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties.CustomizationProperties;

/// <summary>
/// Theme of the page
///
/// Default is `System`.
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<Theme, string>))]
public sealed record class Theme(string value) : Client::IEnum<Theme, string>
{
    public static readonly Theme Dark = new("dark");

    public static readonly Theme Light = new("light");

    public static readonly Theme System = new("system");

    readonly string _value = value;

    public enum Value
    {
        Dark,
        Light,
        System,
    }

    public Value Known() =>
        _value switch
        {
            "dark" => Value.Dark,
            "light" => Value.Light,
            "system" => Value.System,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Theme FromRaw(string value)
    {
        return new(value);
    }
}
