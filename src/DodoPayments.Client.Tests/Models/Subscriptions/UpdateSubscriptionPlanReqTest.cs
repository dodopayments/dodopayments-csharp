using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            DiscountCode = "discount_code",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
        };

        string expectedProductID = "product_id";
        ApiEnum<
            string,
            UpdateSubscriptionPlanReqProrationBillingMode
        > expectedProrationBillingMode =
            UpdateSubscriptionPlanReqProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        string expectedDiscountCode = "discount_code";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> expectedOnPaymentFailure =
            UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedProrationBillingMode, model.ProrationBillingMode);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedDiscountCode, model.DiscountCode);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedOnPaymentFailure, model.OnPaymentFailure);
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            DiscountCode = "discount_code",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            DiscountCode = "discount_code",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
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
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        string expectedDiscountCode = "discount_code";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, UpdateSubscriptionPlanReqOnPaymentFailure> expectedOnPaymentFailure =
            UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedProrationBillingMode, deserialized.ProrationBillingMode);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedDiscountCode, deserialized.DiscountCode);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedOnPaymentFailure, deserialized.OnPaymentFailure);
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            DiscountCode = "discount_code",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
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
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.DiscountCode);
        Assert.False(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OnPaymentFailure);
        Assert.False(model.RawData.ContainsKey("on_payment_failure"));
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

            Addons = null,
            DiscountCode = null,
            Metadata = null,
            OnPaymentFailure = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
        Assert.Null(model.DiscountCode);
        Assert.True(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OnPaymentFailure);
        Assert.True(model.RawData.ContainsKey("on_payment_failure"));
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

            Addons = null,
            DiscountCode = null,
            Metadata = null,
            OnPaymentFailure = null,
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            DiscountCode = "discount_code",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnPaymentFailure = UpdateSubscriptionPlanReqOnPaymentFailure.PreventChange,
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
