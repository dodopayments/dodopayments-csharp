using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class UpdateSubscriptionPlanReqTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        string expectedProductID = "product_id";
        ApiEnum<
            string,
            UpdateSubscriptionPlanReqProrationBillingMode
        > expectedProrationBillingMode =
            UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        bool expectedCancelOlderPaymentLink = true;
        bool expectedCancelScheduledChangePlan = true;
        bool expectedCollectViaPaymentLink = true;
        ApiEnum<string, UpdateSubscriptionPlanReqCredit> expectedCredit =
            UpdateSubscriptionPlanReqCredit.CustomerBalance;
        string expectedDiscountCode = "discount_code";
        List<string> expectedDiscountCodes = ["string"];
        ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt> expectedEffectiveAt =
            UpdateSubscriptionPlanReqEffectiveAt.Immediately;
        UpdateSubscriptionPlanReqInvoice expectedInvoice = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> expectedOnPaymentFailure =
            UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange;
        string expectedReturnUrl = "return_url";

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedProrationBillingMode, model.ProrationBillingMode);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedAdaptiveCurrencyFeesInclusive, model.AdaptiveCurrencyFeesInclusive);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedCancelOlderPaymentLink, model.CancelOlderPaymentLink);
        Assert.Equal(expectedCancelScheduledChangePlan, model.CancelScheduledChangePlan);
        Assert.Equal(expectedCollectViaPaymentLink, model.CollectViaPaymentLink);
        Assert.Equal(expectedCredit, model.Credit);
        Assert.Equal(expectedDiscountCode, model.DiscountCode);
        Assert.NotNull(model.DiscountCodes);
        Assert.Equal(expectedDiscountCodes.Count, model.DiscountCodes.Count);
        for (int i = 0; i < expectedDiscountCodes.Count; i++)
        {
            Assert.Equal(expectedDiscountCodes[i], model.DiscountCodes[i]);
        }
        Assert.Equal(expectedEffectiveAt, model.EffectiveAt);
        Assert.Equal(expectedInvoice, model.Invoice);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedOnPaymentFailure, model.OnPaymentFailure);
        Assert.Equal(expectedReturnUrl, model.ReturnUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReq>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReq>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        ApiEnum<
            string,
            UpdateSubscriptionPlanReqProrationBillingMode
        > expectedProrationBillingMode =
            UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        bool expectedCancelOlderPaymentLink = true;
        bool expectedCancelScheduledChangePlan = true;
        bool expectedCollectViaPaymentLink = true;
        ApiEnum<string, UpdateSubscriptionPlanReqCredit> expectedCredit =
            UpdateSubscriptionPlanReqCredit.CustomerBalance;
        string expectedDiscountCode = "discount_code";
        List<string> expectedDiscountCodes = ["string"];
        ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt> expectedEffectiveAt =
            UpdateSubscriptionPlanReqEffectiveAt.Immediately;
        UpdateSubscriptionPlanReqInvoice expectedInvoice = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> expectedOnPaymentFailure =
            UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange;
        string expectedReturnUrl = "return_url";

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedProrationBillingMode, deserialized.ProrationBillingMode);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(
            expectedAdaptiveCurrencyFeesInclusive,
            deserialized.AdaptiveCurrencyFeesInclusive
        );
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedCancelOlderPaymentLink, deserialized.CancelOlderPaymentLink);
        Assert.Equal(expectedCancelScheduledChangePlan, deserialized.CancelScheduledChangePlan);
        Assert.Equal(expectedCollectViaPaymentLink, deserialized.CollectViaPaymentLink);
        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.Equal(expectedDiscountCode, deserialized.DiscountCode);
        Assert.NotNull(deserialized.DiscountCodes);
        Assert.Equal(expectedDiscountCodes.Count, deserialized.DiscountCodes.Count);
        for (int i = 0; i < expectedDiscountCodes.Count; i++)
        {
            Assert.Equal(expectedDiscountCodes[i], deserialized.DiscountCodes[i]);
        }
        Assert.Equal(expectedEffectiveAt, deserialized.EffectiveAt);
        Assert.Equal(expectedInvoice, deserialized.Invoice);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedOnPaymentFailure, deserialized.OnPaymentFailure);
        Assert.Equal(expectedReturnUrl, deserialized.ReturnUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        Assert.Null(model.CancelOlderPaymentLink);
        Assert.False(model.RawData.ContainsKey("cancel_older_payment_link"));
        Assert.Null(model.CancelScheduledChangePlan);
        Assert.False(model.RawData.ContainsKey("cancel_scheduled_change_plan"));
        Assert.Null(model.CollectViaPaymentLink);
        Assert.False(model.RawData.ContainsKey("collect_via_payment_link"));
        Assert.Null(model.EffectiveAt);
        Assert.False(model.RawData.ContainsKey("effective_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",

            // Null should be interpreted as omitted for these properties
            CancelOlderPaymentLink = null,
            CancelScheduledChangePlan = null,
            CollectViaPaymentLink = null,
            EffectiveAt = null,
        };

        Assert.Null(model.CancelOlderPaymentLink);
        Assert.False(model.RawData.ContainsKey("cancel_older_payment_link"));
        Assert.Null(model.CancelScheduledChangePlan);
        Assert.False(model.RawData.ContainsKey("cancel_scheduled_change_plan"));
        Assert.Null(model.CollectViaPaymentLink);
        Assert.False(model.RawData.ContainsKey("collect_via_payment_link"));
        Assert.Null(model.EffectiveAt);
        Assert.False(model.RawData.ContainsKey("effective_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",

            // Null should be interpreted as omitted for these properties
            CancelOlderPaymentLink = null,
            CancelScheduledChangePlan = null,
            CollectViaPaymentLink = null,
            EffectiveAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
        };

        Assert.Null(model.AdaptiveCurrencyFeesInclusive);
        Assert.False(model.RawData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.DiscountCode);
        Assert.False(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.DiscountCodes);
        Assert.False(model.RawData.ContainsKey("discount_codes"));
        Assert.Null(model.Invoice);
        Assert.False(model.RawData.ContainsKey("invoice"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OnPaymentFailure);
        Assert.False(model.RawData.ContainsKey("on_payment_failure"));
        Assert.Null(model.ReturnUrl);
        Assert.False(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,

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

        Assert.Null(model.AdaptiveCurrencyFeesInclusive);
        Assert.True(model.RawData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Credit);
        Assert.True(model.RawData.ContainsKey("credit"));
        Assert.Null(model.DiscountCode);
        Assert.True(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.DiscountCodes);
        Assert.True(model.RawData.ContainsKey("discount_codes"));
        Assert.Null(model.Invoice);
        Assert.True(model.RawData.ContainsKey("invoice"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OnPaymentFailure);
        Assert.True(model.RawData.ContainsKey("on_payment_failure"));
        Assert.Null(model.ReturnUrl);
        Assert.True(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,

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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateSubscriptionPlanReq
        {
            ProductID = "product_id",
            ProrationBillingMode =
                UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = UpdateSubscriptionPlanReqCredit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = UpdateSubscriptionPlanReqEffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        UpdateSubscriptionPlanReq copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateSubscriptionPlanReqProrationBillingModeTest : TestBase
{
    [Theory]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.FullImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.DifferenceImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.DoNotBill)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediatelyKeepCycle)]
    public void Validation_Works(UpdateSubscriptionPlanReqProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.FullImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.DifferenceImmediately)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.DoNotBill)]
    [InlineData(UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediatelyKeepCycle)]
    public void SerializationRoundtrip_Works(UpdateSubscriptionPlanReqProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UpdateSubscriptionPlanReqCreditTest : TestBase
{
    [Theory]
    [InlineData(UpdateSubscriptionPlanReqCredit.CustomerBalance)]
    [InlineData(UpdateSubscriptionPlanReqCredit.Refund)]
    public void Validation_Works(UpdateSubscriptionPlanReqCredit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqCredit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateSubscriptionPlanReqCredit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateSubscriptionPlanReqCredit.CustomerBalance)]
    [InlineData(UpdateSubscriptionPlanReqCredit.Refund)]
    public void SerializationRoundtrip_Works(UpdateSubscriptionPlanReqCredit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqCredit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqCredit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateSubscriptionPlanReqCredit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqCredit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UpdateSubscriptionPlanReqEffectiveAtTest : TestBase
{
    [Theory]
    [InlineData(UpdateSubscriptionPlanReqEffectiveAt.Immediately)]
    [InlineData(UpdateSubscriptionPlanReqEffectiveAt.NextBillingDate)]
    public void Validation_Works(UpdateSubscriptionPlanReqEffectiveAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateSubscriptionPlanReqEffectiveAt.Immediately)]
    [InlineData(UpdateSubscriptionPlanReqEffectiveAt.NextBillingDate)]
    public void SerializationRoundtrip_Works(UpdateSubscriptionPlanReqEffectiveAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqEffectiveAt>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UpdateSubscriptionPlanReqInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        UpdateSubscriptionPlanReqInvoicePaymentTerms expectedPaymentTerms =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsType();

        Assert.Equal(expectedCollectionMethod, model.CollectionMethod);
        Assert.Equal(expectedFinalize, model.Finalize);
        Assert.Equal(expectedPaymentTerms, model.PaymentTerms);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        UpdateSubscriptionPlanReqInvoicePaymentTerms expectedPaymentTerms =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsType();

        Assert.Equal(expectedCollectionMethod, deserialized.CollectionMethod);
        Assert.Equal(expectedFinalize, deserialized.Finalize);
        Assert.Equal(expectedPaymentTerms, deserialized.PaymentTerms);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice { Finalize = true };

        Assert.Null(model.CollectionMethod);
        Assert.False(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.PaymentTerms);
        Assert.False(model.RawData.ContainsKey("payment_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice { Finalize = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoice
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
        var model = new UpdateSubscriptionPlanReqInvoice
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
        var model = new UpdateSubscriptionPlanReqInvoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new UpdateSubscriptionPlanReqInvoicePaymentTermsType(),
        };

        UpdateSubscriptionPlanReqInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateSubscriptionPlanReqInvoicePaymentTermsTest : TestBase
{
    [Fact]
    public void ObjectValidationWorks()
    {
        UpdateSubscriptionPlanReqInvoicePaymentTerms value =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsType();
        value.Validate();
    }

    [Fact]
    public void UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1ValidationWorks()
    {
        UpdateSubscriptionPlanReqInvoicePaymentTerms value =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(0);
        value.Validate();
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks()
    {
        UpdateSubscriptionPlanReqInvoicePaymentTerms value =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsType();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1SerializationRoundtripWorks()
    {
        UpdateSubscriptionPlanReqInvoicePaymentTerms value =
            new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UpdateSubscriptionPlanReqInvoicePaymentTermsTypeTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UpdateSubscriptionPlanReqInvoicePaymentTermsType();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
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
        var constant = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UpdateSubscriptionPlanReqInvoicePaymentTermsType();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
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
            JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsType>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1>(
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
        var model = new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 { Days = 0 };

        UpdateSubscriptionPlanReqInvoicePaymentTermsUnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateSubscriptionPlanReqOnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange)]
    [InlineData(UpdateSubscriptionPlanReqOnPaymentFailure.ApplyChange)]
    public void Validation_Works(UpdateSubscriptionPlanReqOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange)]
    [InlineData(UpdateSubscriptionPlanReqOnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(UpdateSubscriptionPlanReqOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
