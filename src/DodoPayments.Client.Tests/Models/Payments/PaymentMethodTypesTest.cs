using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentMethodTypesTest : TestBase
{
    [Theory]
    [InlineData(PaymentMethodTypes.Credit)]
    [InlineData(PaymentMethodTypes.Debit)]
    [InlineData(PaymentMethodTypes.UpiCollect)]
    [InlineData(PaymentMethodTypes.UpiIntent)]
    [InlineData(PaymentMethodTypes.ApplePay)]
    [InlineData(PaymentMethodTypes.Cashapp)]
    [InlineData(PaymentMethodTypes.GooglePay)]
    [InlineData(PaymentMethodTypes.Multibanco)]
    [InlineData(PaymentMethodTypes.BancontactCard)]
    [InlineData(PaymentMethodTypes.Eps)]
    [InlineData(PaymentMethodTypes.Ideal)]
    [InlineData(PaymentMethodTypes.Przelewy24)]
    [InlineData(PaymentMethodTypes.Paypal)]
    [InlineData(PaymentMethodTypes.Affirm)]
    [InlineData(PaymentMethodTypes.Klarna)]
    [InlineData(PaymentMethodTypes.Sepa)]
    [InlineData(PaymentMethodTypes.ACH)]
    [InlineData(PaymentMethodTypes.AmazonPay)]
    [InlineData(PaymentMethodTypes.AfterpayClearpay)]
    public void Validation_Works(PaymentMethodTypes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentMethodTypes> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethodTypes>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentMethodTypes.Credit)]
    [InlineData(PaymentMethodTypes.Debit)]
    [InlineData(PaymentMethodTypes.UpiCollect)]
    [InlineData(PaymentMethodTypes.UpiIntent)]
    [InlineData(PaymentMethodTypes.ApplePay)]
    [InlineData(PaymentMethodTypes.Cashapp)]
    [InlineData(PaymentMethodTypes.GooglePay)]
    [InlineData(PaymentMethodTypes.Multibanco)]
    [InlineData(PaymentMethodTypes.BancontactCard)]
    [InlineData(PaymentMethodTypes.Eps)]
    [InlineData(PaymentMethodTypes.Ideal)]
    [InlineData(PaymentMethodTypes.Przelewy24)]
    [InlineData(PaymentMethodTypes.Paypal)]
    [InlineData(PaymentMethodTypes.Affirm)]
    [InlineData(PaymentMethodTypes.Klarna)]
    [InlineData(PaymentMethodTypes.Sepa)]
    [InlineData(PaymentMethodTypes.ACH)]
    [InlineData(PaymentMethodTypes.AmazonPay)]
    [InlineData(PaymentMethodTypes.AfterpayClearpay)]
    public void SerializationRoundtrip_Works(PaymentMethodTypes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentMethodTypes> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethodTypes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethodTypes>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethodTypes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
