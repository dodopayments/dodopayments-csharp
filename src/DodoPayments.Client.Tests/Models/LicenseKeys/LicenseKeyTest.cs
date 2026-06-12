using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string expectedID = "lic_123";
        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeySource> expectedSource = LicenseKeySource.Auto;
        ApiEnum<string, LicenseKeyStatus> expectedStatus = LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedPaymentID = "payment_id";
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedInstancesCount, model.InstancesCount);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lic_123";
        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeySource> expectedSource = LicenseKeySource.Auto;
        ApiEnum<string, LicenseKeyStatus> expectedStatus = LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedPaymentID = "payment_id";
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedInstancesCount, deserialized.InstancesCount);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,

            ActivationsLimit = null,
            ExpiresAt = null,
            PaymentID = null,
            SubscriptionID = null,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,

            ActivationsLimit = null,
            ExpiresAt = null,
            PaymentID = null,
            SubscriptionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeySource.Auto,
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        LicenseKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LicenseKeySourceTest : TestBase
{
    [Theory]
    [InlineData(LicenseKeySource.Auto)]
    [InlineData(LicenseKeySource.Import)]
    [InlineData(LicenseKeySource.Manual)]
    public void Validation_Works(LicenseKeySource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeySource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeySource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LicenseKeySource.Auto)]
    [InlineData(LicenseKeySource.Import)]
    [InlineData(LicenseKeySource.Manual)]
    public void SerializationRoundtrip_Works(LicenseKeySource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeySource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeySource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeySource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeySource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
