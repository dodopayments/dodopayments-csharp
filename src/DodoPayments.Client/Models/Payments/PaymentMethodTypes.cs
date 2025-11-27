using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(PaymentMethodTypesConverter))]
public enum PaymentMethodTypes
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
    Paypal,
    Affirm,
    Klarna,
    Sepa,
    ACH,
    AmazonPay,
    AfterpayClearpay,
}

sealed class PaymentMethodTypesConverter : JsonConverter<PaymentMethodTypes>
{
    public override PaymentMethodTypes Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => PaymentMethodTypes.Credit,
            "debit" => PaymentMethodTypes.Debit,
            "upi_collect" => PaymentMethodTypes.UpiCollect,
            "upi_intent" => PaymentMethodTypes.UpiIntent,
            "apple_pay" => PaymentMethodTypes.ApplePay,
            "cashapp" => PaymentMethodTypes.Cashapp,
            "google_pay" => PaymentMethodTypes.GooglePay,
            "multibanco" => PaymentMethodTypes.Multibanco,
            "bancontact_card" => PaymentMethodTypes.BancontactCard,
            "eps" => PaymentMethodTypes.Eps,
            "ideal" => PaymentMethodTypes.Ideal,
            "przelewy24" => PaymentMethodTypes.Przelewy24,
            "paypal" => PaymentMethodTypes.Paypal,
            "affirm" => PaymentMethodTypes.Affirm,
            "klarna" => PaymentMethodTypes.Klarna,
            "sepa" => PaymentMethodTypes.Sepa,
            "ach" => PaymentMethodTypes.ACH,
            "amazon_pay" => PaymentMethodTypes.AmazonPay,
            "afterpay_clearpay" => PaymentMethodTypes.AfterpayClearpay,
            _ => (PaymentMethodTypes)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentMethodTypes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentMethodTypes.Credit => "credit",
                PaymentMethodTypes.Debit => "debit",
                PaymentMethodTypes.UpiCollect => "upi_collect",
                PaymentMethodTypes.UpiIntent => "upi_intent",
                PaymentMethodTypes.ApplePay => "apple_pay",
                PaymentMethodTypes.Cashapp => "cashapp",
                PaymentMethodTypes.GooglePay => "google_pay",
                PaymentMethodTypes.Multibanco => "multibanco",
                PaymentMethodTypes.BancontactCard => "bancontact_card",
                PaymentMethodTypes.Eps => "eps",
                PaymentMethodTypes.Ideal => "ideal",
                PaymentMethodTypes.Przelewy24 => "przelewy24",
                PaymentMethodTypes.Paypal => "paypal",
                PaymentMethodTypes.Affirm => "affirm",
                PaymentMethodTypes.Klarna => "klarna",
                PaymentMethodTypes.Sepa => "sepa",
                PaymentMethodTypes.ACH => "ach",
                PaymentMethodTypes.AmazonPay => "amazon_pay",
                PaymentMethodTypes.AfterpayClearpay => "afterpay_clearpay",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
