using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionChangePlanParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedProductID = "product_id";
        ApiEnum<string, ProrationBillingMode> expectedProrationBillingMode =
            ProrationBillingMode.ProratedImmediately;
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

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
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
            Quantity = 0,

            Addons = null,
            Metadata = null,
        };

        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChangePlanParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://live.dodopayments.com/subscriptions/subscription_id/change-plan"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionChangePlanParams
        {
            SubscriptionID = "subscription_id",
            ProductID = "product_id",
            ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        SubscriptionChangePlanParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProrationBillingModeTest : TestBase
{
    [Theory]
    [InlineData(ProrationBillingMode.ProratedImmediately)]
    [InlineData(ProrationBillingMode.FullImmediately)]
    [InlineData(ProrationBillingMode.DifferenceImmediately)]
    public void Validation_Works(ProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProrationBillingMode.ProratedImmediately)]
    [InlineData(ProrationBillingMode.FullImmediately)]
    [InlineData(ProrationBillingMode.DifferenceImmediately)]
    public void SerializationRoundtrip_Works(ProrationBillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProrationBillingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
