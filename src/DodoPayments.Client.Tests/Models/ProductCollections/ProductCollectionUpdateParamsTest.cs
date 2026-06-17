using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            BrandID = "brand_id",
            Description = "description",
            EffectiveAtOnDowngrade =
                ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately,
            GroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            OnPaymentFailure = ProductCollectionUpdateParamsOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        string expectedID = "pdc_8BWv0hojwUH7iCDabr0NI";
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        ApiEnum<
            string,
            ProductCollectionUpdateParamsEffectiveAtOnDowngrade
        > expectedEffectiveAtOnDowngrade =
            ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately;
        ApiEnum<
            string,
            ProductCollectionUpdateParamsEffectiveAtOnUpgrade
        > expectedEffectiveAtOnUpgrade =
            ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately;
        List<string> expectedGroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure> expectedOnPaymentFailure =
            ProductCollectionUpdateParamsOnPaymentFailure.PreventChange;
        ApiEnum<
            string,
            ProductCollectionUpdateParamsProrationBillingModeOnDowngrade
        > expectedProrationBillingModeOnDowngrade =
            ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately;
        ApiEnum<
            string,
            ProductCollectionUpdateParamsProrationBillingModeOnUpgrade
        > expectedProrationBillingModeOnUpgrade =
            ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEffectiveAtOnDowngrade, parameters.EffectiveAtOnDowngrade);
        Assert.Equal(expectedEffectiveAtOnUpgrade, parameters.EffectiveAtOnUpgrade);
        Assert.NotNull(parameters.GroupOrder);
        Assert.Equal(expectedGroupOrder.Count, parameters.GroupOrder.Count);
        for (int i = 0; i < expectedGroupOrder.Count; i++)
        {
            Assert.Equal(expectedGroupOrder[i], parameters.GroupOrder[i]);
        }
        Assert.Equal(expectedImageID, parameters.ImageID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOnPaymentFailure, parameters.OnPaymentFailure);
        Assert.Equal(
            expectedProrationBillingModeOnDowngrade,
            parameters.ProrationBillingModeOnDowngrade
        );
        Assert.Equal(
            expectedProrationBillingModeOnUpgrade,
            parameters.ProrationBillingModeOnUpgrade
        );
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionUpdateParams { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EffectiveAtOnDowngrade);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at_on_downgrade"));
        Assert.Null(parameters.EffectiveAtOnUpgrade);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at_on_upgrade"));
        Assert.Null(parameters.GroupOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("group_order"));
        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OnPaymentFailure);
        Assert.False(parameters.RawBodyData.ContainsKey("on_payment_failure"));
        Assert.Null(parameters.ProrationBillingModeOnDowngrade);
        Assert.False(parameters.RawBodyData.ContainsKey("proration_billing_mode_on_downgrade"));
        Assert.Null(parameters.ProrationBillingModeOnUpgrade);
        Assert.False(parameters.RawBodyData.ContainsKey("proration_billing_mode_on_upgrade"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",

            BrandID = null,
            Description = null,
            EffectiveAtOnDowngrade = null,
            EffectiveAtOnUpgrade = null,
            GroupOrder = null,
            ImageID = null,
            Name = null,
            OnPaymentFailure = null,
            ProrationBillingModeOnDowngrade = null,
            ProrationBillingModeOnUpgrade = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EffectiveAtOnDowngrade);
        Assert.True(parameters.RawBodyData.ContainsKey("effective_at_on_downgrade"));
        Assert.Null(parameters.EffectiveAtOnUpgrade);
        Assert.True(parameters.RawBodyData.ContainsKey("effective_at_on_upgrade"));
        Assert.Null(parameters.GroupOrder);
        Assert.True(parameters.RawBodyData.ContainsKey("group_order"));
        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OnPaymentFailure);
        Assert.True(parameters.RawBodyData.ContainsKey("on_payment_failure"));
        Assert.Null(parameters.ProrationBillingModeOnDowngrade);
        Assert.True(parameters.RawBodyData.ContainsKey("proration_billing_mode_on_downgrade"));
        Assert.Null(parameters.ProrationBillingModeOnUpgrade);
        Assert.True(parameters.RawBodyData.ContainsKey("proration_billing_mode_on_upgrade"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionUpdateParams parameters = new() { ID = "pdc_8BWv0hojwUH7iCDabr0NI" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/pdc_8BWv0hojwUH7iCDabr0NI"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionUpdateParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            BrandID = "brand_id",
            Description = "description",
            EffectiveAtOnDowngrade =
                ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately,
            GroupOrder = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            OnPaymentFailure = ProductCollectionUpdateParamsOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        ProductCollectionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductCollectionUpdateParamsEffectiveAtOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately)]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnDowngrade.NextBillingDate)]
    public void Validation_Works(ProductCollectionUpdateParamsEffectiveAtOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately)]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnDowngrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(
        ProductCollectionUpdateParamsEffectiveAtOnDowngrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionUpdateParamsEffectiveAtOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately)]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnUpgrade.NextBillingDate)]
    public void Validation_Works(ProductCollectionUpdateParamsEffectiveAtOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately)]
    [InlineData(ProductCollectionUpdateParamsEffectiveAtOnUpgrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(
        ProductCollectionUpdateParamsEffectiveAtOnUpgrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionUpdateParamsOnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionUpdateParamsOnPaymentFailure.PreventChange)]
    [InlineData(ProductCollectionUpdateParamsOnPaymentFailure.ApplyChange)]
    public void Validation_Works(ProductCollectionUpdateParamsOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionUpdateParamsOnPaymentFailure.PreventChange)]
    [InlineData(ProductCollectionUpdateParamsOnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(ProductCollectionUpdateParamsOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionUpdateParamsProrationBillingModeOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DoNotBill)]
    public void Validation_Works(
        ProductCollectionUpdateParamsProrationBillingModeOnDowngrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DoNotBill)]
    public void SerializationRoundtrip_Works(
        ProductCollectionUpdateParamsProrationBillingModeOnDowngrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionUpdateParamsProrationBillingModeOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DoNotBill)]
    public void Validation_Works(
        ProductCollectionUpdateParamsProrationBillingModeOnUpgrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DoNotBill)]
    public void SerializationRoundtrip_Works(
        ProductCollectionUpdateParamsProrationBillingModeOnUpgrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
