using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
            EffectiveAtOnDowngrade = EffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = EffectiveAtOnUpgrade.Immediately,
            OnPaymentFailure = OnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade = ProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade = ProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        List<ProductCollectionGroupDetails> expectedGroups =
        [
            new()
            {
                Products = [new() { ProductID = "product_id", Status = true }],
                GroupName = "group_name",
                Status = true,
            },
        ];
        string expectedName = "name";
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        ApiEnum<string, EffectiveAtOnDowngrade> expectedEffectiveAtOnDowngrade =
            EffectiveAtOnDowngrade.Immediately;
        ApiEnum<string, EffectiveAtOnUpgrade> expectedEffectiveAtOnUpgrade =
            EffectiveAtOnUpgrade.Immediately;
        ApiEnum<string, OnPaymentFailure> expectedOnPaymentFailure = OnPaymentFailure.PreventChange;
        ApiEnum<string, ProrationBillingModeOnDowngrade> expectedProrationBillingModeOnDowngrade =
            ProrationBillingModeOnDowngrade.ProratedImmediately;
        ApiEnum<string, ProrationBillingModeOnUpgrade> expectedProrationBillingModeOnUpgrade =
            ProrationBillingModeOnUpgrade.ProratedImmediately;

        Assert.Equal(expectedGroups.Count, parameters.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], parameters.Groups[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEffectiveAtOnDowngrade, parameters.EffectiveAtOnDowngrade);
        Assert.Equal(expectedEffectiveAtOnUpgrade, parameters.EffectiveAtOnUpgrade);
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
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EffectiveAtOnDowngrade);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at_on_downgrade"));
        Assert.Null(parameters.EffectiveAtOnUpgrade);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_at_on_upgrade"));
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
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",

            BrandID = null,
            Description = null,
            EffectiveAtOnDowngrade = null,
            EffectiveAtOnUpgrade = null,
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
        ProductCollectionCreateParams parameters = new()
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/product-collections"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
            EffectiveAtOnDowngrade = EffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = EffectiveAtOnUpgrade.Immediately,
            OnPaymentFailure = OnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade = ProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade = ProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        ProductCollectionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EffectiveAtOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(EffectiveAtOnDowngrade.Immediately)]
    [InlineData(EffectiveAtOnDowngrade.NextBillingDate)]
    public void Validation_Works(EffectiveAtOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffectiveAtOnDowngrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnDowngrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EffectiveAtOnDowngrade.Immediately)]
    [InlineData(EffectiveAtOnDowngrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(EffectiveAtOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffectiveAtOnDowngrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnDowngrade>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnDowngrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnDowngrade>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EffectiveAtOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(EffectiveAtOnUpgrade.Immediately)]
    [InlineData(EffectiveAtOnUpgrade.NextBillingDate)]
    public void Validation_Works(EffectiveAtOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffectiveAtOnUpgrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnUpgrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EffectiveAtOnUpgrade.Immediately)]
    [InlineData(EffectiveAtOnUpgrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(EffectiveAtOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffectiveAtOnUpgrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnUpgrade>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnUpgrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffectiveAtOnUpgrade>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(OnPaymentFailure.PreventChange)]
    [InlineData(OnPaymentFailure.ApplyChange)]
    public void Validation_Works(OnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OnPaymentFailure.PreventChange)]
    [InlineData(OnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(OnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OnPaymentFailure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OnPaymentFailure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProrationBillingModeOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(ProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.DoNotBill)]
    public void Validation_Works(ProrationBillingModeOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingModeOnDowngrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingModeOnDowngrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProrationBillingModeOnDowngrade.DoNotBill)]
    public void SerializationRoundtrip_Works(ProrationBillingModeOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingModeOnDowngrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingModeOnDowngrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProrationBillingModeOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(ProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.DoNotBill)]
    public void Validation_Works(ProrationBillingModeOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingModeOnUpgrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingModeOnUpgrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProrationBillingModeOnUpgrade.DoNotBill)]
    public void SerializationRoundtrip_Works(ProrationBillingModeOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingModeOnUpgrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingModeOnUpgrade>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
