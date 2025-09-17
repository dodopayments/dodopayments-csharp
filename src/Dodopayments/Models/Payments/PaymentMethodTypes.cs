using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Payments;

[JsonConverter(typeof(Dodopayments::EnumConverter<PaymentMethodTypes, string>))]
public sealed record class PaymentMethodTypes(string value)
    : Dodopayments::IEnum<PaymentMethodTypes, string>
{
    public static readonly PaymentMethodTypes Credit = new("credit");

    public static readonly PaymentMethodTypes Debit = new("debit");

    public static readonly PaymentMethodTypes UpiCollect = new("upi_collect");

    public static readonly PaymentMethodTypes UpiIntent = new("upi_intent");

    public static readonly PaymentMethodTypes ApplePay = new("apple_pay");

    public static readonly PaymentMethodTypes Cashapp = new("cashapp");

    public static readonly PaymentMethodTypes GooglePay = new("google_pay");

    public static readonly PaymentMethodTypes Multibanco = new("multibanco");

    public static readonly PaymentMethodTypes BancontactCard = new("bancontact_card");

    public static readonly PaymentMethodTypes Eps = new("eps");

    public static readonly PaymentMethodTypes Ideal = new("ideal");

    public static readonly PaymentMethodTypes Przelewy24 = new("przelewy24");

    public static readonly PaymentMethodTypes Affirm = new("affirm");

    public static readonly PaymentMethodTypes Klarna = new("klarna");

    public static readonly PaymentMethodTypes Sepa = new("sepa");

    public static readonly PaymentMethodTypes ACH = new("ach");

    public static readonly PaymentMethodTypes AmazonPay = new("amazon_pay");

    public static readonly PaymentMethodTypes AfterpayClearpay = new("afterpay_clearpay");

    readonly string _value = value;

    public enum Value
    {
        Credit,
        Debit,
        UpiCollect,
        UpiIntent,
        ApplePay,
        Cashapp,
        GooglePay,
        Multibanco,
        BancontactCard,
        Eps,
        Ideal,
        Przelewy24,
        Affirm,
        Klarna,
        Sepa,
        ACH,
        AmazonPay,
        AfterpayClearpay,
    }

    public Value Known() =>
        _value switch
        {
            "credit" => Value.Credit,
            "debit" => Value.Debit,
            "upi_collect" => Value.UpiCollect,
            "upi_intent" => Value.UpiIntent,
            "apple_pay" => Value.ApplePay,
            "cashapp" => Value.Cashapp,
            "google_pay" => Value.GooglePay,
            "multibanco" => Value.Multibanco,
            "bancontact_card" => Value.BancontactCard,
            "eps" => Value.Eps,
            "ideal" => Value.Ideal,
            "przelewy24" => Value.Przelewy24,
            "affirm" => Value.Affirm,
            "klarna" => Value.Klarna,
            "sepa" => Value.Sepa,
            "ach" => Value.ACH,
            "amazon_pay" => Value.AmazonPay,
            "afterpay_clearpay" => Value.AfterpayClearpay,
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

    public static PaymentMethodTypes FromRaw(string value)
    {
        return new(value);
    }
}
