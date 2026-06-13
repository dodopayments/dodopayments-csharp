using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class LicenseKeyCreatedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        LicenseKey expectedData = new()
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
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("license_key.created");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        LicenseKey expectedData = new()
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
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("license_key.created");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        LicenseKeyCreatedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
