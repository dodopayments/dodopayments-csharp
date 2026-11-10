using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionPreviewChangePlanParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = SubscriptionPreviewChangePlanParamsCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms =
                    new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";
        string expectedProductID = "product_id";
        ApiEnum<
            string,
            SubscriptionPreviewChangePlanParamsProrationBillingMode
        > expectedProrationBillingMode =
            SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        bool expectedCancelOlderPaymentLink = true;
        bool expectedCancelScheduledChangePlan = true;
        bool expectedCollectViaPaymentLink = true;
        ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit> expectedCredit =
            SubscriptionPreviewChangePlanParamsCredit.CustomerBalance;
        string expectedDiscountCode = "discount_code";
        List<string> expectedDiscountCodes = ["string"];
        ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt> expectedEffectiveAt =
            SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately;
        SubscriptionPreviewChangePlanParamsInvoice expectedInvoice = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<
            string,
            SubscriptionPreviewChangePlanParamsOnPaymentFailure
        > expectedOnPaymentFailure =
            SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange;
        string expectedReturnUrl = "return_url";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedProrationBillingMode, parameters.ProrationBillingMode);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(
            expectedAdaptiveCurrencyFeesInclusive,
            parameters.AdaptiveCurrencyFeesInclusive
        );
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedCancelOlderPaymentLink, parameters.CancelOlderPaymentLink);
        Assert.Equal(expectedCancelScheduledChangePlan, parameters.CancelScheduledChangePlan);
        Assert.Equal(expectedCollectViaPaymentLink, parameters.CollectViaPaymentLink);
        Assert.Equal(expectedCredit, parameters.Credit);
        Assert.Equal(expectedDiscountCode, parameters.DiscountCode);
        Assert.NotNull(parameters.DiscountCodes);
        Assert.Equal(expectedDiscountCodes.Count, parameters.DiscountCodes.Count);
        for (int i = 0; i < expectedDiscountCodes.Count; i++)
        {
            Assert.Equal(expectedDiscountCodes[i], parameters.DiscountCodes[i]);
        }
        Assert.Equal(expectedEffectiveAt, parameters.EffectiveAt);
        Assert.Equal(expectedInvoice, parameters.Invoice);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedOnPaymentFailure, parameters.OnPaymentFailure);
        Assert.Equal(expectedReturnUrl, parameters.ReturnUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = SubscriptionPreviewChangePlanParamsCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms =
                    new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        Assert.Null(parameters.CancelOlderPaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_older_payment_link"));
        Assert.Null(parameters.CancelScheduledChangePlan);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_scheduled_change_plan"));
        Assert.Null(parameters.CollectViaPaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("collect_via_payment_link"));
        Assert.Null(parameters.EffectiveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = SubscriptionPreviewChangePlanParamsCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms =
                    new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",

            // Null should be interpreted as omitted for these properties
            CancelOlderPaymentLink = null,
            CancelScheduledChangePlan = null,
            CollectViaPaymentLink = null,
            EffectiveAt = null,
        };

        Assert.Null(parameters.CancelOlderPaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_older_payment_link"));
        Assert.Null(parameters.CancelScheduledChangePlan);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_scheduled_change_plan"));
        Assert.Null(parameters.CollectViaPaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("collect_via_payment_link"));
        Assert.Null(parameters.EffectiveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately,
        };

        Assert.Null(parameters.AdaptiveCurrencyFeesInclusive);
        Assert.False(parameters.RawBodyData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.Credit);
        Assert.False(parameters.RawBodyData.ContainsKey("credit"));
        Assert.Null(parameters.DiscountCode);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.DiscountCodes);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_codes"));
        Assert.Null(parameters.Invoice);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OnPaymentFailure);
        Assert.False(parameters.RawBodyData.ContainsKey("on_payment_failure"));
        Assert.Null(parameters.ReturnUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately,

            AdaptiveCurrencyFeesInclusive = null,
            Addons = null,
            Credit = null,
            DiscountCode = null,
            DiscountCodes = null,
            Invoice = null,
            Metadata = null,
            OnPaymentFailure = null,
            ReturnUrl = null,
        };

        Assert.Null(parameters.AdaptiveCurrencyFeesInclusive);
        Assert.True(parameters.RawBodyData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.Credit);
        Assert.True(parameters.RawBodyData.ContainsKey("credit"));
        Assert.Null(parameters.DiscountCode);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.DiscountCodes);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_codes"));
        Assert.Null(parameters.Invoice);
        Assert.True(parameters.RawBodyData.ContainsKey("invoice"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OnPaymentFailure);
        Assert.True(parameters.RawBodyData.ContainsKey("on_payment_failure"));
        Assert.Null(parameters.ReturnUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("return_url"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionPreviewChangePlanParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv/change-plan/preview"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = SubscriptionPreviewChangePlanParamsCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms =
                    new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        SubscriptionPreviewChangePlanParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionPreviewChangePlanParamsProrationBillingModeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.FullImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.DifferenceImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.DoNotBill)]
    [InlineData(
        SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediatelyKeepCycle
    )]
    public void Validation_Works(SubscriptionPreviewChangePlanParamsProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.FullImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.DifferenceImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.DoNotBill)]
    [InlineData(
        SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediatelyKeepCycle
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionPreviewChangePlanParamsProrationBillingMode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewChangePlanParamsCreditTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsCredit.CustomerBalance)]
    [InlineData(SubscriptionPreviewChangePlanParamsCredit.Refund)]
    public void Validation_Works(SubscriptionPreviewChangePlanParamsCredit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsCredit.CustomerBalance)]
    [InlineData(SubscriptionPreviewChangePlanParamsCredit.Refund)]
    public void SerializationRoundtrip_Works(SubscriptionPreviewChangePlanParamsCredit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsCredit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewChangePlanParamsEffectiveAtTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsEffectiveAt.NextBillingDate)]
    public void Validation_Works(SubscriptionPreviewChangePlanParamsEffectiveAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsEffectiveAt.Immediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsEffectiveAt.NextBillingDate)]
    public void SerializationRoundtrip_Works(
        SubscriptionPreviewChangePlanParamsEffectiveAt rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsEffectiveAt>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewChangePlanParamsInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms expectedPaymentTerms =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();

        Assert.Equal(expectedCollectionMethod, model.CollectionMethod);
        Assert.Equal(expectedFinalize, model.Finalize);
        Assert.Equal(expectedPaymentTerms, model.PaymentTerms);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms expectedPaymentTerms =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();

        Assert.Equal(expectedCollectionMethod, deserialized.CollectionMethod);
        Assert.Equal(expectedFinalize, deserialized.Finalize);
        Assert.Equal(expectedPaymentTerms, deserialized.PaymentTerms);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice { Finalize = true };

        Assert.Null(model.CollectionMethod);
        Assert.False(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.PaymentTerms);
        Assert.False(model.RawData.ContainsKey("payment_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice { Finalize = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            Finalize = true,

            CollectionMethod = null,
            PaymentTerms = null,
        };

        Assert.Null(model.CollectionMethod);
        Assert.True(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.PaymentTerms);
        Assert.True(model.RawData.ContainsKey("payment_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            Finalize = true,

            CollectionMethod = null,
            PaymentTerms = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt(),
        };

        SubscriptionPreviewChangePlanParamsInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewChangePlanParamsInvoicePaymentTermsTest : TestBase
{
    [Fact]
    public void DueOnReceiptValidationWorks()
    {
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms value =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();
        value.Validate();
    }

    [Fact]
    public void NetValidationWorks()
    {
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms value =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet(0);
        value.Validate();
    }

    [Fact]
    public void DueOnReceiptSerializationRoundtripWorks()
    {
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms value =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTerms>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NetSerializationRoundtripWorks()
    {
        SubscriptionPreviewChangePlanParamsInvoicePaymentTerms value =
            new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTerms>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceiptTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
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
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
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
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsDueOnReceipt>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet>(
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
        var model = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet { Days = 0 };

        SubscriptionPreviewChangePlanParamsInvoicePaymentTermsNet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewChangePlanParamsOnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange)]
    [InlineData(SubscriptionPreviewChangePlanParamsOnPaymentFailure.ApplyChange)]
    public void Validation_Works(SubscriptionPreviewChangePlanParamsOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsOnPaymentFailure.PreventChange)]
    [InlineData(SubscriptionPreviewChangePlanParamsOnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(
        SubscriptionPreviewChangePlanParamsOnPaymentFailure rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
