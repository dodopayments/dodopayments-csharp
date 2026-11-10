using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Items =
            [
                new InvoiceUpdateParamsItemCustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            Memo = "memo",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            PaymentTerms = new InvoiceUpdateParamsPaymentTermsDueOnReceipt(),
            ReviewRequired = true,
            TaxID = "tax_id",
        };

        string expectedInvoiceID = "invoice_id";
        string expectedIfMatch = "If-Match";
        InvoiceUpdateParamsBillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        List<string> expectedCcEmails = ["string"];
        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerID = "customer_id";
        List<string> expectedDiscountIds = ["string"];
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        InvoiceUpdateParamsDunning expectedDunning = new()
        {
            RemindersEnabled = true,
            OffsetsDays = [0],
        };
        List<InvoiceUpdateParamsItem> expectedItems =
        [
            new InvoiceUpdateParamsItemCustomItem()
            {
                Description = "description",
                TaxCategory = TaxCategory.DigitalProducts,
                UnitAmount = 0,
                Quantity = 0,
            },
        ];
        string expectedMemo = "memo";
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        InvoiceUpdateParamsPaymentTerms expectedPaymentTerms =
            new InvoiceUpdateParamsPaymentTermsDueOnReceipt();
        bool expectedReviewRequired = true;
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedIfMatch, parameters.IfMatch);
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.NotNull(parameters.CcEmails);
        Assert.Equal(expectedCcEmails.Count, parameters.CcEmails.Count);
        for (int i = 0; i < expectedCcEmails.Count; i++)
        {
            Assert.Equal(expectedCcEmails[i], parameters.CcEmails[i]);
        }
        Assert.Equal(expectedCollectionMethod, parameters.CollectionMethod);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCustomerEmail, parameters.CustomerEmail);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.NotNull(parameters.DiscountIds);
        Assert.Equal(expectedDiscountIds.Count, parameters.DiscountIds.Count);
        for (int i = 0; i < expectedDiscountIds.Count; i++)
        {
            Assert.Equal(expectedDiscountIds[i], parameters.DiscountIds[i]);
        }
        Assert.Equal(expectedDueAt, parameters.DueAt);
        Assert.Equal(expectedDunning, parameters.Dunning);
        Assert.NotNull(parameters.Items);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
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
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceUpdateParams { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.CcEmails);
        Assert.False(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CollectionMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("collection_method"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.CustomerEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_email"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DiscountIds);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_ids"));
        Assert.Null(parameters.DueAt);
        Assert.False(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Dunning);
        Assert.False(parameters.RawBodyData.ContainsKey("dunning"));
        Assert.Null(parameters.Items);
        Assert.False(parameters.RawBodyData.ContainsKey("items"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.ReviewRequired);
        Assert.False(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",

            BillingAddress = null,
            CcEmails = null,
            CollectionMethod = null,
            Currency = null,
            CustomerEmail = null,
            CustomerID = null,
            DiscountIds = null,
            DueAt = null,
            Dunning = null,
            Items = null,
            Memo = null,
            Metadata = null,
            PaymentTerms = null,
            ReviewRequired = null,
            TaxID = null,
        };

        Assert.Null(parameters.BillingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.CcEmails);
        Assert.True(parameters.RawBodyData.ContainsKey("cc_emails"));
        Assert.Null(parameters.CollectionMethod);
        Assert.True(parameters.RawBodyData.ContainsKey("collection_method"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.CustomerEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_email"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DiscountIds);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_ids"));
        Assert.Null(parameters.DueAt);
        Assert.True(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Dunning);
        Assert.True(parameters.RawBodyData.ContainsKey("dunning"));
        Assert.Null(parameters.Items);
        Assert.True(parameters.RawBodyData.ContainsKey("items"));
        Assert.Null(parameters.Memo);
        Assert.True(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_terms"));
        Assert.Null(parameters.ReviewRequired);
        Assert.True(parameters.RawBodyData.ContainsKey("review_required"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceUpdateParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InvoiceUpdateParams parameters = new() { InvoiceID = "invoice_id", IfMatch = "If-Match" };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["If-Match"], requestMessage.Headers.GetValues("If-Match"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "invoice_id",
            IfMatch = "If-Match",
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Currency = Currency.Aed,
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            DiscountIds = ["string"],
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dunning = new() { RemindersEnabled = true, OffsetsDays = [0] },
            Items =
            [
                new InvoiceUpdateParamsItemCustomItem()
                {
                    Description = "description",
                    TaxCategory = TaxCategory.DigitalProducts,
                    UnitAmount = 0,
                    Quantity = 0,
                },
            ],
            Memo = "memo",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            PaymentTerms = new InvoiceUpdateParamsPaymentTermsDueOnReceipt(),
            ReviewRequired = true,
            TaxID = "tax_id",
        };

        InvoiceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InvoiceUpdateParamsBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsBillingAddress
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
        var model = new InvoiceUpdateParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceUpdateParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsBillingAddress>(
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
        var model = new InvoiceUpdateParamsBillingAddress
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
        var model = new InvoiceUpdateParamsBillingAddress { Country = CountryCode.Af };

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
        var model = new InvoiceUpdateParamsBillingAddress { Country = CountryCode.Af };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceUpdateParamsBillingAddress
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
        var model = new InvoiceUpdateParamsBillingAddress
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
        var model = new InvoiceUpdateParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        InvoiceUpdateParamsBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceUpdateParamsDunningTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true, OffsetsDays = [0] };

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
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true, OffsetsDays = [0] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDunning>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true, OffsetsDays = [0] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDunning>(
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
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true, OffsetsDays = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true };

        Assert.Null(model.OffsetsDays);
        Assert.False(model.RawData.ContainsKey("offsets_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceUpdateParamsDunning
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
        var model = new InvoiceUpdateParamsDunning
        {
            RemindersEnabled = true,

            OffsetsDays = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceUpdateParamsDunning { RemindersEnabled = true, OffsetsDays = [0] };

        InvoiceUpdateParamsDunning copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceUpdateParamsItemTest : TestBase
{
    [Fact]
    public void CustomValidationWorks()
    {
        InvoiceUpdateParamsItem value = new InvoiceUpdateParamsItemCustomItem()
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
        InvoiceUpdateParamsItem value = new InvoiceUpdateParamsItemProductItem()
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
        InvoiceUpdateParamsItem value = new InvoiceUpdateParamsItemCustomItem()
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ProductSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsItem value = new InvoiceUpdateParamsItemProductItem()
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceUpdateParamsItemCustomItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemCustomItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceUpdateParamsItemCustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemCustomItem>(
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
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
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
        var model = new InvoiceUpdateParamsItemCustomItem
        {
            Description = "description",
            TaxCategory = TaxCategory.DigitalProducts,
            UnitAmount = 0,
            Quantity = 0,
        };

        InvoiceUpdateParamsItemCustomItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceUpdateParamsItemProductItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];

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
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemProductItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemProductItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];

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
        var model = new InvoiceUpdateParamsItemProductItem
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
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceUpdateParamsItemProductItem
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
        var model = new InvoiceUpdateParamsItemProductItem
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
        var model = new InvoiceUpdateParamsItemProductItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        InvoiceUpdateParamsItemProductItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceUpdateParamsPaymentTermsTest : TestBase
{
    [Fact]
    public void DueOnReceiptValidationWorks()
    {
        InvoiceUpdateParamsPaymentTerms value = new InvoiceUpdateParamsPaymentTermsDueOnReceipt();
        value.Validate();
    }

    [Fact]
    public void NetValidationWorks()
    {
        InvoiceUpdateParamsPaymentTerms value = new InvoiceUpdateParamsPaymentTermsNet(0);
        value.Validate();
    }

    [Fact]
    public void DueOnReceiptSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsPaymentTerms value = new InvoiceUpdateParamsPaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NetSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsPaymentTerms value = new InvoiceUpdateParamsPaymentTermsNet(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceUpdateParamsPaymentTermsDueOnReceiptTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new InvoiceUpdateParamsPaymentTermsDueOnReceipt();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
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
        var constant = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new InvoiceUpdateParamsPaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
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
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class InvoiceUpdateParamsPaymentTermsNetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsPaymentTermsNet { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceUpdateParamsPaymentTermsNet { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsNet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceUpdateParamsPaymentTermsNet { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsNet>(
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
        var model = new InvoiceUpdateParamsPaymentTermsNet { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceUpdateParamsPaymentTermsNet { Days = 0 };

        InvoiceUpdateParamsPaymentTermsNet copied = new(model);

        Assert.Equal(model, copied);
    }
}
