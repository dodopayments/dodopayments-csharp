using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionChangePlanParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = Subscriptions::Credit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = Subscriptions::EffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new Subscriptions::Type(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = Subscriptions::OnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";
        string expectedProductID = "product_id";
        ApiEnum<string, Subscriptions::ProrationBillingMode> expectedProrationBillingMode =
            Subscriptions::ProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        List<Subscriptions::AttachAddon> expectedAddons =
        [
            new() { AddonID = "addon_id", Quantity = 0 },
        ];
        bool expectedCancelOlderPaymentLink = true;
        bool expectedCancelScheduledChangePlan = true;
        bool expectedCollectViaPaymentLink = true;
        ApiEnum<string, Subscriptions::Credit> expectedCredit =
            Subscriptions::Credit.CustomerBalance;
        string expectedDiscountCode = "discount_code";
        List<string> expectedDiscountCodes = ["string"];
        ApiEnum<string, Subscriptions::EffectiveAt> expectedEffectiveAt =
            Subscriptions::EffectiveAt.Immediately;
        Subscriptions::Invoice expectedInvoice = new()
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Subscriptions::OnPaymentFailure> expectedOnPaymentFailure =
            Subscriptions::OnPaymentFailure.PreventChange;
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
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = Subscriptions::Credit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new Subscriptions::Type(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = Subscriptions::OnPaymentFailure.PreventChange,
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
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Credit = Subscriptions::Credit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new Subscriptions::Type(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = Subscriptions::OnPaymentFailure.PreventChange,
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
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = Subscriptions::EffectiveAt.Immediately,
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
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            EffectiveAt = Subscriptions::EffectiveAt.Immediately,

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
        Subscriptions::SubscriptionChangePlanParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv/change-plan"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            ProductID = "product_id",
            ProrationBillingMode = Subscriptions::ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            AdaptiveCurrencyFeesInclusive = true,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            CancelOlderPaymentLink = true,
            CancelScheduledChangePlan = true,
            CollectViaPaymentLink = true,
            Credit = Subscriptions::Credit.CustomerBalance,
            DiscountCode = "discount_code",
            DiscountCodes = ["string"],
            EffectiveAt = Subscriptions::EffectiveAt.Immediately,
            Invoice = new()
            {
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                Finalize = true,
                PaymentTerms = new Subscriptions::Type(),
            },
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            OnPaymentFailure = Subscriptions::OnPaymentFailure.PreventChange,
            ReturnUrl = "return_url",
        };

        Subscriptions::SubscriptionChangePlanParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProrationBillingModeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ProrationBillingMode.ProratedImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.FullImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.DifferenceImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.DoNotBill)]
    [InlineData(Subscriptions::ProrationBillingMode.ProratedImmediatelyKeepCycle)]
    public void Validation_Works(Subscriptions::ProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ProrationBillingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ProrationBillingMode.ProratedImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.FullImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.DifferenceImmediately)]
    [InlineData(Subscriptions::ProrationBillingMode.DoNotBill)]
    [InlineData(Subscriptions::ProrationBillingMode.ProratedImmediatelyKeepCycle)]
    public void SerializationRoundtrip_Works(Subscriptions::ProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ProrationBillingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBillingMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBillingMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Credit.CustomerBalance)]
    [InlineData(Subscriptions::Credit.Refund)]
    public void Validation_Works(Subscriptions::Credit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Credit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Credit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Credit.CustomerBalance)]
    [InlineData(Subscriptions::Credit.Refund)]
    public void SerializationRoundtrip_Works(Subscriptions::Credit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Credit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Credit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Credit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Credit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EffectiveAtTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::EffectiveAt.Immediately)]
    [InlineData(Subscriptions::EffectiveAt.NextBillingDate)]
    public void Validation_Works(Subscriptions::EffectiveAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::EffectiveAt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EffectiveAt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::EffectiveAt.Immediately)]
    [InlineData(Subscriptions::EffectiveAt.NextBillingDate)]
    public void SerializationRoundtrip_Works(Subscriptions::EffectiveAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::EffectiveAt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EffectiveAt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EffectiveAt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EffectiveAt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        Subscriptions::PaymentTerms expectedPaymentTerms = new Subscriptions::Type();

        Assert.Equal(expectedCollectionMethod, model.CollectionMethod);
        Assert.Equal(expectedFinalize, model.Finalize);
        Assert.Equal(expectedPaymentTerms, model.PaymentTerms);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Invoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InvoiceCollectionMethod> expectedCollectionMethod =
            InvoiceCollectionMethod.AutoCharge;
        bool expectedFinalize = true;
        Subscriptions::PaymentTerms expectedPaymentTerms = new Subscriptions::Type();

        Assert.Equal(expectedCollectionMethod, deserialized.CollectionMethod);
        Assert.Equal(expectedFinalize, deserialized.Finalize);
        Assert.Equal(expectedPaymentTerms, deserialized.PaymentTerms);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new Subscriptions::Type(),
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new Subscriptions::Type(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new Subscriptions::Type(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        Assert.Null(model.Finalize);
        Assert.False(model.RawData.ContainsKey("finalize"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            PaymentTerms = new Subscriptions::Type(),

            // Null should be interpreted as omitted for these properties
            Finalize = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Invoice { Finalize = true };

        Assert.Null(model.CollectionMethod);
        Assert.False(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.PaymentTerms);
        Assert.False(model.RawData.ContainsKey("payment_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Invoice { Finalize = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Invoice
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
        var model = new Subscriptions::Invoice
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
        var model = new Subscriptions::Invoice
        {
            CollectionMethod = InvoiceCollectionMethod.AutoCharge,
            Finalize = true,
            PaymentTerms = new Subscriptions::Type(),
        };

        Subscriptions::Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentTermsTest : TestBase
{
    [Fact]
    public void ObjectValidationWorks()
    {
        Subscriptions::PaymentTerms value = new Subscriptions::Type();
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        Subscriptions::PaymentTerms value = new Subscriptions::UnionMember1(0);
        value.Validate();
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks()
    {
        Subscriptions::PaymentTerms value = new Subscriptions::Type();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        Subscriptions::PaymentTerms value = new Subscriptions::UnionMember1(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PaymentTerms>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Subscriptions::Type();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Subscriptions::Type>(
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
        var constant = JsonSerializer.Deserialize<Subscriptions::Type>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Subscriptions::Type();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Type>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Subscriptions::Type>(
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Type>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Subscriptions::Type>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Type>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::UnionMember1 { Days = 0 };

        int expectedDays = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("net");

        Assert.Equal(expectedDays, model.Days);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::UnionMember1 { Days = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::UnionMember1 { Days = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnionMember1>(
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
        var model = new Subscriptions::UnionMember1 { Days = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::UnionMember1 { Days = 0 };

        Subscriptions::UnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::OnPaymentFailure.PreventChange)]
    [InlineData(Subscriptions::OnPaymentFailure.ApplyChange)]
    public void Validation_Works(Subscriptions::OnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::OnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::OnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::OnPaymentFailure.PreventChange)]
    [InlineData(Subscriptions::OnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(Subscriptions::OnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::OnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::OnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::OnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::OnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
