using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Memo = "memo",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            PaymentTerms = new DueOnReceipt(),
            ReviewRequired = true,
            TaxID = "tax_id",
            IdempotencyKey = "Idempotency-Key",
        };

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerID = "customer_id";
        List<Item> expectedItems =
        [
            new CustomItem()
            {
                Description = "description",
                TaxCategory = TaxCategory.DigitalProducts,
                UnitAmount = 0,
                Quantity = 0,
            },
        ];
        BillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        List<string> expectedCcEmails = ["string"];
        string expectedCustomerEmail = "customer_email";
        List<string> expectedDiscountIds = ["string"];
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dunning expectedDunning = new() { RemindersEnabled = true, OffsetsDays = [0] };
        string expectedMemo = "memo";
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        PaymentTerms expectedPaymentTerms = new DueOnReceipt();
        bool expectedReviewRequired = true;
        string expectedTaxID = "tax_id";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedCollectionMethod, parameters.CollectionMethod);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.NotNull(parameters.CcEmails);
        Assert.Equal(expectedCcEmails.Count, parameters.CcEmails.Count);
        for (int i = 0; i < expectedCcEmails.Count; i++)
        {
            Assert.Equal(expectedCcEmails[i], parameters.CcEmails[i]);
        }
        Assert.Equal(expectedCustomerEmail, parameters.CustomerEmail);
        Assert.NotNull(parameters.DiscountIds);
        Assert.Equal(expectedDiscountIds.Count, parameters.DiscountIds.Count);
        for (int i = 0; i < expectedDiscountIds.Count; i++)
        {
            Assert.Equal(expectedDiscountIds[i], parameters.DiscountIds[i]);
        }
        Assert.Equal(expectedDueAt, parameters.DueAt);
        Assert.Equal(expectedDunning, parameters.Dunning);
        Assert.Equal(expectedMemo, parameters.Memo);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentTerms, parameters.PaymentTerms);
        Assert.Equal(expectedReviewRequired, parameters.ReviewRequired);
        Assert.Equal(expectedTaxID, parameters.TaxID);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Memo = "memo",
            PaymentTerms = new DueOnReceipt(),
            TaxID = "tax_id",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReviewRequired);
        Assert.False(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Memo = "memo",
            PaymentTerms = new DueOnReceipt(),
            TaxID = "tax_id",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            ReviewRequired = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReviewRequired);
        Assert.False(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            ReviewRequired = true,
            IdempotencyKey = "Idempotency-Key",
        };

        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.CcEmails);
        Assert.False(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CustomerEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_email"));
        Assert.Null(parameters.DiscountIds);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_ids"));
        Assert.Null(parameters.DueAt);
        Assert.False(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Dunning);
        Assert.False(parameters.RawBodyData.ContainsKey("dunning"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.PaymentTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            ReviewRequired = true,
            IdempotencyKey = "Idempotency-Key",

            BillingAddress = null,
            CcEmails = null,
            CustomerEmail = null,
            DiscountIds = null,
            DueAt = null,
            Dunning = null,
            Memo = null,
            PaymentTerms = null,
            TaxID = null,
        };

        Assert.Null(parameters.BillingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.CcEmails);
        Assert.True(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CustomerEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_email"));
        Assert.Null(parameters.DiscountIds);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_ids"));
        Assert.Null(parameters.DueAt);
        Assert.True(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Dunning);
        Assert.True(parameters.RawBodyData.ContainsKey("dunning"));
        Assert.Null(parameters.Memo);
        Assert.True(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.PaymentTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceCreateParams parameters = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/billing/invoices"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InvoiceCreateParams parameters = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            IdempotencyKey = "Idempotency-Key",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["Idempotency-Key"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceCreateParams
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            Items =
            [
                new CustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerEmail = "customer_email",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Memo = "memo",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            PaymentTerms = new DueOnReceipt(),
            ReviewRequired = true,
            TaxID = "tax_id",
            IdempotencyKey = "Idempotency-Key",
        };

        InvoiceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void CustomValidationWorks()
    {
        Item value = new CustomItem()
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ProductValidationWorks()
    {
        Item value = new ProductItem()
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };
        value.Validate();
    }

    [Fact]
    public void CustomSerializationRoundtripWorks()
    {
        Item value = new CustomItem()
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ProductSerializationRoundtripWorks()
    {
        Item value = new ProductItem()
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        string expectedDescription = "description";
        JsonElement expectedKind = JsonSerializer.SerializeToElement("custom");
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        int expectedUnitAmount = 0;
        int expectedQuantity = 0;

        Assert.Equal(expectedDescription, model.Description);
        Assert.True(JsonElement.DeepEquals(expectedKind, model.Kind));
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        JsonElement expectedKind = JsonSerializer.SerializeToElement("custom");
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        int expectedUnitAmount = 0;
        int expectedQuantity = 0;

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.True(JsonElement.DeepEquals(expectedKind, deserialized.Kind));
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,

            Quantity = null,
        };

        Assert.Null(model.Quantity);
        Assert.True(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,

            Quantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        CustomItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<Subscriptions::AttachAddon> expectedAddons =
        [
            new() { AddonID = "addon_id", Quantity = 0 },
        ];

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<Subscriptions::AttachAddon> expectedAddons =
        [
            new() { AddonID = "addon_id", Quantity = 0 },
        ];

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductItem { ProductID = "product_id", Quantity = 0 };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductItem { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,

            Addons = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,

            Addons = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        ProductItem copied = new(model);

        Assert.Equal(model, copied);
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

public class DunningTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dunning { RemindersEnabled = true, OffsetsDays = [0] };

        bool expectedRemindersEnabled = true;
        List<int> expectedOffsetsDays = [0];

        Assert.Equal(expectedRemindersEnabled, model.RemindersEnabled);
        Assert.NotNull(model.OffsetsDays);
        Assert.Equal(expectedOffsetsDays.Count, model.OffsetsDays.Count);
        for (int i = 0; i < expectedOffsetsDays.Count; i++)
        {
            Assert.Equal(expectedOffsetsDays[i], model.OffsetsDays[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dunning { RemindersEnabled = true, OffsetsDays = [0] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dunning>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dunning { RemindersEnabled = true, OffsetsDays = [0] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dunning>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedRemindersEnabled = true;
        List<int> expectedOffsetsDays = [0];

        Assert.Equal(expectedRemindersEnabled, deserialized.RemindersEnabled);
        Assert.NotNull(deserialized.OffsetsDays);
        Assert.Equal(expectedOffsetsDays.Count, deserialized.OffsetsDays.Count);
        for (int i = 0; i < expectedOffsetsDays.Count; i++)
        {
            Assert.Equal(expectedOffsetsDays[i], deserialized.OffsetsDays[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dunning { RemindersEnabled = true, OffsetsDays = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dunning { RemindersEnabled = true };

        Assert.Null(model.OffsetsDays);
        Assert.False(model.RawData.ContainsKey("offsets_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dunning { RemindersEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Dunning
        {
            RemindersEnabled = true,

            OffsetsDays = null,
        };

        Assert.Null(model.OffsetsDays);
        Assert.True(model.RawData.ContainsKey("offsets_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dunning
        {
            RemindersEnabled = true,

            OffsetsDays = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dunning { RemindersEnabled = true, OffsetsDays = [0] };

        Dunning copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentTermsTest : TestBase
{
    [Fact]
    public void DueOnReceiptValidationWorks()
    {
        PaymentTerms value = new DueOnReceipt();
        value.Validate();
    }

    [Fact]
    public void NetValidationWorks()
    {
        PaymentTerms value = new Net(0);
        value.Validate();
    }

    [Fact]
    public void DueOnReceiptSerializationRoundtripWorks()
    {
        PaymentTerms value = new DueOnReceipt();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NetSerializationRoundtripWorks()
    {
        PaymentTerms value = new Net(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DueOnReceiptTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new DueOnReceipt();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<DueOnReceipt>(
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
        var constant = JsonSerializer.Deserialize<DueOnReceipt>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new DueOnReceipt();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<DueOnReceipt>(
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
        var deserialized = JsonSerializer.Deserialize<DueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<DueOnReceipt>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class NetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Net { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Net { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Net>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Net { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Net>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, deserialized.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Net { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Net { Days = 0 };

        Net copied = new(model);

        Assert.Equal(model, copied);
    }
}
