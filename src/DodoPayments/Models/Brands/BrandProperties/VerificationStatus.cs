using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Brands.BrandProperties;

[JsonConverter(typeof(DodoPayments::EnumConverter<VerificationStatus, string>))]
public sealed record class VerificationStatus(string value)
    : DodoPayments::IEnum<VerificationStatus, string>
{
    public static readonly VerificationStatus Success = new("Success");

    public static readonly VerificationStatus Fail = new("Fail");

    public static readonly VerificationStatus Review = new("Review");

    public static readonly VerificationStatus Hold = new("Hold");

    readonly string _value = value;

    public enum Value
    {
        Success,
        Fail,
        Review,
        Hold,
    }

    public Value Known() =>
        _value switch
        {
            "Success" => Value.Success,
            "Fail" => Value.Fail,
            "Review" => Value.Review,
            "Hold" => Value.Hold,
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

    public static VerificationStatus FromRaw(string value)
    {
        return new(value);
    }
}
