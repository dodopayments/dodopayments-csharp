using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
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
                        CardHolderName = "card_holder_name",
                        CardIssuingCountry = CountryCode.Af,
                        CardNetwork = "card_network",
                        CardType = "card_type",
                        ExpiryMonth = "expiry_month",
                        ExpiryYear = "expiry_year",
                        Last4Digits = "last4_digits",
                    },
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentMethodType = Payments::PaymentMethodTypes.Ach,
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
                    CardHolderName = "card_holder_name",
                    CardIssuingCountry = CountryCode.Af,
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    ExpiryMonth = "expiry_month",
                    ExpiryYear = "expiry_year",
                    Last4Digits = "last4_digits",
                },
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodType = Payments::PaymentMethodTypes.Ach,
                RecurringEnabled = true,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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
                        CardHolderName = "card_holder_name",
                        CardIssuingCountry = CountryCode.Af,
                        CardNetwork = "card_network",
                        CardType = "card_type",
                        ExpiryMonth = "expiry_month",
                        ExpiryYear = "expiry_year",
                        Last4Digits = "last4_digits",
                    },
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentMethodType = Payments::PaymentMethodTypes.Ach,
                    RecurringEnabled = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrievePaymentMethodsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                        CardHolderName = "card_holder_name",
                        CardIssuingCountry = CountryCode.Af,
                        CardNetwork = "card_network",
                        CardType = "card_type",
                        ExpiryMonth = "expiry_month",
                        ExpiryYear = "expiry_year",
                        Last4Digits = "last4_digits",
                    },
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentMethodType = Payments::PaymentMethodTypes.Ach,
                    RecurringEnabled = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrievePaymentMethodsResponse>(
            element
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                PaymentMethod = PaymentMethod.Card,
                PaymentMethodID = "payment_method_id",
                Card = new()
                {
                    CardHolderName = "card_holder_name",
                    CardIssuingCountry = CountryCode.Af,
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    ExpiryMonth = "expiry_month",
                    ExpiryYear = "expiry_year",
                    Last4Digits = "last4_digits",
                },
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodType = Payments::PaymentMethodTypes.Ach,
                RecurringEnabled = true,
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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
                        CardHolderName = "card_holder_name",
                        CardIssuingCountry = CountryCode.Af,
                        CardNetwork = "card_network",
                        CardType = "card_type",
                        ExpiryMonth = "expiry_month",
                        ExpiryYear = "expiry_year",
                        Last4Digits = "last4_digits",
                    },
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentMethodType = Payments::PaymentMethodTypes.Ach,
                    RecurringEnabled = true,
                },
            ],
        };

        model.Validate();
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
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardNetwork = "card_network",
                CardType = "card_type",
                ExpiryMonth = "expiry_month",
                ExpiryYear = "expiry_year",
                Last4Digits = "last4_digits",
            },
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodType = Payments::PaymentMethodTypes.Ach,
            RecurringEnabled = true,
        };

        ApiEnum<string, PaymentMethod> expectedPaymentMethod = PaymentMethod.Card;
        string expectedPaymentMethodID = "payment_method_id";
        Card expectedCard = new()
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Payments::PaymentMethodTypes> expectedPaymentMethodType =
            Payments::PaymentMethodTypes.Ach;
        bool expectedRecurringEnabled = true;

        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedCard, model.Card);
        Assert.Equal(expectedLastUsedAt, model.LastUsedAt);
        Assert.Equal(expectedPaymentMethodType, model.PaymentMethodType);
        Assert.Equal(expectedRecurringEnabled, model.RecurringEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
            Card = new()
            {
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardNetwork = "card_network",
                CardType = "card_type",
                ExpiryMonth = "expiry_month",
                ExpiryYear = "expiry_year",
                Last4Digits = "last4_digits",
            },
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodType = Payments::PaymentMethodTypes.Ach,
            RecurringEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
            Card = new()
            {
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardNetwork = "card_network",
                CardType = "card_type",
                ExpiryMonth = "expiry_month",
                ExpiryYear = "expiry_year",
                Last4Digits = "last4_digits",
            },
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodType = Payments::PaymentMethodTypes.Ach,
            RecurringEnabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, PaymentMethod> expectedPaymentMethod = PaymentMethod.Card;
        string expectedPaymentMethodID = "payment_method_id";
        Card expectedCard = new()
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Payments::PaymentMethodTypes> expectedPaymentMethodType =
            Payments::PaymentMethodTypes.Ach;
        bool expectedRecurringEnabled = true;

        Assert.Equal(expectedPaymentMethod, deserialized.PaymentMethod);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedCard, deserialized.Card);
        Assert.Equal(expectedLastUsedAt, deserialized.LastUsedAt);
        Assert.Equal(expectedPaymentMethodType, deserialized.PaymentMethodType);
        Assert.Equal(expectedRecurringEnabled, deserialized.RecurringEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
            Card = new()
            {
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardNetwork = "card_network",
                CardType = "card_type",
                ExpiryMonth = "expiry_month",
                ExpiryYear = "expiry_year",
                Last4Digits = "last4_digits",
            },
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodType = Payments::PaymentMethodTypes.Ach,
            RecurringEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
        };

        Assert.Null(model.Card);
        Assert.False(model.RawData.ContainsKey("card"));
        Assert.Null(model.LastUsedAt);
        Assert.False(model.RawData.ContainsKey("last_used_at"));
        Assert.Null(model.PaymentMethodType);
        Assert.False(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.RecurringEnabled);
        Assert.False(model.RawData.ContainsKey("recurring_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",

            Card = null,
            LastUsedAt = null,
            PaymentMethodType = null,
            RecurringEnabled = null,
        };

        Assert.Null(model.Card);
        Assert.True(model.RawData.ContainsKey("card"));
        Assert.Null(model.LastUsedAt);
        Assert.True(model.RawData.ContainsKey("last_used_at"));
        Assert.Null(model.PaymentMethodType);
        Assert.True(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.RecurringEnabled);
        Assert.True(model.RawData.ContainsKey("recurring_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            PaymentMethod = PaymentMethod.Card,
            PaymentMethodID = "payment_method_id",

            Card = null,
            LastUsedAt = null,
            PaymentMethodType = null,
            RecurringEnabled = null,
        };

        model.Validate();
    }
}

