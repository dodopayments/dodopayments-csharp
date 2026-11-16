using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Invoices = DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionStartTrialParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            PaymentMethodID = "payment_method_id",
            PaymentTerms = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt(),
            Quantity = 0,
            ReviewRequired = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,
            IdempotencyKey = "Idempotency-Key",
        };

        ApiEnum<string, Invoices::InvoiceCollectionMethod> expectedCollectionMethod =
            Invoices::InvoiceCollectionMethod.AutoCharge;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerID = "customer_id";
        string expectedProductID = "product_id";
        BillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        string expectedPaymentMethodID = "payment_method_id";
        SubscriptionStartTrialParamsPaymentTerms expectedPaymentTerms =
            new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt();
        int expectedQuantity = 0;
        bool expectedReviewRequired = true;
        string expectedTaxID = "tax_id";
        int expectedTrialPeriodDays = 0;
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedCollectionMethod, parameters.CollectionMethod);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
        Assert.Equal(expectedPaymentTerms, parameters.PaymentTerms);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedReviewRequired, parameters.ReviewRequired);
        Assert.Equal(expectedTaxID, parameters.TaxID);
        Assert.Equal(expectedTrialPeriodDays, parameters.TrialPeriodDays);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            PaymentMethodID = "payment_method_id",
            PaymentTerms = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt(),
            TaxID = "tax_id",
            TrialPeriodDays = 0,
        };

        Assert.Null(parameters.Quantity);
        Assert.False(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.ReviewRequired);
        Assert.False(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            PaymentMethodID = "payment_method_id",
            PaymentTerms = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt(),
            TaxID = "tax_id",
            TrialPeriodDays = 0,

            // Null should be interpreted as omitted for these properties
            Quantity = null,
            ReviewRequired = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Quantity);
        Assert.False(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.ReviewRequired);
        Assert.False(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            Quantity = 0,
            ReviewRequired = true,
            IdempotencyKey = "Idempotency-Key",
        };

        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.PaymentTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
        Assert.Null(parameters.TrialPeriodDays);
        Assert.False(parameters.RawBodyData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            Quantity = 0,
            ReviewRequired = true,
            IdempotencyKey = "Idempotency-Key",

            BillingAddress = null,
            PaymentMethodID = null,
            PaymentTerms = null,
            TaxID = null,
            TrialPeriodDays = null,
        };

        Assert.Null(parameters.BillingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.PaymentTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
        Assert.Null(parameters.TrialPeriodDays);
        Assert.True(parameters.RawBodyData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionStartTrialParams parameters = new()
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/billing/subscriptions"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SubscriptionStartTrialParams parameters = new()
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            IdempotencyKey = "Idempotency-Key",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["Idempotency-Key"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionStartTrialParams
        {
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            ProductID = "product_id",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            PaymentMethodID = "payment_method_id",
            PaymentTerms = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt(),
            Quantity = 0,
            ReviewRequired = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,
            IdempotencyKey = "Idempotency-Key",
        };

        SubscriptionStartTrialParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedCity = "city";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedZipcode, model.Zipcode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedCity = "city";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedZipcode, deserialized.Zipcode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingAddress { Country = CountryCode.Af };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.False(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingAddress { Country = CountryCode.Af };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,

            City = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.True(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,

            City = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionStartTrialParamsPaymentTermsTest : TestBase
{
    [Fact]
    public void DueOnReceiptValidationWorks()
    {
        SubscriptionStartTrialParamsPaymentTerms value =
            new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt();
        value.Validate();
    }

    [Fact]
    public void NetValidationWorks()
    {
        SubscriptionStartTrialParamsPaymentTerms value =
            new SubscriptionStartTrialParamsPaymentTermsNet(0);
        value.Validate();
    }

    [Fact]
    public void DueOnReceiptSerializationRoundtripWorks()
    {
        SubscriptionStartTrialParamsPaymentTerms value =
            new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NetSerializationRoundtripWorks()
    {
        SubscriptionStartTrialParamsPaymentTerms value =
            new SubscriptionStartTrialParamsPaymentTermsNet(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionStartTrialParamsPaymentTermsDueOnReceiptTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                JsonSerializer.Deserialize<JsonElement>(
                    """
                    {
                      "type": "due_on_receipt"
                    }
                    """
                ),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                JsonSerializer.Deserialize<JsonElement>(
                    """
                    {
                      "type": "due_on_receipt"
                    }
                    """
                ),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class SubscriptionStartTrialParamsPaymentTermsNetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionStartTrialParamsPaymentTermsNet { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionStartTrialParamsPaymentTermsNet { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsNet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionStartTrialParamsPaymentTermsNet { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsNet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, deserialized.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionStartTrialParamsPaymentTermsNet { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionStartTrialParamsPaymentTermsNet { Days = 0 };

        SubscriptionStartTrialParamsPaymentTermsNet copied = new(model);

        Assert.Equal(model, copied);
    }
}
