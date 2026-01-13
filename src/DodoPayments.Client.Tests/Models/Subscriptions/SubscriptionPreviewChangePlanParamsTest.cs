using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionPreviewChangePlanParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedProductID = "product_id";
        ApiEnum<
            string,
            SubscriptionPreviewChangePlanParamsProrationBillingMode
        > expectedProrationBillingMode =
            SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedProrationBillingMode, parameters.ProrationBillingMode);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionPreviewChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,

            Addons = null,
        };

        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionPreviewChangePlanParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode =
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/subscriptions/subscription_id/change-plan/preview"
            ),
            url
        );
    }
}

public class SubscriptionPreviewChangePlanParamsProrationBillingModeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.FullImmediately)]
    [InlineData(SubscriptionPreviewChangePlanParamsProrationBillingMode.DifferenceImmediately)]
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
