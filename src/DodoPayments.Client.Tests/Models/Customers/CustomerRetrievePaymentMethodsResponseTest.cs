using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerRetrievePaymentMethodsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerRetrievePaymentMethodsResponse
        {
            Items =
            [
                new()
                {
                    PaymentMethod = PaymentMethod.Card,
                    PaymentMethodID = "payment_method_id",
                    Card = new()
                    {
                        CardIssuingCountry = CountryCode.Af,
                        CardNetwork = "card_network",
                        CardType = "card_type",
                        ExpiryMonth = "expiry_month",
                        ExpiryYear = "expiry_year",
                        Last4Digits = "last4_digits",
                    },
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentMethodType = Payments::PaymentMethodTypes.Credit,
                    RecurringEnabled = true,
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                PaymentMethod = PaymentMethod.Card,
                PaymentMethodID = "payment_method_id",
                Card = new()
                {
                    CardIssuingCountry = CountryCode.Af,
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    ExpiryMonth = "expiry_month",
                    ExpiryYear = "expiry_year",
                    Last4Digits = "last4_digits",
                },
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodType = Payments::PaymentMethodTypes.Credit,
                RecurringEnabled = true,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
            Card = new()
            {
                CardIssuingCountry = CountryCode.Af,
                CardNetwork = "card_network",
                CardType = "card_type",
                ExpiryMonth = "expiry_month",
                ExpiryYear = "expiry_year",
                Last4Digits = "last4_digits",
            },
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodType = Payments::PaymentMethodTypes.Credit,
            RecurringEnabled = true,
        };

        ApiEnum<string, PaymentMethod> expectedPaymentMethod = PaymentMethod.Card;
        string expectedPaymentMethodID = "payment_method_id";
        Card expectedCard = new()
        {
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Payments::PaymentMethodTypes> expectedPaymentMethodType =
            Payments::PaymentMethodTypes.Credit;
        bool expectedRecurringEnabled = true;

        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedCard, model.Card);
        Assert.Equal(expectedLastUsedAt, model.LastUsedAt);
        Assert.Equal(expectedPaymentMethodType, model.PaymentMethodType);
        Assert.Equal(expectedRecurringEnabled, model.RecurringEnabled);
    }
}

public class CardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Card
        {
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };

        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedExpiryMonth = "expiry_month";
        string expectedExpiryYear = "expiry_year";
        string expectedLast4Digits = "last4_digits";

        Assert.Equal(expectedCardIssuingCountry, model.CardIssuingCountry);
        Assert.Equal(expectedCardNetwork, model.CardNetwork);
        Assert.Equal(expectedCardType, model.CardType);
        Assert.Equal(expectedExpiryMonth, model.ExpiryMonth);
        Assert.Equal(expectedExpiryYear, model.ExpiryYear);
        Assert.Equal(expectedLast4Digits, model.Last4Digits);
    }
}
