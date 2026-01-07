using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentMethodTypesTest : TestBase
{
    [Theory]
    [InlineData(PaymentMethodTypes.Ach)]
    [InlineData(PaymentMethodTypes.Affirm)]
    [InlineData(PaymentMethodTypes.AfterpayClearpay)]
    [InlineData(PaymentMethodTypes.Alfamart)]
    [InlineData(PaymentMethodTypes.AliPay)]
    [InlineData(PaymentMethodTypes.AliPayHk)]
    [InlineData(PaymentMethodTypes.Alma)]
    [InlineData(PaymentMethodTypes.AmazonPay)]
    [InlineData(PaymentMethodTypes.ApplePay)]
    [InlineData(PaymentMethodTypes.Atome)]
    [InlineData(PaymentMethodTypes.Bacs)]
    [InlineData(PaymentMethodTypes.BancontactCard)]
    [InlineData(PaymentMethodTypes.Becs)]
    [InlineData(PaymentMethodTypes.Benefit)]
    [InlineData(PaymentMethodTypes.Bizum)]
    [InlineData(PaymentMethodTypes.Blik)]
    [InlineData(PaymentMethodTypes.Boleto)]
    [InlineData(PaymentMethodTypes.BcaBankTransfer)]
    [InlineData(PaymentMethodTypes.BniVa)]
    [InlineData(PaymentMethodTypes.BriVa)]
    [InlineData(PaymentMethodTypes.CardRedirect)]
    [InlineData(PaymentMethodTypes.CimbVa)]
    [InlineData(PaymentMethodTypes.Classic)]
    [InlineData(PaymentMethodTypes.Credit)]
    [InlineData(PaymentMethodTypes.CryptoCurrency)]
    [InlineData(PaymentMethodTypes.Cashapp)]
    [InlineData(PaymentMethodTypes.Dana)]
    [InlineData(PaymentMethodTypes.DanamonVa)]
    [InlineData(PaymentMethodTypes.Debit)]
    [InlineData(PaymentMethodTypes.DuitNow)]
    [InlineData(PaymentMethodTypes.Efecty)]
    [InlineData(PaymentMethodTypes.Eft)]
    [InlineData(PaymentMethodTypes.Eps)]
    [InlineData(PaymentMethodTypes.Fps)]
    [InlineData(PaymentMethodTypes.Evoucher)]
    [InlineData(PaymentMethodTypes.Giropay)]
    [InlineData(PaymentMethodTypes.Givex)]
    [InlineData(PaymentMethodTypes.GooglePay)]
    [InlineData(PaymentMethodTypes.GoPay)]
    [InlineData(PaymentMethodTypes.Gcash)]
    [InlineData(PaymentMethodTypes.Ideal)]
    [InlineData(PaymentMethodTypes.Interac)]
    [InlineData(PaymentMethodTypes.Indomaret)]
    [InlineData(PaymentMethodTypes.Klarna)]
    [InlineData(PaymentMethodTypes.KakaoPay)]
    [InlineData(PaymentMethodTypes.LocalBankRedirect)]
    [InlineData(PaymentMethodTypes.MandiriVa)]
    [InlineData(PaymentMethodTypes.Knet)]
    [InlineData(PaymentMethodTypes.MBWay)]
    [InlineData(PaymentMethodTypes.MobilePay)]
    [InlineData(PaymentMethodTypes.Momo)]
    [InlineData(PaymentMethodTypes.MomoAtm)]
    [InlineData(PaymentMethodTypes.Multibanco)]
    [InlineData(PaymentMethodTypes.OnlineBankingThailand)]
    [InlineData(PaymentMethodTypes.OnlineBankingCzechRepublic)]
    [InlineData(PaymentMethodTypes.OnlineBankingFinland)]
    [InlineData(PaymentMethodTypes.OnlineBankingFpx)]
    [InlineData(PaymentMethodTypes.OnlineBankingPoland)]
    [InlineData(PaymentMethodTypes.OnlineBankingSlovakia)]
    [InlineData(PaymentMethodTypes.Oxxo)]
    [InlineData(PaymentMethodTypes.PagoEfectivo)]
    [InlineData(PaymentMethodTypes.PermataBankTransfer)]
    [InlineData(PaymentMethodTypes.OpenBankingUk)]
    [InlineData(PaymentMethodTypes.PayBright)]
    [InlineData(PaymentMethodTypes.Paypal)]
    [InlineData(PaymentMethodTypes.Paze)]
    [InlineData(PaymentMethodTypes.Pix)]
    [InlineData(PaymentMethodTypes.PaySafeCard)]
    [InlineData(PaymentMethodTypes.Przelewy24)]
    [InlineData(PaymentMethodTypes.PromptPay)]
    [InlineData(PaymentMethodTypes.Pse)]
    [InlineData(PaymentMethodTypes.RedCompra)]
    [InlineData(PaymentMethodTypes.RedPagos)]
    [InlineData(PaymentMethodTypes.SamsungPay)]
    [InlineData(PaymentMethodTypes.Sepa)]
    [InlineData(PaymentMethodTypes.SepaBankTransfer)]
    [InlineData(PaymentMethodTypes.Sofort)]
    [InlineData(PaymentMethodTypes.Swish)]
    [InlineData(PaymentMethodTypes.TouchNGo)]
    [InlineData(PaymentMethodTypes.Trustly)]
    [InlineData(PaymentMethodTypes.Twint)]
    [InlineData(PaymentMethodTypes.UpiCollect)]
    [InlineData(PaymentMethodTypes.UpiIntent)]
    [InlineData(PaymentMethodTypes.Vipps)]
    [InlineData(PaymentMethodTypes.VietQr)]
    [InlineData(PaymentMethodTypes.Venmo)]
    [InlineData(PaymentMethodTypes.Walley)]
    [InlineData(PaymentMethodTypes.WeChatPay)]
    [InlineData(PaymentMethodTypes.SevenEleven)]
    [InlineData(PaymentMethodTypes.Lawson)]
    [InlineData(PaymentMethodTypes.MiniStop)]
    [InlineData(PaymentMethodTypes.FamilyMart)]
    [InlineData(PaymentMethodTypes.Seicomart)]
    [InlineData(PaymentMethodTypes.PayEasy)]
    [InlineData(PaymentMethodTypes.LocalBankTransfer)]
    [InlineData(PaymentMethodTypes.Mifinity)]
    [InlineData(PaymentMethodTypes.OpenBankingPis)]
    [InlineData(PaymentMethodTypes.DirectCarrierBilling)]
    [InlineData(PaymentMethodTypes.InstantBankTransfer)]
    [InlineData(PaymentMethodTypes.Billie)]
    [InlineData(PaymentMethodTypes.Zip)]
    [InlineData(PaymentMethodTypes.RevolutPay)]
    [InlineData(PaymentMethodTypes.NaverPay)]
    [InlineData(PaymentMethodTypes.Payco)]
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
    [InlineData(PaymentMethodTypes.Ach)]
    [InlineData(PaymentMethodTypes.Affirm)]
    [InlineData(PaymentMethodTypes.AfterpayClearpay)]
    [InlineData(PaymentMethodTypes.Alfamart)]
    [InlineData(PaymentMethodTypes.AliPay)]
    [InlineData(PaymentMethodTypes.AliPayHk)]
    [InlineData(PaymentMethodTypes.Alma)]
    [InlineData(PaymentMethodTypes.AmazonPay)]
    [InlineData(PaymentMethodTypes.ApplePay)]
    [InlineData(PaymentMethodTypes.Atome)]
    [InlineData(PaymentMethodTypes.Bacs)]
    [InlineData(PaymentMethodTypes.BancontactCard)]
    [InlineData(PaymentMethodTypes.Becs)]
    [InlineData(PaymentMethodTypes.Benefit)]
    [InlineData(PaymentMethodTypes.Bizum)]
    [InlineData(PaymentMethodTypes.Blik)]
    [InlineData(PaymentMethodTypes.Boleto)]
    [InlineData(PaymentMethodTypes.BcaBankTransfer)]
    [InlineData(PaymentMethodTypes.BniVa)]
    [InlineData(PaymentMethodTypes.BriVa)]
    [InlineData(PaymentMethodTypes.CardRedirect)]
    [InlineData(PaymentMethodTypes.CimbVa)]
    [InlineData(PaymentMethodTypes.Classic)]
    [InlineData(PaymentMethodTypes.Credit)]
    [InlineData(PaymentMethodTypes.CryptoCurrency)]
    [InlineData(PaymentMethodTypes.Cashapp)]
    [InlineData(PaymentMethodTypes.Dana)]
    [InlineData(PaymentMethodTypes.DanamonVa)]
    [InlineData(PaymentMethodTypes.Debit)]
    [InlineData(PaymentMethodTypes.DuitNow)]
    [InlineData(PaymentMethodTypes.Efecty)]
    [InlineData(PaymentMethodTypes.Eft)]
    [InlineData(PaymentMethodTypes.Eps)]
    [InlineData(PaymentMethodTypes.Fps)]
    [InlineData(PaymentMethodTypes.Evoucher)]
    [InlineData(PaymentMethodTypes.Giropay)]
    [InlineData(PaymentMethodTypes.Givex)]
    [InlineData(PaymentMethodTypes.GooglePay)]
    [InlineData(PaymentMethodTypes.GoPay)]
    [InlineData(PaymentMethodTypes.Gcash)]
    [InlineData(PaymentMethodTypes.Ideal)]
    [InlineData(PaymentMethodTypes.Interac)]
    [InlineData(PaymentMethodTypes.Indomaret)]
    [InlineData(PaymentMethodTypes.Klarna)]
    [InlineData(PaymentMethodTypes.KakaoPay)]
    [InlineData(PaymentMethodTypes.LocalBankRedirect)]
    [InlineData(PaymentMethodTypes.MandiriVa)]
    [InlineData(PaymentMethodTypes.Knet)]
    [InlineData(PaymentMethodTypes.MBWay)]
    [InlineData(PaymentMethodTypes.MobilePay)]
    [InlineData(PaymentMethodTypes.Momo)]
    [InlineData(PaymentMethodTypes.MomoAtm)]
    [InlineData(PaymentMethodTypes.Multibanco)]
    [InlineData(PaymentMethodTypes.OnlineBankingThailand)]
    [InlineData(PaymentMethodTypes.OnlineBankingCzechRepublic)]
    [InlineData(PaymentMethodTypes.OnlineBankingFinland)]
    [InlineData(PaymentMethodTypes.OnlineBankingFpx)]
    [InlineData(PaymentMethodTypes.OnlineBankingPoland)]
    [InlineData(PaymentMethodTypes.OnlineBankingSlovakia)]
    [InlineData(PaymentMethodTypes.Oxxo)]
    [InlineData(PaymentMethodTypes.PagoEfectivo)]
    [InlineData(PaymentMethodTypes.PermataBankTransfer)]
    [InlineData(PaymentMethodTypes.OpenBankingUk)]
    [InlineData(PaymentMethodTypes.PayBright)]
    [InlineData(PaymentMethodTypes.Paypal)]
    [InlineData(PaymentMethodTypes.Paze)]
    [InlineData(PaymentMethodTypes.Pix)]
    [InlineData(PaymentMethodTypes.PaySafeCard)]
    [InlineData(PaymentMethodTypes.Przelewy24)]
    [InlineData(PaymentMethodTypes.PromptPay)]
    [InlineData(PaymentMethodTypes.Pse)]
    [InlineData(PaymentMethodTypes.RedCompra)]
    [InlineData(PaymentMethodTypes.RedPagos)]
    [InlineData(PaymentMethodTypes.SamsungPay)]
    [InlineData(PaymentMethodTypes.Sepa)]
    [InlineData(PaymentMethodTypes.SepaBankTransfer)]
    [InlineData(PaymentMethodTypes.Sofort)]
    [InlineData(PaymentMethodTypes.Swish)]
    [InlineData(PaymentMethodTypes.TouchNGo)]
    [InlineData(PaymentMethodTypes.Trustly)]
    [InlineData(PaymentMethodTypes.Twint)]
    [InlineData(PaymentMethodTypes.UpiCollect)]
    [InlineData(PaymentMethodTypes.UpiIntent)]
    [InlineData(PaymentMethodTypes.Vipps)]
    [InlineData(PaymentMethodTypes.VietQr)]
    [InlineData(PaymentMethodTypes.Venmo)]
    [InlineData(PaymentMethodTypes.Walley)]
    [InlineData(PaymentMethodTypes.WeChatPay)]
    [InlineData(PaymentMethodTypes.SevenEleven)]
    [InlineData(PaymentMethodTypes.Lawson)]
    [InlineData(PaymentMethodTypes.MiniStop)]
    [InlineData(PaymentMethodTypes.FamilyMart)]
    [InlineData(PaymentMethodTypes.Seicomart)]
    [InlineData(PaymentMethodTypes.PayEasy)]
    [InlineData(PaymentMethodTypes.LocalBankTransfer)]
    [InlineData(PaymentMethodTypes.Mifinity)]
    [InlineData(PaymentMethodTypes.OpenBankingPis)]
    [InlineData(PaymentMethodTypes.DirectCarrierBilling)]
    [InlineData(PaymentMethodTypes.InstantBankTransfer)]
    [InlineData(PaymentMethodTypes.Billie)]
    [InlineData(PaymentMethodTypes.Zip)]
    [InlineData(PaymentMethodTypes.RevolutPay)]
    [InlineData(PaymentMethodTypes.NaverPay)]
    [InlineData(PaymentMethodTypes.Payco)]
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