public class PaymentMethodTest : TestBase
{
    [Theory]
    [InlineData(PaymentMethod.Card)]
    [InlineData(PaymentMethod.CardRedirect)]
    [InlineData(PaymentMethod.PayLater)]
    [InlineData(PaymentMethod.Wallet)]
    [InlineData(PaymentMethod.BankRedirect)]
    [InlineData(PaymentMethod.BankTransfer)]
    [InlineData(PaymentMethod.Crypto)]
    [InlineData(PaymentMethod.BankDebit)]
    [InlineData(PaymentMethod.Reward)]
    [InlineData(PaymentMethod.RealTimePayment)]
    [InlineData(PaymentMethod.Upi)]
    [InlineData(PaymentMethod.Voucher)]
    [InlineData(PaymentMethod.GiftCard)]
    [InlineData(PaymentMethod.OpenBanking)]
    [InlineData(PaymentMethod.MobilePayment)]
    public void Validation_Works(PaymentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethod>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentMethod.Card)]
    [InlineData(PaymentMethod.CardRedirect)]
    [InlineData(PaymentMethod.PayLater)]
    [InlineData(PaymentMethod.Wallet)]
    [InlineData(PaymentMethod.BankRedirect)]
    [InlineData(PaymentMethod.BankTransfer)]
    [InlineData(PaymentMethod.Crypto)]
    [InlineData(PaymentMethod.BankDebit)]
    [InlineData(PaymentMethod.Reward)]
    [InlineData(PaymentMethod.RealTimePayment)]
    [InlineData(PaymentMethod.Upi)]
    [InlineData(PaymentMethod.Voucher)]
    [InlineData(PaymentMethod.GiftCard)]
    [InlineData(PaymentMethod.OpenBanking)]
    [InlineData(PaymentMethod.MobilePayment)]
    public void SerializationRoundtrip_Works(PaymentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethod>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Card
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };

        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedExpiryMonth = "expiry_month";
        string expectedExpiryYear = "expiry_year";
        string expectedLast4Digits = "last4_digits";

        Assert.Equal(expectedCardHolderName, model.CardHolderName);
        Assert.Equal(expectedCardIssuingCountry, model.CardIssuingCountry);
        Assert.Equal(expectedCardNetwork, model.CardNetwork);
        Assert.Equal(expectedCardType, model.CardType);
        Assert.Equal(expectedExpiryMonth, model.ExpiryMonth);
        Assert.Equal(expectedExpiryYear, model.ExpiryYear);
        Assert.Equal(expectedLast4Digits, model.Last4Digits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Card
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Card>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Card
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Card>(element);
        Assert.NotNull(deserialized);

        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedExpiryMonth = "expiry_month";
        string expectedExpiryYear = "expiry_year";
        string expectedLast4Digits = "last4_digits";

        Assert.Equal(expectedCardHolderName, deserialized.CardHolderName);
        Assert.Equal(expectedCardIssuingCountry, deserialized.CardIssuingCountry);
        Assert.Equal(expectedCardNetwork, deserialized.CardNetwork);
        Assert.Equal(expectedCardType, deserialized.CardType);
        Assert.Equal(expectedExpiryMonth, deserialized.ExpiryMonth);
        Assert.Equal(expectedExpiryYear, deserialized.ExpiryYear);
        Assert.Equal(expectedLast4Digits, deserialized.Last4Digits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Card
        {
            CardHolderName = "card_holder_name",
            CardIssuingCountry = CountryCode.Af,
            CardNetwork = "card_network",
            CardType = "card_type",
            ExpiryMonth = "expiry_month",
            ExpiryYear = "expiry_year",
            Last4Digits = "last4_digits",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Card { };

        Assert.Null(model.CardHolderName);
        Assert.False(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
        Assert.Null(model.CardNetwork);
        Assert.False(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.False(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.ExpiryMonth);
        Assert.False(model.RawData.ContainsKey("expiry_month"));
        Assert.Null(model.ExpiryYear);
        Assert.False(model.RawData.ContainsKey("expiry_year"));
        Assert.Null(model.Last4Digits);
        Assert.False(model.RawData.ContainsKey("last4_digits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Card { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Card
        {
            CardHolderName = null,
            CardIssuingCountry = null,
            CardNetwork = null,
            CardType = null,
            ExpiryMonth = null,
            ExpiryYear = null,
            Last4Digits = null,
        };

        Assert.Null(model.CardHolderName);
        Assert.True(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardIssuingCountry);
        Assert.True(model.RawData.ContainsKey("card_issuing_country"));
        Assert.Null(model.CardNetwork);
        Assert.True(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.True(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.ExpiryMonth);
        Assert.True(model.RawData.ContainsKey("expiry_month"));
        Assert.Null(model.ExpiryYear);
        Assert.True(model.RawData.ContainsKey("expiry_year"));
        Assert.Null(model.Last4Digits);
        Assert.True(model.RawData.ContainsKey("last4_digits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Card
        {
            CardHolderName = null,
            CardIssuingCountry = null,
            CardNetwork = null,
            CardType = null,
            ExpiryMonth = null,
            ExpiryYear = null,
            Last4Digits = null,
        };

        model.Validate();
    }
}
